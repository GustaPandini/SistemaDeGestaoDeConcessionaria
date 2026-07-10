using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class CampoCPFEmClienteIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cliente_CPF",
                table: "Cliente",
                column: "CPF",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cliente_CPF",
                table: "Cliente");
        }
    }
}
