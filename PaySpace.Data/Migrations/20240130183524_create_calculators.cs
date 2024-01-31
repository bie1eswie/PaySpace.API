using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace PaySpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class create_calculators : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CalculatorResponses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnnualIncome = table.Column<double>(type: "float", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalculatedValue = table.Column<double>(type: "float", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalculatorResponses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProgressiveCalculatorRangeMaps",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    From = table.Column<double>(type: "float", nullable: false),
                    To = table.Column<double>(type: "float", nullable: false),
                    Percentage = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressiveCalculatorRangeMaps", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "CalculatorTypeMaps",
                columns: new[] { "Id", "CalculatorType", "PostalCode" },
                values: new object[,]
                {
                    { new Guid("40bbb4cc-3fb5-4d32-b29c-b839e38828ac"), 1, "A100" },
                    { new Guid("769edf75-2bd7-4688-b4f3-f433e79e54eb"), 0, "7441" },
                    { new Guid("9662f04f-d363-4831-87ae-e159be869f9c"), 0, "1000" },
                    { new Guid("c12c5a45-950e-4911-ad18-a07bdc80acb7"), 2, "7000" }
                });

            migrationBuilder.InsertData(
                table: "ProgressiveCalculatorRangeMaps",
                columns: new[] { "Id", "From", "Percentage", "To" },
                values: new object[,]
                {
                    { new Guid("0c355928-9b7b-479c-9c61-09570402e6c9"), 372951.0, 0.0, 1.7976931348623157E+308 },
                    { new Guid("2218804c-3180-4470-85a8-512f9ec72224"), 33951.0, 0.25, 82250.0 },
                    { new Guid("46820772-0c01-4f1b-992b-9c5e4ba91242"), 171551.0, 0.33000000000000002, 372950.0 },
                    { new Guid("4a3a1172-6563-415d-adcc-c503902023d9"), 82251.0, 0.28000000000000003, 171550.0 },
                    { new Guid("6cd0473e-3c9e-49e1-a010-82f634b5692c"), 8351.0, 0.14999999999999999, 33950.0 },
                    { new Guid("e3c965f0-e8f3-45fc-ac17-ef8af23f5634"), 0.0, 0.10000000000000001, 8350.0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalculatorResponses");

            migrationBuilder.DropTable(
                name: "ProgressiveCalculatorRangeMaps");

            migrationBuilder.DeleteData(
                table: "CalculatorTypeMaps",
                keyColumn: "Id",
                keyValue: new Guid("40bbb4cc-3fb5-4d32-b29c-b839e38828ac"));

            migrationBuilder.DeleteData(
                table: "CalculatorTypeMaps",
                keyColumn: "Id",
                keyValue: new Guid("769edf75-2bd7-4688-b4f3-f433e79e54eb"));

            migrationBuilder.DeleteData(
                table: "CalculatorTypeMaps",
                keyColumn: "Id",
                keyValue: new Guid("9662f04f-d363-4831-87ae-e159be869f9c"));

            migrationBuilder.DeleteData(
                table: "CalculatorTypeMaps",
                keyColumn: "Id",
                keyValue: new Guid("c12c5a45-950e-4911-ad18-a07bdc80acb7"));
        }
    }
}
