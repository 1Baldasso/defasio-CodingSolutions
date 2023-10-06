using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingSolutions.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnSaldoCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Saldo",
                table: "Clientes",
                type: "DECIMAL(10,2)",
                nullable: false,
                defaultValue: 500m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Saldo",
                table: "Clientes");
        }
    }
}
