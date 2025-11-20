using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotificationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "3bb136ab-2805-4fc5-9e0c-24e4bcb3a168");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "3ff83a70-8ac2-419e-995d-e7b981b4fc60");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "4a34b1da-2e32-4aae-9d2d-5c31f575f917");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "bd74840e-a944-488b-add0-36908966102b");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RecipientId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_AspNetUsers_RecipientId",
                        column: x => x.RecipientId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be9616a1-9260-421c-a70e-46fcdfc649fb", "AQAAAAIAAYagAAAAECIll/yK6nEIsDbNmBDISP/vuKYS+xcjUC6iCYolT8YZkRQoBn/34Uibm7+y5RvehQ==", "2d0a780e-e65e-453c-ac9f-cdf57c83b6b6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6738c386-4029-40ea-b022-63b22eea4411", "AQAAAAIAAYagAAAAEL4zNVM/I9ASDswz/NtjxucHCyNtJ1crJHPIzenYoEpwtOxKQM0ZGp+RHtWVAVCJPg==", "5da1cf14-a3ef-4d72-b45c-d584c9725190" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e474b0fd-ae2b-48e9-afa2-3ffa9806b576", "AQAAAAIAAYagAAAAEJvRPO6TVi7sN3vTUtLQie1u/epvRcxT3C84Q1L7bgIIDtwLB/9wAQf/1lFrqiGvIw==", "8184b767-5192-4a4c-b52b-68d8bce2af46" });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-1",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 20, 14, 4, 26, 62, DateTimeKind.Local).AddTicks(612), new DateTime(2025, 11, 27, 14, 4, 26, 62, DateTimeKind.Local).AddTicks(589), new DateTime(2025, 11, 20, 14, 4, 26, 62, DateTimeKind.Local).AddTicks(587) });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-2",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 20, 14, 4, 26, 62, DateTimeKind.Local).AddTicks(625), new DateTime(2025, 11, 30, 14, 4, 26, 62, DateTimeKind.Local).AddTicks(623), new DateTime(2025, 11, 20, 14, 4, 26, 62, DateTimeKind.Local).AddTicks(621) });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9564));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9493));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9527));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9532));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9536));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9540));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9545));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9549));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9553));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 20, 12, 4, 25, 165, DateTimeKind.Utc).AddTicks(9557));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "2d9d2679-1873-42e2-988c-823834b2dc41", "You are a professional medical AI system.\r\n\r\nCompare the two medicines based on how relevant they are for the given diagnosis.\r\n\r\nFor each medicine:\r\n- Analyze indications relevance\r\n- Match diagnosis keywords\r\n- Score relevance from 0 to 10\r\n- Provide matched keywords\r\n\r\nRespond STRICTLY in JSON using this structure:\r\n\r\n{\r\n    \"diagnosis\": \"string\",\r\n    \"a\": {\r\n        \"medicineId\": \"id1\",\r\n        \"matchScore\": 0,\r\n        \"matchingKeywords\": [\"word1\",\"word2\"]\r\n    },\r\n    \"b\": {\r\n        \"medicineId\": \"id2\",\r\n        \"matchScore\": 0,\r\n        \"matchingKeywords\": [\"word1\"]\r\n    },\r\n    \"betterMedicineId\": \"id1\",\r\n    \"explanation\": \"string\"\r\n}", new DateTime(2025, 11, 20, 14, 4, 25, 343, DateTimeKind.Local).AddTicks(4229), null, null, false, "Medicine Comparison Prompt", 5, null },
                    { "95501b59-7a7c-446d-abf0-03124d178e3b", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 20, 14, 4, 25, 343, DateTimeKind.Local).AddTicks(4219), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null },
                    { "d4bcff9a-e765-4750-b7c6-87e0b876c7de", "You are a professional AI health assistant working in a Smart Clinical System.\r\n\r\nYour task:\r\nAnalyze the user's medical receipts AND personal health logs for the given time period.\r\nConsider:\r\n- Reported symptoms\r\n- Pain levels\r\n- Mood logs\r\n- Temperatures\r\n- Notes written by the user\r\n- Side effects\r\n- Medications prescribed in the receipts\r\n- Consistency or worsening of symptoms\r\n\r\nYour goal:\r\nProduce a clear, friendly, medically helpful health summary (4–6 sentences).\r\nDo NOT diagnose new illnesses. Base everything STRICTLY on the provided data.\r\n\r\nRespond STRICTLY in JSON using the following structure:\r\n\r\n{\r\n    \"timePeriodDays\": number,\r\n    \"summary\": \"string (4–6 sentences summarizing health trends)\",\r\n    \"keyConcerns\": [\"string\", \"string\"],\r\n    \"positiveTrends\": [\"string\", \"string\"],\r\n    \"recommendedActions\": [\"string\", \"string\"]\r\n}\r\n\r\nRules:\r\n- No markdown\r\n- No extra text outside JSON\r\n- No invented data\r\n- Summaries must directly refer to the provided logs and receipts", new DateTime(2025, 11, 20, 14, 4, 25, 343, DateTimeKind.Local).AddTicks(4231), null, null, false, "Health Summary Check Prompt", 2, null },
                    { "ed06beca-a274-4e9e-93d0-b225e2a9cb46", "    You are a senior clinical AI assistant reviewing a doctor's medical receipt.\r\n\r\n    ### Your Goals\r\n    1. Evaluate the doctor's diagnosis for completeness and clarity.\r\n    2. Refine or expand it into a more detailed but concise medical explanation.\r\n    3. Ensure the prescribed medicines are appropriate for the diagnosis.\r\n    4. Write patient-friendly advice that complements the doctor's notes — not just repeats them.\r\n\r\n    ### Your Response\r\n    Respond strictly in **JSON** format:\r\n    {\r\n      \"aiDiagnosis\": \"Refined, detailed diagnosis in clinical terms (do not copy doctor's text verbatim)\",\r\n      \"aiAdvice\": \"Expanded advice with lifestyle or follow-up recommendations (friendly and medically sound)\"\r\n    }\r\n\r\n    Avoid repeating the doctor's text; instead, validate and *enhance* it.\r\n    Keep responses short (2–3 sentences per field).         ", new DateTime(2025, 11, 20, 12, 4, 25, 343, DateTimeKind.Utc).AddTicks(4228), null, "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.", false, "Default Receipt Review Prompt", 4, null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_RecipientId",
                table: "Notifications",
                column: "RecipientId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "2d9d2679-1873-42e2-988c-823834b2dc41");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "95501b59-7a7c-446d-abf0-03124d178e3b");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "d4bcff9a-e765-4750-b7c6-87e0b876c7de");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "ed06beca-a274-4e9e-93d0-b225e2a9cb46");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e39c6dfd-8a36-47c0-9a3f-1a1cea011904", "AQAAAAIAAYagAAAAEBBqTchSdJS0GLxlRRE1gBiXYea77YsmTw7CqKA6gA1sYacIxXMDeRW+DgTbIGA80w==", "893e9e25-6bcb-43e1-8e80-2c4468bca424" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "bc0c48b7-5cb9-4d8f-802b-68bea5bf4780",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c3c70007-d2f9-44b2-a460-5f933abfbcd4", "AQAAAAIAAYagAAAAEMTBTcycbMAztJRQAat8aa6pFb8I/NDKS8vlnKhq4ofX+CgyQDf7TseV18cL6zO7JQ==", "dd63a9ab-6a81-4857-b324-228d3503be27" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e5cb72e2-bafc-430e-9600-37ba0c1387a2", "AQAAAAIAAYagAAAAEC0TrhZ3SHxpj9Oy9/mRnqdd+aVqJonA6eYb9qmDbWsLcJnJBV+V45LsqeQk4fpZPQ==", "fa98e777-4acd-4b4d-9a40-360c33b3b4da" });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-1",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 19, 17, 59, 32, 242, DateTimeKind.Local).AddTicks(1177), new DateTime(2025, 11, 26, 17, 59, 32, 242, DateTimeKind.Local).AddTicks(1158), new DateTime(2025, 11, 19, 17, 59, 32, 242, DateTimeKind.Local).AddTicks(1157) });

            migrationBuilder.UpdateData(
                table: "MedicalReceipts",
                keyColumn: "MedicalReceiptId",
                keyValue: "rec-2",
                columns: new[] { "CreatedAt", "ExpirationDate", "IssueDate" },
                values: new object[] { new DateTime(2025, 11, 19, 17, 59, 32, 242, DateTimeKind.Local).AddTicks(1185), new DateTime(2025, 11, 29, 17, 59, 32, 242, DateTimeKind.Local).AddTicks(1184), new DateTime(2025, 11, 19, 17, 59, 32, 242, DateTimeKind.Local).AddTicks(1183) });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1361));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1376));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1380));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1442));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1449));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1452));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 19, 15, 59, 31, 557, DateTimeKind.Utc).AddTicks(1496));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[,]
                {
                    { "3bb136ab-2805-4fc5-9e0c-24e4bcb3a168", "You are a professional AI health assistant working in a Smart Clinical System.\r\n\r\nYour task:\r\nAnalyze the user's medical receipts AND personal health logs for the given time period.\r\nConsider:\r\n- Reported symptoms\r\n- Pain levels\r\n- Mood logs\r\n- Temperatures\r\n- Notes written by the user\r\n- Side effects\r\n- Medications prescribed in the receipts\r\n- Consistency or worsening of symptoms\r\n\r\nYour goal:\r\nProduce a clear, friendly, medically helpful health summary (4–6 sentences).\r\nDo NOT diagnose new illnesses. Base everything STRICTLY on the provided data.\r\n\r\nRespond STRICTLY in JSON using the following structure:\r\n\r\n{\r\n    \"timePeriodDays\": number,\r\n    \"summary\": \"string (4–6 sentences summarizing health trends)\",\r\n    \"keyConcerns\": [\"string\", \"string\"],\r\n    \"positiveTrends\": [\"string\", \"string\"],\r\n    \"recommendedActions\": [\"string\", \"string\"]\r\n}\r\n\r\nRules:\r\n- No markdown\r\n- No extra text outside JSON\r\n- No invented data\r\n- Summaries must directly refer to the provided logs and receipts", new DateTime(2025, 11, 19, 17, 59, 31, 697, DateTimeKind.Local).AddTicks(9956), null, null, false, "Health Summary Check Prompt", 2, null },
                    { "3ff83a70-8ac2-419e-995d-e7b981b4fc60", "You are a professional medical AI system.\r\n\r\nCompare the two medicines based on how relevant they are for the given diagnosis.\r\n\r\nFor each medicine:\r\n- Analyze indications relevance\r\n- Match diagnosis keywords\r\n- Score relevance from 0 to 10\r\n- Provide matched keywords\r\n\r\nRespond STRICTLY in JSON using this structure:\r\n\r\n{\r\n    \"diagnosis\": \"string\",\r\n    \"a\": {\r\n        \"medicineId\": \"id1\",\r\n        \"matchScore\": 0,\r\n        \"matchingKeywords\": [\"word1\",\"word2\"]\r\n    },\r\n    \"b\": {\r\n        \"medicineId\": \"id2\",\r\n        \"matchScore\": 0,\r\n        \"matchingKeywords\": [\"word1\"]\r\n    },\r\n    \"betterMedicineId\": \"id1\",\r\n    \"explanation\": \"string\"\r\n}", new DateTime(2025, 11, 19, 17, 59, 31, 697, DateTimeKind.Local).AddTicks(9953), null, null, false, "Medicine Comparison Prompt", 5, null },
                    { "4a34b1da-2e32-4aae-9d2d-5c31f575f917", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 19, 17, 59, 31, 697, DateTimeKind.Local).AddTicks(9938), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null },
                    { "bd74840e-a944-488b-add0-36908966102b", "    You are a senior clinical AI assistant reviewing a doctor's medical receipt.\r\n\r\n    ### Your Goals\r\n    1. Evaluate the doctor's diagnosis for completeness and clarity.\r\n    2. Refine or expand it into a more detailed but concise medical explanation.\r\n    3. Ensure the prescribed medicines are appropriate for the diagnosis.\r\n    4. Write patient-friendly advice that complements the doctor's notes — not just repeats them.\r\n\r\n    ### Your Response\r\n    Respond strictly in **JSON** format:\r\n    {\r\n      \"aiDiagnosis\": \"Refined, detailed diagnosis in clinical terms (do not copy doctor's text verbatim)\",\r\n      \"aiAdvice\": \"Expanded advice with lifestyle or follow-up recommendations (friendly and medically sound)\"\r\n    }\r\n\r\n    Avoid repeating the doctor's text; instead, validate and *enhance* it.\r\n    Keep responses short (2–3 sentences per field).         ", new DateTime(2025, 11, 19, 15, 59, 31, 697, DateTimeKind.Utc).AddTicks(9952), null, "Validates a doctor's medical receipt and generates AI-based diagnosis & advice.", false, "Default Receipt Review Prompt", 4, null }
                });
        }
    }
}
