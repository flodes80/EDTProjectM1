using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EDTProjectM1.Data.Migrations
{
    public partial class ModelsInits : Migration
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
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    Intitule = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UE", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Salles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomSalle = table.Column<string>(nullable: false),
                    BatimentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Salles_Batiments_BatimentId",
                        column: x => x.BatimentId,
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
                    UEId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Groupes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Groupes_UE_UEId",
                        column: x => x.UEId,
                        principalTable: "UE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seances",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TypeSeanceId = table.Column<int>(nullable: false),
                    GroupeId = table.Column<int>(nullable: false),
                    SalleId = table.Column<int>(nullable: false),
                    UEId = table.Column<int>(nullable: false),
                    DateDebut = table.Column<DateTime>(nullable: false),
                    Duree = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seances", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Seances_Groupes_GroupeId",
                        column: x => x.GroupeId,
                        principalTable: "Groupes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_Salles_SalleId",
                        column: x => x.SalleId,
                        principalTable: "Salles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_TypesSeance_TypeSeanceId",
                        column: x => x.TypeSeanceId,
                        principalTable: "TypesSeance",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Seances_UE_UEId",
                        column: x => x.UEId,
                        principalTable: "UE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Groupes_UEId",
                table: "Groupes",
                column: "UEId");

            migrationBuilder.CreateIndex(
                name: "IX_Salles_BatimentId",
                table: "Salles",
                column: "BatimentId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_GroupeId",
                table: "Seances",
                column: "GroupeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_SalleId",
                table: "Seances",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_TypeSeanceId",
                table: "Seances",
                column: "TypeSeanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Seances_UEId",
                table: "Seances",
                column: "UEId");

            // Insertion de données de tests
            // Types Seance
            migrationBuilder.InsertData(
                table: "TypesSeance",
                columns: new[] { "ID", "Intitule" },
                values: new object[] { 1, "CM" });

            migrationBuilder.InsertData(
                table: "TypesSeance",
                columns: new[] { "ID", "Intitule" },
                values: new object[] { 2, "TD" });

            migrationBuilder.InsertData(
                table: "TypesSeance",
                columns: new[] { "ID", "Intitule" },
                values: new object[] { 3, "TP" });

            // Bâtiments
            migrationBuilder.InsertData(
                table: "Batiments",
                columns: new[] { "ID", "NomBatiment" },
                values: new object[] { 1, "Bâtiment A" });

            migrationBuilder.InsertData(
                table: "Batiments",
                columns: new[] { "ID", "NomBatiment" },
                values: new object[] { 2, "Bâtiment B" });

            migrationBuilder.InsertData(
                table: "Batiments",
                columns: new[] { "ID", "NomBatiment" },
                values: new object[] { 3, "Bâtiment C" });

            // Salles
            migrationBuilder.InsertData(
                table: "Salles",
                columns: new[] { "ID", "NomSalle", "BatimentId" },
                values: new object[] { 1, "Salle 01", 1 });

            migrationBuilder.InsertData(
                table: "Salles",
                columns: new[] { "ID", "NomSalle", "BatimentId" },
                values: new object[] { 2, "Salle 02", 1 });

            migrationBuilder.InsertData(
                table: "Salles",
                columns: new[] { "ID", "NomSalle", "BatimentId" },
                values: new object[] { 3, "Salle 10", 2 });

            migrationBuilder.InsertData(
                table: "Salles",
                columns: new[] { "ID", "NomSalle", "BatimentId" },
                values: new object[] { 4, "Salle 11", 2 });

            migrationBuilder.InsertData(
                table: "Salles",
                columns: new[] { "ID", "NomSalle", "BatimentId" },
                values: new object[] { 5, "Salle Co-Working", 3 });

            // UEs
            migrationBuilder.InsertData(
                table: "UE",
                columns: new[] { "ID", "Numero", "Intitule" },
                values: new object[] { 1, 1, "Informatique" });

            migrationBuilder.InsertData(
                table: "UE",
                columns: new[] { "ID", "Numero", "Intitule" },
                values: new object[] { 2, 2, "Mathématiques" });

            migrationBuilder.InsertData(
                table: "UE",
                columns: new[] { "ID", "Numero", "Intitule" },
                values: new object[] { 3, 3, "Marketing" });

            // Groupes
            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "ID", "NomGroupe", "UEId" },
                values: new object[] { 1, "Groupe 1", 1 });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "ID", "NomGroupe", "UEId" },
                values: new object[] { 2, "Groupe 2", 1 });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "ID", "NomGroupe", "UEId" },
                values: new object[] { 3, "Groupe 1", 2 });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "ID", "NomGroupe", "UEId" },
                values: new object[] { 4, "Groupe 2", 2 });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "ID", "NomGroupe", "UEId" },
                values: new object[] { 5, "Groupe 1", 3 });

            migrationBuilder.InsertData(
                table: "Groupes",
                columns: new[] { "ID", "NomGroupe", "UEId" },
                values: new object[] { 6, "Groupe 2", 3 });

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
