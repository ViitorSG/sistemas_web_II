using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro_fornecedores.Migrations
{
    /// <inheritdoc />
    public partial class insertAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "supplierAddress",
                table: "Suppliers",
                newName: "supplierStreet");

            migrationBuilder.AddColumn<string>(
                name: "supplierAddressComplement",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "supplierCep",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "supplierCity",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "supplierHouseNumber",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "supplierNeighborhood",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "supplierState",
                table: "Suppliers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "supplierAddressComplement",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "supplierCep",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "supplierCity",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "supplierHouseNumber",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "supplierNeighborhood",
                table: "Suppliers");

            migrationBuilder.DropColumn(
                name: "supplierState",
                table: "Suppliers");

            migrationBuilder.RenameColumn(
                name: "supplierStreet",
                table: "Suppliers",
                newName: "supplierAddress");
        }
    }
}
