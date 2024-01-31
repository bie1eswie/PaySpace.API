using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PaySpace.Data.Migrations
{
    /// <inheritdoc />
    public partial class update_progressive_calculator : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProgressiveCalculatorRangeMaps",
                keyColumn: "Id",
                keyValue: new Guid("0c355928-9b7b-479c-9c61-09570402e6c9"),
                column: "Percentage",
                value: 0.34999999999999998);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ProgressiveCalculatorRangeMaps",
                keyColumn: "Id",
                keyValue: new Guid("0c355928-9b7b-479c-9c61-09570402e6c9"),
                column: "Percentage",
                value: 0.0);
        }
    }
}
