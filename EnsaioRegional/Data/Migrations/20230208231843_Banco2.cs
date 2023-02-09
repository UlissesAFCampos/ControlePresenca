using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnsaioRegional.Data.Migrations
{
    public partial class Banco2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataEnsaio",
                columns: table => new
                {
                    IdData = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DescricaoEnsaio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CidadeRealizacao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataEnsaio", x => x.IdData);
                });

            migrationBuilder.CreateTable(
                name: "Igreja",
                columns: table => new
                {
                    IdIgreja = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroRelatorio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nomeigreja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Igreja", x => x.IdIgreja);
                });

            migrationBuilder.CreateTable(
                name: "TipoInstrumento",
                columns: table => new
                {
                    IdTipoInstrumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoInstrumento", x => x.IdTipoInstrumento);
                });

            migrationBuilder.CreateTable(
                name: "Instrumento",
                columns: table => new
                {
                    IdInstrumento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeInstrumento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoInstrumento = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Instrumento", x => x.IdInstrumento);
                    table.ForeignKey(
                        name: "FK_Instrumento_TipoInstrumento_IdTipoInstrumento",
                        column: x => x.IdTipoInstrumento,
                        principalTable: "TipoInstrumento",
                        principalColumn: "IdTipoInstrumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Musico",
                columns: table => new
                {
                    IdMusico = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeMusico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdTipoMusico = table.Column<int>(type: "int", nullable: false),
                    IdTipoFormacao = table.Column<bool>(type: "bit", nullable: false),
                    IdInstrumento = table.Column<int>(type: "int", nullable: false),
                    IdIgreja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Musico", x => x.IdMusico);
                    table.ForeignKey(
                        name: "FK_Musico_Igreja_IdIgreja",
                        column: x => x.IdIgreja,
                        principalTable: "Igreja",
                        principalColumn: "IdIgreja",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Musico_Instrumento_IdInstrumento",
                        column: x => x.IdInstrumento,
                        principalTable: "Instrumento",
                        principalColumn: "IdInstrumento",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Presenca",
                columns: table => new
                {
                    IdPresenca = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdData = table.Column<int>(type: "int", nullable: false),
                    IdMusico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Presenca", x => x.IdPresenca);
                    table.ForeignKey(
                        name: "FK_Presenca_DataEnsaio_IdData",
                        column: x => x.IdData,
                        principalTable: "DataEnsaio",
                        principalColumn: "IdData",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Presenca_Musico_IdMusico",
                        column: x => x.IdMusico,
                        principalTable: "Musico",
                        principalColumn: "IdMusico",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Instrumento_IdTipoInstrumento",
                table: "Instrumento",
                column: "IdTipoInstrumento");

            migrationBuilder.CreateIndex(
                name: "IX_Musico_IdIgreja",
                table: "Musico",
                column: "IdIgreja");

            migrationBuilder.CreateIndex(
                name: "IX_Musico_IdInstrumento",
                table: "Musico",
                column: "IdInstrumento");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_IdData",
                table: "Presenca",
                column: "IdData");

            migrationBuilder.CreateIndex(
                name: "IX_Presenca_IdMusico",
                table: "Presenca",
                column: "IdMusico");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Presenca");

            migrationBuilder.DropTable(
                name: "DataEnsaio");

            migrationBuilder.DropTable(
                name: "Musico");

            migrationBuilder.DropTable(
                name: "Igreja");

            migrationBuilder.DropTable(
                name: "Instrumento");

            migrationBuilder.DropTable(
                name: "TipoInstrumento");
        }
    }
}
