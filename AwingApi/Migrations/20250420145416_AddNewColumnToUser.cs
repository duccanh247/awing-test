using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AwingApi.Migrations
{
    /// <inheritdoc />
    public partial class AddNewColumnToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Resutl",
                table: "CalculationLog",
                newName: "Var_P");

            migrationBuilder.RenameColumn(
                name: "P",
                table: "CalculationLog",
                newName: "Var_N");

            migrationBuilder.RenameColumn(
                name: "N",
                table: "CalculationLog",
                newName: "Var_M");

            migrationBuilder.RenameColumn(
                name: "M",
                table: "CalculationLog",
                newName: "Result");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Var_P",
                table: "CalculationLog",
                newName: "Resutl");

            migrationBuilder.RenameColumn(
                name: "Var_N",
                table: "CalculationLog",
                newName: "P");

            migrationBuilder.RenameColumn(
                name: "Var_M",
                table: "CalculationLog",
                newName: "N");

            migrationBuilder.RenameColumn(
                name: "Result",
                table: "CalculationLog",
                newName: "M");
        }
    }
}
