using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cadastro_fornecedores.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    supplierFantasyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    supplierEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cnpj = table.Column<long>(type: "bigint", nullable: false),
                    supplierPhone = table.Column<long>(type: "bigint", nullable: false),
                    supplierAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    personToContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phoneNumberPersonToContact = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
