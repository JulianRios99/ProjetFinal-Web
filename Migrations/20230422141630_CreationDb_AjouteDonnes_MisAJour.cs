using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetFinal.Migrations
{
    /// <inheritdoc />
    public partial class CreationDb_AjouteDonnes_MisAJour : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Ouvrages",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Auteur = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Exemplaires = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ouvrages", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Utilisateurs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Prenom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Courriel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotDePasse = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    Langue = table.Column<int>(type: "int", nullable: false),
                    Admin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilisateurs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UtilisateursID = table.Column<int>(type: "int", nullable: false),
                    OuvrageID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Reservations_Ouvrages_OuvrageID",
                        column: x => x.OuvrageID,
                        principalTable: "Ouvrages",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Reservations_Utilisateurs_UtilisateursID",
                        column: x => x.UtilisateursID,
                        principalTable: "Utilisateurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RoleUtilisateurs",
                columns: table => new
                {
                    RolesID = table.Column<int>(type: "int", nullable: false),
                    UtilisateursID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoleUtilisateurs", x => new { x.RolesID, x.UtilisateursID });
                    table.ForeignKey(
                        name: "FK_RoleUtilisateurs_Roles_RolesID",
                        column: x => x.RolesID,
                        principalTable: "Roles",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RoleUtilisateurs_Utilisateurs_UtilisateursID",
                        column: x => x.UtilisateursID,
                        principalTable: "Utilisateurs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_OuvrageID",
                table: "Reservations",
                column: "OuvrageID");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_UtilisateursID",
                table: "Reservations",
                column: "UtilisateursID");

            migrationBuilder.CreateIndex(
                name: "IX_RoleUtilisateurs_UtilisateursID",
                table: "RoleUtilisateurs",
                column: "UtilisateursID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reservations");

            migrationBuilder.DropTable(
                name: "RoleUtilisateurs");

            migrationBuilder.DropTable(
                name: "Ouvrages");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Utilisateurs");
        }
    }
}
