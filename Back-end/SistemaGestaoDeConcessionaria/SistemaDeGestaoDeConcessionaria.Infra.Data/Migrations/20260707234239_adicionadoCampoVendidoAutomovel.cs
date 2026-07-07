using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionadoCampoVendidoAutomovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Vendido",
                table: "Automovel",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Vendido",
                table: "Automovel");
        }
    }
}
