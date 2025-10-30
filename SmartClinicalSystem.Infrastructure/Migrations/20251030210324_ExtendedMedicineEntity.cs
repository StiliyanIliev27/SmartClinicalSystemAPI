using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartClinicalSystem.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedMedicineEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AiSummary",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Contraindications",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Indications",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastAiUpdated",
                table: "Medicines",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Precautions",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SideEffects",
                table: "Medicines",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c6e8e4c6-4eff-43ba-b87a-a79a07bd0b67", "AQAAAAIAAYagAAAAEK83+SyB7m/e8ztfn1PX038fkQCSPb2hcfh7Ou3LEBJwoXmVx1EfhTyeE9JXyQMqbw==", "d2c2b274-6d6a-41c5-88f6-319388531dcd" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5131), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5096), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5101), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5105), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5109), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5113), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5116), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5119), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5122), null, null, null, null, null });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                columns: new[] { "AiSummary", "Contraindications", "CreatedAt", "Description", "Indications", "LastAiUpdated", "Precautions", "SideEffects" },
                values: new object[] { null, null, new DateTime(2025, 10, 30, 21, 3, 23, 465, DateTimeKind.Utc).AddTicks(5128), null, null, null, null, null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AiSummary",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Contraindications",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Indications",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "LastAiUpdated",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "Precautions",
                table: "Medicines");

            migrationBuilder.DropColumn(
                name: "SideEffects",
                table: "Medicines");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "84ada157-7669-4600-b586-5e0ff1b56498", "AQAAAAIAAYagAAAAEJ2pzrXUAbNS/N6Lv8w1HQjC9pgRMgEOZj54mWqDz9BYBuOd88Ui4cNcyCPH9XMVQg==", "0c74b65f-18bf-4c09-9b7f-0cfed1a2661f" });

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "0j1k2l3m-4n5o-6p7q-8r9s-0t1u2v3w4x5y",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9245));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "1a2b3c4d-5e6f-7g8h-9i0j-1k2l3m4n5o6p",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9203));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "2b3c4d5e-6f7g-8h9i-0j1k-2l3m4n5o6p7q",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "3c4d5e6f-7g8h-9i0j-1k2l-3m4n5o6p7q8r",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9220));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "4d5e6f7g-8h9i-0j1k-2l3m-4n5o6p7q8r9s",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9223));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "5e6f7g8h-9i0j-1k2l-3m4n-5o6p7q8r9s0t",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9227));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "6f7g8h9i-0j1k-2l3m-4n5o-6p7q8r9s0t1u",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9230));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "7g8h9i0j-1k2l-3m4n-5o6p-7q8r9s0t1u2v",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9233));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "8h9i0j1k-2l3m-4n5o-6p7q-8r9s0t1u2v3w",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9236));

            migrationBuilder.UpdateData(
                table: "Medicines",
                keyColumn: "MedicineId",
                keyValue: "9i0j1k2l-3m4n-5o6p-7q8r-9s0t1u2v3w4x",
                column: "CreatedAt",
                value: new DateTime(2025, 10, 29, 22, 30, 57, 82, DateTimeKind.Utc).AddTicks(9240));
        }
    }
}
