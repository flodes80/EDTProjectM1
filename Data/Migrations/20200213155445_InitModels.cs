using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDTProjectM1.Data.Migrations
{
    public partial class InitModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Batiments",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomBatiment = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Batiments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TypesSeance",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypesSeance", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "UE",
                columns: table => new
                {
                    Numero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Intitule = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UE", x => x.Numero);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSalle = table.Column<string>(nullable: false),
                    BatimentID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Salles_Batiments_BatimentID",
                        column: x => x.BatimentID,
                        principalTable: "Batiments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Groupes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomGroupe = table.Column<string>(nullable: false),
                    UENumero = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Groupes_UE_UENumero",
                        column: x => x.UENumero,
                        principalTable: "UE",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeSeanceID = table.Column<int>(nullable: false),
                    GroupeID = table.Column<int>(nullable: true),
                    UENumero = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    Duree = table.Column<int>(nullable: false),
                    SalleID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seances_Groupes_GroupeID",
                        column: x => x.GroupeID,
                        principalTable: "Groupes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seances_Salles_SalleID",
                        column: x => x.SalleID,
                        principalTable: "Salles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Seances_TypesSeance_TypeSeanceID",
                        column: x => x.TypeSeanceID,
                        principalTable: "TypesSeance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_UE_UENumero",
                        column: x => x.UENumero,
                        principalTable: "UE",
                        principalColumn: "Numero",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_UENumero",
                table: "Groupes",
                column: "UENumero");

            migrationBuilder.CreateIndex(
                name: "IX_Salles_BatimentID",
                table: "Salles",
                column: "BatimentID");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_GroupeID",
                table: "Seances",
                column: "GroupeID");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_SalleID",
                table: "Seances",
                column: "SalleID");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_TypeSeanceID",
                table: "Seances",
                column: "TypeSeanceID");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_UENumero",
                table: "Seances",
                column: "UENumero");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seances");

            migrationBuilder.DropTable(
                name: "Groupes");

            migrationBuilder.DropTable(
                name: "Salles");

            migrationBuilder.DropTable(
                name: "TypesSeance");

            migrationBuilder.DropTable(
                name: "UE");

            migrationBuilder.DropTable(
                name: "Batiments");
        }
    }
}
