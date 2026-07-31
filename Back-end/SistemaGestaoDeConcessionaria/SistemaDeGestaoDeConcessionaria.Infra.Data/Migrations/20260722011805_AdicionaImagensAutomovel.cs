using Microsoft.EntityFrameworkCore.Migrations;
using MySql.EntityFrameworkCore.Metadata;

#nullable disable

namespace SistemaDeGestaoDeConcessionaria.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaImagensAutomovel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ImagensAutomovel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySQL:ValueGenerationStrategy", MySQLValueGenerationStrategy.IdentityColumn),
                    Url = table.Column<string>(type: "longtext", nullable: false),
                    PublicId = table.Column<string>(type: "longtext", nullable: false),
                    idAutomovel = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImagensAutomovel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ImagensAutomovel_Automovel_idAutomovel",
                        column: x => x.idAutomovel,
                        principalTable: "Automovel",
                        principalColumn: "idAutomovel",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ImagensAutomovel_idAutomovel",
                table: "ImagensAutomovel",
                column: "idAutomovel");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ImagensAutomovel");
        }
    }
}
