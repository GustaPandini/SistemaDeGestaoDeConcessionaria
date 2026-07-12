using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class adicionaCampoExcluidoEmTodasAsClasses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Venda",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Usuario",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Cliente",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Excluido",
                table: "Automovel",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Venda");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "Excluido",
                table: "Automovel");
        }
    }
}
