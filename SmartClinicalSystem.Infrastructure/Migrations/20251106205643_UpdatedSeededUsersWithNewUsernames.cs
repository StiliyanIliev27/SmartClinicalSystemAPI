using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSeededUsersWithNewUsernames : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "247ebaa3-ad3d-4083-b705-81aae9746780");

            migrationBuilder.AddColumn<string>(
                name: "Symptoms",
                table: "AiConsultations",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "25acf9cd-5348-473b-8d17-96ae89a3ef5d", "ADMIN_ADMINOV", "AQAAAAIAAYagAAAAEN7p626Lq9jQE7OdeS0Yazx3/xQwm0Sv9YmjreAwOz/X3xINLiU6AIfo2ncZDEnijw==", "a476f9b9-c5e8-47b3-93e7-bf3645968d2c", "admin_adminov" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "ed1454d7-5d11-490f-bfdb-147aa0496be3", "USER_USEROV", "AQAAAAIAAYagAAAAEEe7KbVJi6o5CMxHY9bDhaP6QAPA4ppAqQ3U0qn3r6/Xz1puE52b+3XRgxOqCKdKHQ==", "2675be0b-82d6-44eb-8038-cbd2230c26bd", "user_userov" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(9140));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(8845));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(8862));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(8954));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(8967));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(9085));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(9109));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(9118));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 6, 20, 56, 42, 87, DateTimeKind.Utc).AddTicks(9128));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[] { "111ad5d8-b235-47c3-a221-08c7a6638f9c", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 6, 22, 56, 42, 215, DateTimeKind.Local).AddTicks(8634), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "111ad5d8-b235-47c3-a221-08c7a6638f9c");

            migrationBuilder.DropColumn(
                name: "Symptoms",
                table: "AiConsultations");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "56df9be0-1439-4376-b178-b8e52f671f5a", null, "AQAAAAIAAYagAAAAEIF50GLEHbdI2irSIqrqK5GRSc5T8sdBBEF1JdB8wHMoh0MpgtZnEmQOCzQrFjTAzQ==", "1061480c-1c1d-4586-8d39-d64c6603e9bf", null });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "NormalizedUserName", "PasswordHash", "SecurityStamp", "UserName" },
                values: new object[] { "b108051a-78f2-425b-8359-cde33d3d7e53", null, "AQAAAAIAAYagAAAAENGr48bSy83jmbDihTbSZeVPb1Acvk11pxv5wkON8XHBFFsIsZfWpswyf77IMdmKEg==", "459e4851-794d-46bb-ad10-5db3c18a5508", null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5381));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5393));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5454));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5469));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5475));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5544));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5548));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5552));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 11, 3, 22, 49, 24, 736, DateTimeKind.Utc).AddTicks(5556));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[] { "247ebaa3-ad3d-4083-b705-81aae9746780", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 11, 4, 0, 49, 24, 839, DateTimeKind.Local).AddTicks(2043), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null });
        }
    }
}
