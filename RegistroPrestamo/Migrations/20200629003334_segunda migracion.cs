using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroPrestamo.Migrations
{
    public partial class segundamigracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Mora",
                columns: table => new
                {
                    MoraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    fecha = table.Column<DateTime>(nullable: false),
                    Total = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mora", x => x.MoraId);
                });

            migrationBuilder.CreateTable(
                name: "MoraDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MoraId = table.Column<int>(nullable: false),
                    PrestamoId = table.Column<int>(nullable: false),
                    Valor = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoraDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoraDetalle_Mora_MoraId",
                        column: x => x.MoraId,
                        principalTable: "Mora",
                        principalColumn: "MoraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoraDetalle_MoraId",
                table: "MoraDetalle",
                column: "MoraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoraDetalle");

            migrationBuilder.DropTable(
                name: "Mora");
        }
    }
}
