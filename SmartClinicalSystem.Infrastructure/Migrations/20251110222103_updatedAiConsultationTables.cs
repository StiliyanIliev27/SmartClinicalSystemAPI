using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedAiConsultationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AiConsultations");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "a655d45e-0e7b-4e76-bb00-9aad1bf56662");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "ae5538d4-f708-476a-9087-34fee94a8023");

            migrationBuilder.CreateTable(
                name: "AiCompareConsultations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstMedicineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecondMedicineId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AiResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiCompareConsultations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AiCompareConsultations_Medicines_FirstMedicineId",
                        column: x => x.FirstMedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AiCompareConsultations_Medicines_SecondMedicineId",
                        column: x => x.SecondMedicineId,
                        principalTable: "Medicines",
                        principalColumn: "MedicineId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AiDiagnosisConsultations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AiResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiDiagnosisConsultations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AiSummaryCheckerConsultations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    InputPeriod = table.Column<int>(type: "int", nullable: false, comment: "The period (in days) for which the summary is to be checked"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AiResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiSummaryCheckerConsultations", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2ee527ae-bd3d-477b-a9bb-b19b0ae7513b", "AQAAAAIAAYagAAAAEBgujKGTneB6BLxGlKhZELudl/HUBXT9oEAkRepjZ28XHm1d4gOkX3yp+cOu0Pbrqw==", "5eeae18b-9481-47a0-9da7-f917b2db5731" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "10d1cb23-bf74-4e3f-be2b-2e7c1b0006ac", "AQAAAAIAAYagAAAAEAjZqxnx4Z4zUVaZXTCYBiWuUu8b5F8VpGND8nK985SO61oQuHAv+X1QbMlHBhLxGg==", "5f193c9e-b58f-4720-8b09-9daf1034ab07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2724a605-60d7-400b-86da-c30ea3a98825", "AQAAAAIAAYagAAAAEFjo5c8rMM4RBfrfp5XO7qXiMgPoL4xCBIVmzXnXmNCL48yDXT+yXY9hpi2F+XA+yw==", "ec9b8494-18df-4823-b455-260f7c10583f" });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-1",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 11, 0, 21, 3, 23, DateTimeKind.Local).AddTicks(6059), new DateTime(2025, 11, 18, 0, 21, 3, 23, DateTimeKind.Local).AddTicks(6039), new DateTime(2025, 11, 11, 0, 21, 3, 23, DateTimeKind.Local).AddTicks(6036) });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-2",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 11, 0, 21, 3, 23, DateTimeKind.Local).AddTicks(6069), new DateTime(2025, 11, 21, 0, 21, 3, 23, DateTimeKind.Local).AddTicks(6067), new DateTime(2025, 11, 11, 0, 21, 3, 23, DateTimeKind.Local).AddTicks(6066) });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4228));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(3999));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4196));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4200));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4203));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4206));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4213));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4216));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4219));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 10, 22, 21, 2, 131, DateTimeKind.Utc).AddTicks(4222));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "2db2cf7b-827b-4f38-ab0f-5eade07e9bcc", "    You are a senior clinical AI assistant reviewing a doctor's medical receipt.\r\n\r\n    ### Your Goals\r\n    1. Evaluate the doctor's diagnosis for completeness and clarity.\r\n    2. Refine or expand it into a more detailed but concise medical explanation.\r\n    3. Ensure the prescribed medicines are appropriate for the diagnosis.\r\n    4. Write patient-friendly advice that complements the doctor's notes — not just repeats them.\r\n\r\n    ### Your Response\r\n    Respond strictly in **JSON** format:\r\n    {\r\n      \"aiDiagnosis\": \"Refined, detailed diagnosis in clinical terms (do not copy doctor's text verbatim)\",\r\n      \"aiAdvice\": \"Expanded advice with lifestyle or follow-up recommendations (friendly and medically sound)\"\r\n    }\r\n\r\n    Avoid repeating the doctor's text; instead, validate and *enhance* it.\r\n    Keep responses short (2–3 sentences per field).         ", new DateTime(2025, 11, 10, 22, 21, 2, 313, DateTimeKind.Utc).AddTicks(6314), null, "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.", false, "Default Receipt Review Prompt", 4, null },
                    { "31dead47-a087-4041-a4d8-92bc6d0a5fa6", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 11, 0, 21, 2, 313, DateTimeKind.Local).AddTicks(6302), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AiCompareConsultations_FirstMedicineId",
                table: "AiCompareConsultations",
                column: "FirstMedicineId");

            migrationBuilder.CreateIndex(
                name: "IX_AiCompareConsultations_SecondMedicineId",
                table: "AiCompareConsultations",
                column: "SecondMedicineId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AiCompareConsultations");

            migrationBuilder.DropTable(
                name: "AiDiagnosisConsultations");

            migrationBuilder.DropTable(
                name: "AiSummaryCheckerConsultations");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "2db2cf7b-827b-4f38-ab0f-5eade07e9bcc");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "31dead47-a087-4041-a4d8-92bc6d0a5fa6");

            migrationBuilder.CreateTable(
                name: "AiConsultations",
                columns: table => new
                {
                    AiConsultationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AiResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Symptoms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AiConsultations", x => x.AiConsultationId);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "35f6218f-4df0-402d-b3aa-91e3606c1ebe", "AQAAAAIAAYagAAAAEK8JKwmS9LWtKgs3DWPTfCZMaq/ODjEM8IId82GrLSP0QtMYwmNDxZAmovptI+YfWA==", "447afa20-ce90-471d-8bcc-4ca6106bc052" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "80f5d146-2bce-4f8b-9173-ec2566b5316a", "AQAAAAIAAYagAAAAEIcM6ZC8O8al/zCEXAOpAPI02WMpTCY36Q2pIH4GA9Q6nZNGLeOp98N2DYwS2CS8JQ==", "f4766325-eebe-498a-b70e-0d0dcfb9d469" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "27e4c707-3966-4c50-aa68-a1807a565c03", "AQAAAAIAAYagAAAAEI/OHlL4M5jbWE6WUr2m76E4ORhpz1me+Zr33HbqvKX3jAyyiSdTEf2+1Tp23Dc8Ig==", "5cda5e6f-0f3e-4858-b162-f1b41dc90015" });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-1",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 8, 13, 17, 0, 17, DateTimeKind.Local).AddTicks(3106), new DateTime(2025, 11, 15, 13, 17, 0, 17, DateTimeKind.Local).AddTicks(3085), new DateTime(2025, 11, 8, 13, 17, 0, 17, DateTimeKind.Local).AddTicks(3082) });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-2",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 8, 13, 17, 0, 17, DateTimeKind.Local).AddTicks(3114), new DateTime(2025, 11, 18, 13, 17, 0, 17, DateTimeKind.Local).AddTicks(3112), new DateTime(2025, 11, 8, 13, 17, 0, 17, DateTimeKind.Local).AddTicks(3111) });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9645));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9530));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9580));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9612));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9619));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9627));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9632));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9636));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 11, 16, 59, 222, DateTimeKind.Utc).AddTicks(9641));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "a655d45e-0e7b-4e76-bb00-9aad1bf56662", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 8, 13, 16, 59, 395, DateTimeKind.Local).AddTicks(9868), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null },
                    { "ae5538d4-f708-476a-9087-34fee94a8023", "    You are a senior clinical AI assistant reviewing a doctor's medical receipt.\r\n\r\n    ### Your Goals\r\n    1. Evaluate the doctor's diagnosis for completeness and clarity.\r\n    2. Refine or expand it into a more detailed but concise medical explanation.\r\n    3. Ensure the prescribed medicines are appropriate for the diagnosis.\r\n    4. Write patient-friendly advice that complements the doctor's notes — not just repeats them.\r\n\r\n    ### Your Response\r\n    Respond strictly in **JSON** format:\r\n    {\r\n      \"aiDiagnosis\": \"Refined, detailed diagnosis in clinical terms (do not copy doctor's text verbatim)\",\r\n      \"aiAdvice\": \"Expanded advice with lifestyle or follow-up recommendations (friendly and medically sound)\"\r\n    }\r\n\r\n    Avoid repeating the doctor's text; instead, validate and *enhance* it.\r\n    Keep responses short (2–3 sentences per field).         ", new DateTime(2025, 11, 8, 11, 16, 59, 395, DateTimeKind.Utc).AddTicks(9879), null, "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.", false, "Default Receipt Review Prompt", 4, null }
                });
        }
    }
}
