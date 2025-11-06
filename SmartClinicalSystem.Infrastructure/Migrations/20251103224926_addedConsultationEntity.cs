using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addedConsultationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "c9b42596-ebb7-4460-a4fd-18feba292546");

            migrationBuilder.CreateTable(
                name: "AiConsultations",
                columns: table => new
                {
                    AiConsultationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    AiResponseJson = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                values: new object[] { "56df9be0-1439-4376-b178-b8e52f671f5a", "AQAAAAIAAYagAAAAEIF50GLEHbdI2irSIqrqK5GRSc5T8sdBBEF1JdB8wHMoh0MpgtZnEmQOCzQrFjTAzQ==", "1061480c-1c1d-4586-8d39-d64c6603e9bf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b108051a-78f2-425b-8359-cde33d3d7e53", "AQAAAAIAAYagAAAAENGr48bSy83jmbDihTbSZeVPb1Acvk11pxv5wkON8XHBFFsIsZfWpswyf77IMdmKEg==", "459e4851-794d-46bb-ad10-5db3c18a5508" });

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AiConsultations");

            migrationBuilder.DeleteData(
                table: "PromptTemplates",
                keyColumn: "PromptTemplateId",
                keyValue: "247ebaa3-ad3d-4083-b705-81aae9746780");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27d78708-8671-4b05-bd5e-17aa91392224",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f759cf48-0439-447f-a708-76d299203917", "AQAAAAIAAYagAAAAELTxtT6aUTh0qfD+giXsR1pdad9cQ3xEAr7qDcaZLSeMfwBPc9M+33a2mU6gdk0Rrw==", "d5a75b1a-229a-4de1-9153-2d093ee510e6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f8472c89-f48d-49cc-8517-a81153d47cdd",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb28312b-6cf2-4f78-a3b5-213eedca60d4", "AQAAAAIAAYagAAAAEICOOOMUaoaDbsye5I7dtoN4IARfLfcZptUMMIOl0lgpTA8WMDMWTUayFhzmX8TMjQ==", "95822bb2-6318-4ef2-b83c-776a0c8eaa62" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4969));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4918));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4923));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4927));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4930));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4950));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4956));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4960));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 30, 23, 30, 36, 209, DateTimeKind.Utc).AddTicks(4964));

            migrationBuilder.InsertData(
                table: "PromptTemplates",
                columns: new[] { "PromptTemplateId", "Content", "CreatedAt", "DeletedOn", "Description", "IsDeleted", "Name", "Type", "UpdatedAt" },
                values: new object[] { "c9b42596-ebb7-4460-a4fd-18feba292546", "    You are a responsible and helpful AI medical assistant for a Smart Clinical System.\r\n    Your role:\r\n    - Analyze the user's symptoms.\r\n    - Recommend the most appropriate medicines ONLY from the provided list (with their IDs).\r\n    - Provide a short and friendly advice section for the patient.\r\n\r\n    Follow these rules:\r\n    1. Never invent new medicines or diseases.\r\n    2. Choose only from the provided list.\r\n    3. Always respond **strictly in JSON** format using this structure:\r\n\r\n    {\r\n      \"possibleConditions\": \"string — short description of likely common conditions\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"string — short patient-friendly advice\"\r\n    }\r\n\r\n    Example response:\r\n\r\n    {\r\n      \"possibleConditions\": \"Common cold or influenza\",\r\n      \"recommendedMedicineIds\": [\"9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x\", \"0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y\"],\r\n      \"advice\": \"Stay hydrated, rest, and take paracetamol for fever. Consult a doctor if symptoms persist more than 3 days.\"\r\n    }\r\n\r\n    Do not include any text, explanation, or markdown outside the JSON block.", new DateTime(2025, 10, 31, 1, 30, 36, 297, DateTimeKind.Local).AddTicks(9077), null, "Analyzes user symptoms and recommends possible conditions and medicines from the available list.", false, "Default Diagnose Prompt", 1, null });
        }
    }
}
