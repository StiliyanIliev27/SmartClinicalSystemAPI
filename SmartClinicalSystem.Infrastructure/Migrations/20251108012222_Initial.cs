using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AiConsultations",
                columns: table => new
                {
                    AiConsultationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Category = table.Column<int>(type: "int", nullable: false),
                    AiResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiConsultations", x => x.AiConsultationId);
                });

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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MedicalReceipts",
                columns: table => new
                {
                    MedicalReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    PatientId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Diagnosis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Advice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpirationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AiDiagnosis = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AiAdvice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalReceipts", x => x.MedicalReceiptId);
                    table.ForeignKey(
                        name: "FK_MedicalReceipts_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_MedicalReceipts_AspNetUsers_PatientId",
                        column: x => x.PatientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "MedicalReceiptsMedicines",
                columns: table => new
                {
                    ReceiptMedicineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicalReceiptId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MedicineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    DosageInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DurationDays = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicalReceiptsMedicines", x => x.ReceiptMedicineId);
                    table.ForeignKey(
                        name: "FK_MedicalReceiptsMedicines_MedicalReceipts_MedicalReceiptId",
                        column: x => x.MedicalReceiptId,
                        principalTable: "MedicalReceipts",
                        principalColumn: "MedicalReceiptId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MedicalReceiptsMedicines_Medicines_MedicineId",
                        column: x => x.MedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "4f8554d2-cfaa-44b5-90ce-e883c804ae90", "4f8554d2-cfaa-44b5-90ce-e883c804ae90", "User", "USER" },
                    { "50622ab4-fb1c-41b3-87f0-a225bd75e2a6", "50622ab4-fb1c-41b3-87f0-a225bd75e2a6", "Doctor", "DOCTOR" },
                    { "656a6079-ec9a-4a98-a484-2d1752156d60", "656a6079-ec9a-4a98-a484-2d1752156d60", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "27d78708-8671-4b05-bd5e-17aa91392224", 0, "dfb55ac2-dd94-470d-8ba4-88e6159fcc4e", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN_ADMINOV", "AQAAAAIAAYagAAAAECab9urmPj2vW/1rQ2HLUzVApbxXpGuitynnItAtan6YVXQP349IW2JMIX3rfZyYOw==", null, false, "2f4d7a8a-c674-48f3-9468-c69f6317224c", false, "admin_adminov" },
                    { "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780", 0, "666ac0b3-0293-4b58-83ea-b7e7263d60c9", "doctor@doctor.com", true, false, null, "DOCTOR@DOCTOR.COM", "DOCTOR_DOCTOROV", "AQAAAAIAAYagAAAAEIwOXoZlDitjazRwb9A5ZfipRdYQopsOfpSXnglSqqtImL7oJTw7of7rsLMKpukCfw==", null, false, "8f6b9cd2-7f96-4f4d-a666-e25fee23caa5", false, "doctor_doctorov" },
                    { "f8472c89-f48d-49cc-8517-a81153d47cdd", 0, "436a47f5-c778-48ce-b9b3-8fa717e06094", "user@user.com", true, false, null, "USER@USER.COM", "USER_USEROV", "AQAAAAIAAYagAAAAELgDgyIqV7lEhxXJ4xuV4VYPb++gMU6UwJfOsVqJjGDFsZETYKUmtHrOn5xcsFNVLA==", null, false, "c3609192-0c6e-49ab-a8d9-9480729e4c81", false, "user_userov" }
                });

            migrationBuilder.InsertData(
                table: "Medicines",
                columns: new[] { "MedicineId", "AiSummary", "Category", "Contraindications", "CreatedAt", "DeletedOn", "Description", "DosageForm", "GenericName", "Indications", "IsDeleted", "LastAiUpdated", "Manufacturer", "Precautions", "Price", "SideEffects", "StockQuantity", "Strength", "UpdatedAt" },
                values: new object[,]
                {
                    { "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y", null, 11, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1039), null, null, "Tablet", "Cetirizine", null, false, null, "AllergyRelief", null, 1.5m, null, 500, "10mg", null },
                    { "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p", null, 1, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(999), null, null, "Tablet", "Paracetamol", null, false, null, "PharmaCorp", null, 2.5m, null, 100, "500mg", null },
                    { "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q", null, 1, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1011), null, null, "Capsule", "Ibuprofen", null, false, null, "HealthMeds", null, 3.0m, null, 200, "200mg", null },
                    { "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r", null, 2, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1014), null, null, "Capsule", "Amoxicillin", null, false, null, "MediLife", null, 5.0m, null, 150, "250mg", null },
                    { "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s", null, 3, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1017), null, null, "Tablet", "Acyclovir", null, false, null, "ViralPharma", null, 8.0m, null, 50, "400mg", null },
                    { "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t", null, 4, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1020), null, null, "Capsule", "Fluconazole", null, false, null, "FungalCare", null, 6.0m, null, 75, "150mg", null },
                    { "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u", null, 7, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1026), null, null, "Tablet", "Metformin", null, false, null, "DiabetesCare", null, 4.0m, null, 300, "500mg", null },
                    { "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v", null, 6, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1029), null, null, "Tablet", "Losartan", null, false, null, "HeartHealth", null, 3.5m, null, 250, "50mg", null },
                    { "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w", null, 9, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1032), null, null, "Capsule", "Omeprazole", null, false, null, "DigestiveCare", null, 2.0m, null, 400, "20mg", null },
                    { "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x", null, 10, null, new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1035), null, null, "Inhaler", "Salbutamol", null, false, null, "BreathEasy", null, 10.0m, null, 120, "100mcg", null }
                });

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "56432313-e72d-456d-b425-7d05a100e0ec", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 8, 3, 22, 21, 414, DateTimeKind.Local).AddTicks(2371), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null },
                    { "9e7855d1-a68a-4679-8414-e3803d11135d", "    You are a medical AI expert reviewing a doctor's prescription.\r\n    Analyze the doctor's diagnosis and medicines for logical consistency.\r\n    Respond strictly in JSON:\r\n    {\r\n        \"aiDiagnosis\": \"refined and concise summary of diagnosis\",\r\n        \"aiAdvice\": \"short, patient-friendly guidance\"\r\n    }", new DateTime(2025, 11, 8, 1, 22, 21, 414, DateTimeKind.Utc).AddTicks(2387), null, "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.", false, "Default Receipt Review Prompt", 4, null }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { "50622ab4-fb1c-41b3-87f0-a225bd75e2a6", "27d78708-8671-4b05-bd5e-17aa91392224" },
                    { "656a6079-ec9a-4a98-a484-2d1752156d60", "27d78708-8671-4b05-bd5e-17aa91392224" },
                    { "50622ab4-fb1c-41b3-87f0-a225bd75e2a6", "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780" },
                    { "4f8554d2-cfaa-44b5-90ce-e883c804ae90", "f8472c89-f48d-49cc-8517-a81153d47cdd" }
                });

            migrationBuilder.InsertData(
                table: "MedicalReceipts",
                columns: new[] { "MedicalReceiptId", "Advice", "AiAdvice", "AiDiagnosis", "CreatedAt", "DeletedOn", "Diagnosis", "DoctorId", "ExpirationDate", "IsDeleted", "IssueDate", "PatientId", "UpdatedAt" },
                values: new object[,]
                {
                    { "rec-1", "Take rest and drink fluids.", "Increase hydration and rest.", "Possible viral infection", new DateTime(2025, 11, 8, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8887), null, "Viral Pharyngitis", "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780", new DateTime(2025, 11, 15, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8865), false, new DateTime(2025, 11, 8, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8864), "f8472c89-f48d-49cc-8517-a81153d47cdd", null },
                    { "rec-2", "Complete the antibiotic course.", "Avoid spicy foods.", "Possible bacterial tonsillitis", new DateTime(2025, 11, 8, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8900), null, "Bacterial Tonsillitis", "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780", new DateTime(2025, 11, 18, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8898), false, new DateTime(2025, 11, 8, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8896), "f8472c89-f48d-49cc-8517-a81153d47cdd", null }
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
                name: "IX_MedicalReceipts_DoctorId",
                table: "MedicalReceipts",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReceipts_PatientId",
                table: "MedicalReceipts",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReceiptsMedicines_MedicalReceiptId",
                table: "MedicalReceiptsMedicines",
                column: "MedicalReceiptId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalReceiptsMedicines_MedicineId",
                table: "MedicalReceiptsMedicines",
                column: "MedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AiConsultations");

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
                name: "MedicalReceiptsMedicines");

            migrationBuilder.DropTable(
                name: "PromptTemplates");

            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "MedicalReceipts");

            migrationBuilder.DropTable(
                name: "Medicines");

            migrationBuilder.DropTable(
                name: "AspNetUsers");
        }
    }
}
