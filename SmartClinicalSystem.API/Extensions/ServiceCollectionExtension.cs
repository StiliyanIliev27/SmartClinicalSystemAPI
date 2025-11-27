using BuildingBlock.BuildingBlocks.Behaviours;
using FluentValidation;
using Mapster;
using MapsterMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using OpenAI;
using SmartClinicalSystem.API.Exceptions.Handler;
using SmartClinicalSystem.API.Mapping;
using SmartClinicalSystem.Core.Configs;
using SmartClinicalSystem.Core.Contracts;
using SmartClinicalSystem.Core.Queries.Medicines;
using SmartClinicalSystem.Core.Services;
using SmartClinicalSystem.Infrastructure.Common;
using SmartClinicalSystem.Infrastructure.Data;
using SmartClinicalSystem.Infrastructure.Data.Models;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Mapping configuration
            var config = TypeAdapterConfig.GlobalSettings;
            config.Scan(typeof(MappingConfig).Assembly);
            services.AddSingleton(config);
            services.AddScoped<IMapper, ServiceMapper>();

            services.AddValidatorsFromAssembly(typeof(GetMedicineByIdQueryHandler).Assembly);

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new() { Title = "SmartClinicalSystem API", Version = "v1" });

                // 🔐 Add JWT Bearer security definition
                options.AddSecurityDefinition("Bearer", new OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = OpenApi.Models.SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = OpenApi.Models.ParameterLocation.Header,
                    Description = "Enter 'Bearer' [space] and then your JWT. Example: 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...'"
                });

                // 🔐 Require Bearer token for endpoints that need it
                options.AddSecurityRequirement(new OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                    new OpenApi.Models.OpenApiSecurityScheme
                    {
                        Reference = new OpenApi.Models.OpenApiReference
                        {
                            Type = OpenApi.Models.ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        }
                    },
                    Array.Empty<string>()
                    }
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend",
                    policy =>
                    {
                        policy.WithOrigins("http://localhost:5173") // Front end url
                              .AllowAnyHeader()
                              .AllowAnyMethod()
                              .AllowCredentials();
                    });
            });



            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<ISmartService, SmartService>();
            services.AddScoped<INotificationService, NotificationService>();

            return services;
        }

        public static IServiceCollection AddApplicationDbContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<SmartClinicalSystemDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(typeof(GetMedicineByIdQueryHandler).Assembly);
                cfg.AddOpenBehavior(typeof(ValidationBehavior<,>));
                cfg.AddOpenBehavior(typeof(LoggingBehaviour<,>));
            });

            // Bind OpenAI config
            services.Configure<OpenAiOptions>(config.GetSection("OpenAI"));

            // Register OpenAI client
            services.AddSingleton(sp =>
            {
                var options = sp.GetRequiredService<IOptions<OpenAiOptions>>().Value;
                return new OpenAIClient(options.ApiKey);
            });

            services.AddScoped<IRepository, Repository>();

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                {
                    builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
                });
            });

            services.AddExceptionHandler<CustomExceptionHandler>();

            return services;
        }

        public static IServiceCollection AddApplicationIdentity(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>("SmartClinicalSystem")
                .AddEntityFrameworkStores<SmartClinicalSystemDbContext>()
                .AddDefaultTokenProviders();

            // Password requirements
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 5;
                options.SignIn.RequireConfirmedEmail = true;
            });

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = config["Jwt:Issuer"],
                        ValidAudience = config["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]!)),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }
    }
}
