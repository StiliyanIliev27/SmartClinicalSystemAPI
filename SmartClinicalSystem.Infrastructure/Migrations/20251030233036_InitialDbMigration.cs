using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDbMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    MedicineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GenericName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    DosageForm = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Strength = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Indications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contraindications = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SideEffects = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precautions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AiSummary = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastAiUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.MedicineId);
                });

            migrationBuilder.CreateTable(
                name: "PromptTemplates",
                columns: table => new
                {
                    PromptTemplateId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PromptTemplates", x => x.PromptTemplateId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Revoked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f8554d2-cfaa-44b5-90ce-e883c804ae90", "4f8554d2-cfaa-44b5-90ce-e883c804ae90", "User", "USER" },
                    { "656a6079-ec9a-4a98-a484-2d1752156d60", "656a6079-ec9a-4a98-a484-2d1752156d60", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "27d78708-8671-4b05-bd5e-17aa91392224", 0, "f759cf48-0439-447f-a708-76d299203917", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", null, "AQAAAAIAAYagAAAAELTxtT6aUTh0qfD+giXsR1pdad9cQ3xEAr7qDcaZLSeMfwBPc9M+33a2mU6gdk0Rrw==", null, false, "d5a75b1a-229a-4de1-9153-2d093ee510e6", false, null },
                    { "f8472c89-f48d-49cc-8517-a81153d47cdd", 0, "fb28312b-6cf2-4f78-a3b5-213eedca60d4", "user@user.com", true, false, null, "USER@USER.COM", null, "AQAAAAIAAYagAAAAEICOOOMUaoaDbsye5I7dtoN4IARfLfcZptUMMIOl0lgpTA8WMDMWTUayFhzmX8TMjQ==", null, false, "95822bb2-6318-4ef2-b83c-776a0c8eaa62", false, null }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "MedicineId", "AiSummary", "Category", "Contraindications", "CreatedAt", "DeletedOn", "Description", "DosageForm", "GenericName", "Indications", "IsDeleted", "LastAiUpdated", "Manufacturer", "Precautions", "Price", "SideEffects", "StockQuantity", "Strength", "UpdatedAt" },
                values: new object[,]
                {
                    { "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y", null, 11, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4969), null, null, "Tablet", "Cetirizine", null, false, null, "AllergyRelief", null, 1.5m, null, 500, "10mg", null },
                    { "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p", null, 1, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4906), null, null, "Tablet", "Paracetamol", null, false, null, "PharmaCorp", null, 2.5m, null, 100, "500mg", null },
                    { "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q", null, 1, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4918), null, null, "Capsule", "Ibuprofen", null, false, null, "HealthMeds", null, 3.0m, null, 200, "200mg", null },
                    { "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r", null, 2, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4923), null, null, "Capsule", "Amoxicillin", null, false, null, "MediLife", null, 5.0m, null, 150, "250mg", null },
                    { "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s", null, 3, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4927), null, null, "Tablet", "Acyclovir", null, false, null, "ViralPharma", null, 8.0m, null, 50, "400mg", null },
                    { "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t", null, 4, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4930), null, null, "Capsule", "Fluconazole", null, false, null, "FungalCare", null, 6.0m, null, 75, "150mg", null },
                    { "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u", null, 7, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4950), null, null, "Tablet", "Metformin", null, false, null, "DiabetesCare", null, 4.0m, null, 300, "500mg", null },
                    { "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v", null, 6, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4956), null, null, "Tablet", "Losartan", null, false, null, "HeartHealth", null, 3.5m, null, 250, "50mg", null },
                    { "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w", null, 9, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4960), null, null, "Capsule", "Omeprazole", null, false, null, "DigestiveCare", null, 2.0m, null, 400, "20mg", null },
                    { "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x", null, 10, null, new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4964), null, null, "Inhaler", "Salbutamol", null, false, null, "BreathEasy", null, 10.0m, null, 120, "100mcg", null }
                });

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[] { "c9b42596-ebb7-4460-a4fd-18feba292546", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 10, 31, 1, 30, 36, 297, DateTimeKind.Local).AddTicks(9077), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "656a6079-ec9a-4a98-a484-2d1752156d60", "27d78708-8671-4b05-bd5e-17aa91392224" },
                    { "4f8554d2-cfaa-44b5-90ce-e883c804ae90", "f8472c89-f48d-49cc-8517-a81153d47cdd" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "PromptTemplates");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
