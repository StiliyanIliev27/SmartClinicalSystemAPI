using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedUserHealthLogsToDoctorsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "0559967f-9094-4d7b-8a41-d5b1fb0d4d67");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "647d7aa8-a4b1-433c-81a3-49380c29d601");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "d9334538-0769-4053-8914-28cf40d5fec3");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "e6a43ad3-ca70-42bf-afbf-58529cfa309f");

            migrationBuilder.CreateTable(
                name: "UserHealthLogsToDoctors",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserHealthLogId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DoctorId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    IsViewedByDoctor = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHealthLogsToDoctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserHealthLogsToDoctors_AspNetUsers_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserHealthLogsToDoctors_UserHealthLogs_UserHealthLogId",
                        column: x => x.UserHealthLogId,
                        principalTable: "UserHealthLogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f32df39e-75a8-4381-a79e-437e27cd523c", "AQAAAAIAAYagAAAAEL3hjDFjDnSzjBZKSMv9AaYRBZNMyoiTJpWorjZZG7VE2auXhjyqOwqO6iAA5iqhZA==", "53a00036-92d9-4c42-a38c-ad6683a99cbe" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "63a94cde-f5b0-4ca0-af4c-2dcd7fbf5944", "AQAAAAIAAYagAAAAEIswpfjotY1XPjMb4m8vVBkjKoLM5lmZrtIoO1WgXa4fg8+pSbWK8Rn93DCxgEM7+Q==", "1b2e3bc3-317f-42ee-b599-e88a735a25fd" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b6711fd3-11ad-4b24-b7fc-37b9d0cf1249", "AQAAAAIAAYagAAAAEFocfeOoJFU7LB1WCht5MUNYFXnJ0r4M1KrqzfxNkc+vAdXBBnsM1GStWmHE2Z1Oww==", "ee0c6a73-31b9-4d27-8f5e-f568a20924ff" });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-1",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 19, 1, 7, 9, 663, DateTimeKind.Local).AddTicks(451), new DateTime(2025, 11, 26, 1, 7, 9, 663, DateTimeKind.Local).AddTicks(432), new DateTime(2025, 11, 19, 1, 7, 9, 663, DateTimeKind.Local).AddTicks(431) });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-2",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 19, 1, 7, 9, 663, DateTimeKind.Local).AddTicks(457), new DateTime(2025, 11, 29, 1, 7, 9, 663, DateTimeKind.Local).AddTicks(456), new DateTime(2025, 11, 19, 1, 7, 9, 663, DateTimeKind.Local).AddTicks(455) });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(755));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(631));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(642));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(646));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(649));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(656));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(682));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(685));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 18, 23, 7, 8, 980, DateTimeKind.Utc).AddTicks(750));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "8933ab06-9aaa-4232-b7e0-7a449650096e", "You are a professional medical AI system.\r\n\r\nCompare the two medicines based on how relevant they are for the given diagnosis.\r\n\r\nFor each medicine:\r\n- Analyze indications relevance\r\n- Match diagnosis keywords\r\n- Score relevance from 0 to 10\r\n- Provide matched keywords\r\n\r\nRespond STRICTLY in JSON using this structure:\r\n\r\n{\r\n    \"diagnosis\": \"string\",\r\n    \"a\": {\r\n        \"medicineId\": \"id1\",\r\n        \"matchScore\": 0,\r\n        \"matchingKeywords\": [\"word1\",\"word2\"]\r\n    },\r\n    \"b\": {\r\n        \"medicineId\": \"id2\",\r\n        \"matchScore\": 0,\r\n        \"matchingKeywords\": [\"word1\"]\r\n    },\r\n    \"betterMedicineId\": \"id1\",\r\n    \"explanation\": \"string\"\r\n}", new DateTime(2025, 11, 19, 1, 7, 9, 115, DateTimeKind.Local).AddTicks(6261), null, null, false, "Medicine Comparison Prompt", 5, null },
                    { "8bd4cdb5-09e5-4794-93b3-44ed63fc6527", "You are a professional AI health assistant working in a Smart Clinical System.\r\n\r\nYour task:\r\nAnalyze the user's medical receipts AND personal health logs for the given time period.\r\nConsider:\r\n- Reported symptoms\r\n- Pain levels\r\n- Mood logs\r\n- Temperatures\r\n- Notes written by the user\r\n- Side effects\r\n- Medications prescribed in the receipts\r\n- Consistency or worsening of symptoms\r\n\r\nYour goal:\r\nProduce a clear, friendly, medically helpful health summary (4–6 sentences).\r\nDo NOT diagnose new illnesses. Base everything STRICTLY on the provided data.\r\n\r\nRespond STRICTLY in JSON using the following structure:\r\n\r\n{\r\n    \"timePeriodDays\": number,\r\n    \"summary\": \"string (4–6 sentences summarizing health trends)\",\r\n    \"keyConcerns\": [\"string\", \"string\"],\r\n    \"positiveTrends\": [\"string\", \"string\"],\r\n    \"recommendedActions\": [\"string\", \"string\"]\r\n}\r\n\r\nRules:\r\n- No markdown\r\n- No extra text outside JSON\r\n- No invented data\r\n- Summaries must directly refer to the provided logs and receipts", new DateTime(2025, 11, 19, 1, 7, 9, 115, DateTimeKind.Local).AddTicks(6263), null, null, false, "Health Summary Check Prompt", 2, null },
                    { "b415e309-7109-4561-8147-0641a7151efb", "    You are a senior clinical AI assistant reviewing a doctor's medical receipt.\r\n\r\n    ### Your Goals\r\n    1. Evaluate the doctor's diagnosis for completeness and clarity.\r\n    2. Refine or expand it into a more detailed but concise medical explanation.\r\n    3. Ensure the prescribed medicines are appropriate for the diagnosis.\r\n    4. Write patient-friendly advice that complements the doctor's notes — not just repeats them.\r\n\r\n    ### Your Response\r\n    Respond strictly in **JSON** format:\r\n    {\r\n      \"aiDiagnosis\": \"Refined, detailed diagnosis in clinical terms (do not copy doctor's text verbatim)\",\r\n      \"aiAdvice\": \"Expanded advice with lifestyle or follow-up recommendations (friendly and medically sound)\"\r\n    }\r\n\r\n    Avoid repeating the doctor's text; instead, validate and *enhance* it.\r\n    Keep responses short (2–3 sentences per field).         ", new DateTime(2025, 11, 18, 23, 7, 9, 115, DateTimeKind.Utc).AddTicks(6260), null, "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.", false, "Default Receipt Review Prompt", 4, null },
                    { "f33c0739-d93b-4124-8846-9a1f69e74c9b", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 19, 1, 7, 9, 115, DateTimeKind.Local).AddTicks(6244), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserHealthLogsToDoctors_DoctorId",
                table: "UserHealthLogsToDoctors",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_UserHealthLogsToDoctors_UserHealthLogId",
                table: "UserHealthLogsToDoctors",
                column: "UserHealthLogId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserHealthLogsToDoctors");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "8933ab06-9aaa-4232-b7e0-7a449650096e");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "8bd4cdb5-09e5-4794-93b3-44ed63fc6527");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "b415e309-7109-4561-8147-0641a7151efb");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "f33c0739-d93b-4124-8846-9a1f69e74c9b");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0c345ac8-1d3b-4344-b6ae-917a9146905e", "AQAAAAIAAYagAAAAEJRe1TJ7qO4qWwPAk0uiZE4UT5zFFHvQOjV3xR9v1x/dkXup6v6aAHrdv2yuuOT9nQ==", "e5a73a3e-e61f-4b53-b676-b74642190703" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f9142bcb-3f54-49c4-8108-691efe3855ff", "AQAAAAIAAYagAAAAEGFPVipq4BzzW5pomczMvvYHEsPZex9ttucfACegcnE9GwKD807AbUlond6zvb+a1A==", "f53c139f-40bc-42cf-b5d8-37c920dbbae9" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a41f9b84-267d-4e7a-b7a5-b648a42b454b", "AQAAAAIAAYagAAAAEMl2g0NHJZyzLJqNG8X3tK4ARkHD6t9k8aKwjXr0dAyvbb456rZtHWzOecCqJW8JXw==", "37c47f43-8617-4e51-aca1-473ae7cbcbd1" });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-1",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 16, 23, 34, 48, 563, DateTimeKind.Local).AddTicks(2600), new DateTime(2025, 11, 23, 23, 34, 48, 563, DateTimeKind.Local).AddTicks(2568), new DateTime(2025, 11, 16, 23, 34, 48, 563, DateTimeKind.Local).AddTicks(2567) });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-2",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 16, 23, 34, 48, 563, DateTimeKind.Local).AddTicks(2610), new DateTime(2025, 11, 26, 23, 34, 48, 563, DateTimeKind.Local).AddTicks(2609), new DateTime(2025, 11, 16, 23, 34, 48, 563, DateTimeKind.Local).AddTicks(2608) });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6499));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6451));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6454));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6457));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6461));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6465));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6468));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6471));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 16, 21, 34, 47, 769, DateTimeKind.Utc).AddTicks(6473));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "0559967f-9094-4d7b-8a41-d5b1fb0d4d67", "You are a professional AI health assistant working in a Smart Clinical System.\r\n\r\nYour task:\r\nAnalyze the user's medical receipts AND personal health logs for the given time period.\r\nConsider:\r\n- Reported symptoms\r\n- Pain levels\r\n- Mood logs\r\n- Temperatures\r\n- Notes written by the user\r\n- Side effects\r\n- Medications prescribed in the receipts\r\n- Consistency or worsening of symptoms\r\n\r\nYour goal:\r\nProduce a clear, friendly, medically helpful health summary (4–6 sentences).\r\nDo NOT diagnose new illnesses. Base everything STRICTLY on the provided data.\r\n\r\nRespond STRICTLY in JSON using the following structure:\r\n\r\n{\r\n    \"timePeriodDays\": number,\r\n    \"summary\": \"string (4–6 sentences summarizing health trends)\",\r\n    \"keyConcerns\": [\"string\", \"string\"],\r\n    \"positiveTrends\": [\"string\", \"string\"],\r\n    \"recommendedActions\": [\"string\", \"string\"]\r\n}\r\n\r\nRules:\r\n- No markdown\r\n- No extra text outside JSON\r\n- No invented data\r\n- Summaries must directly refer to the provided logs and receipts", new DateTime(2025, 11, 16, 23, 34, 47, 923, DateTimeKind.Local).AddTicks(9655), null, null, false, "Health Summary Check Prompt", 2, null },
                    { "647d7aa8-a4b1-433c-81a3-49380c29d601", "You are a professional medical AI system.\r\n\r\nCompare the two medicines based on how relevant they are for the given diagnosis.\r\n\r\nFor each medicine:\r\n- Analyze indications relevance\r\n- Match diagnosis keywords\r\n- Score relevance from 0 to 10\r\n- Provide matched keywords\r\n\r\nRespond STRICTLY in JSON using this structure:\r\n\r\n{\r\n    \"diagnosis\": \"string\",\r\n    \"a\": {\r\n        \"medicineId\": \"id1\",\r\n        \"matchScore\": 0,\r\n        \"matchingKeywords\": [\"word1\",\"word2\"]\r\n    },\r\n    \"b\": {\r\n        \"medicineId\": \"id2\",\r\n        \"matchScore\": 0,\r\n        \"matchingKeywords\": [\"word1\"]\r\n    },\r\n    \"betterMedicineId\": \"id1\",\r\n    \"explanation\": \"string\"\r\n}", new DateTime(2025, 11, 16, 23, 34, 47, 923, DateTimeKind.Local).AddTicks(9653), null, null, false, "Medicine Comparison Prompt", 5, null },
                    { "d9334538-0769-4053-8914-28cf40d5fec3", "    You are a senior clinical AI assistant reviewing a doctor's medical receipt.\r\n\r\n    ### Your Goals\r\n    1. Evaluate the doctor's diagnosis for completeness and clarity.\r\n    2. Refine or expand it into a more detailed but concise medical explanation.\r\n    3. Ensure the prescribed medicines are appropriate for the diagnosis.\r\n    4. Write patient-friendly advice that complements the doctor's notes — not just repeats them.\r\n\r\n    ### Your Response\r\n    Respond strictly in **JSON** format:\r\n    {\r\n      \"aiDiagnosis\": \"Refined, detailed diagnosis in clinical terms (do not copy doctor's text verbatim)\",\r\n      \"aiAdvice\": \"Expanded advice with lifestyle or follow-up recommendations (friendly and medically sound)\"\r\n    }\r\n\r\n    Avoid repeating the doctor's text; instead, validate and *enhance* it.\r\n    Keep responses short (2–3 sentences per field).         ", new DateTime(2025, 11, 16, 21, 34, 47, 923, DateTimeKind.Utc).AddTicks(9652), null, "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.", false, "Default Receipt Review Prompt", 4, null },
                    { "e6a43ad3-ca70-42bf-afbf-58529cfa309f", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 16, 23, 34, 47, 923, DateTimeKind.Local).AddTicks(9639), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null }
                });
        }
    }
}
