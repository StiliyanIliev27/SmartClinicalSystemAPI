using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class updatedDoctorDiagnosisAIpromptTemplate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "56432313-e72d-456d-b425-7d05a100e0ec");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "9e7855d1-a68a-4679-8414-e3803d11135d");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "a655d45e-0e7b-4e76-bb00-9aad1bf56662");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "ae5538d4-f708-476a-9087-34fee94a8023");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dfb55ac2-dd94-470d-8ba4-88e6159fcc4e", "AQAAAAIAAYagAAAAECab9urmPj2vW/1rQ2HLUzVApbxXpGuitynnItAtan6YVXQP349IW2JMIX3rfZyYOw==", "2f4d7a8a-c674-48f3-9468-c69f6317224c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "666ac0b3-0293-4b58-83ea-b7e7263d60c9", "AQAAAAIAAYagAAAAEIwOXoZlDitjazRwb9A5ZfipRdYQopsOfpSXnglSqqtImL7oJTw7of7rsLMKpukCfw==", "8f6b9cd2-7f96-4f4d-a666-e25fee23caa5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "436a47f5-c778-48ce-b9b3-8fa717e06094", "AQAAAAIAAYagAAAAELgDgyIqV7lEhxXJ4xuV4VYPb++gMU6UwJfOsVqJjGDFsZETYKUmtHrOn5xcsFNVLA==", "c3609192-0c6e-49ab-a8d9-9480729e4c81" });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-1",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 8, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8887), new DateTime(2025, 11, 15, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8865), new DateTime(2025, 11, 8, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8864) });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-2",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 8, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8900), new DateTime(2025, 11, 18, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8898), new DateTime(2025, 11, 8, 3, 22, 21, 977, DateTimeKind.Local).AddTicks(8896) });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1039));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(999));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1011));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1014));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1017));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1020));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1026));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1029));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1032));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 8, 1, 22, 21, 277, DateTimeKind.Utc).AddTicks(1035));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "56432313-e72d-456d-b425-7d05a100e0ec", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 8, 3, 22, 21, 414, DateTimeKind.Local).AddTicks(2371), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null },
                    { "9e7855d1-a68a-4679-8414-e3803d11135d", "    You are a medical AI expert reviewing a doctor's prescription.\r\n    Analyze the doctor's diagnosis and medicines for logical consistency.\r\n    Respond strictly in JSON:\r\n    {\r\n        \"aiDiagnosis\": \"refined and concise summary of diagnosis\",\r\n        \"aiAdvice\": \"short, patient-friendly guidance\"\r\n    }", new DateTime(2025, 11, 8, 1, 22, 21, 414, DateTimeKind.Utc).AddTicks(2387), null, "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.", false, "Default Receipt Review Prompt", 4, null }
                });
        }
    }
}
