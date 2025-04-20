using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CodePostal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Nom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Prenom = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ville = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Livreur",
                columns: table => new
                {
                    CIN = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CodePostal = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RaisonSocial = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Ville = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livreur", x => x.CIN);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Vehicule",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Couleur = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Marque = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VitesseLimite = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicule", x => x.Matricule);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Colis",
                columns: table => new
                {
                    DateLivraison = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    LivreurFk = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ClientFk = table.Column<int>(type: "int", nullable: false),
                    Montant = table.Column<double>(type: "double", nullable: false),
                    Poids = table.Column<double>(type: "double", nullable: false),
                    Volume = table.Column<double>(type: "double", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colis", x => new { x.LivreurFk, x.ClientFk, x.DateLivraison });
                    table.ForeignKey(
                        name: "FK_Colis_Client_ClientFk",
                        column: x => x.ClientFk,
                        principalTable: "Client",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Colis_Livreur_LivreurFk",
                        column: x => x.LivreurFk,
                        principalTable: "Livreur",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Camion",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capacite = table.Column<int>(type: "int", nullable: false),
                    NbrEssieux = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Camion", x => x.Matricule);
                    table.ForeignKey(
                        name: "FK_Camion_Vehicule_Matricule",
                        column: x => x.Matricule,
                        principalTable: "Vehicule",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Conduite",
                columns: table => new
                {
                    LivreursCIN = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VehiculesMatricule = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conduite", x => new { x.LivreursCIN, x.VehiculesMatricule });
                    table.ForeignKey(
                        name: "FK_Conduite_Livreur_LivreursCIN",
                        column: x => x.LivreursCIN,
                        principalTable: "Livreur",
                        principalColumn: "CIN",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Conduite_Vehicule_VehiculesMatricule",
                        column: x => x.VehiculesMatricule,
                        principalTable: "Vehicule",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Voiture",
                columns: table => new
                {
                    Matricule = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NbrPlaces = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Voiture", x => x.Matricule);
                    table.ForeignKey(
                        name: "FK_Voiture_Vehicule_Matricule",
                        column: x => x.Matricule,
                        principalTable: "Vehicule",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Colis_ClientFk",
                table: "Colis",
                column: "ClientFk");

            migrationBuilder.CreateIndex(
                name: "IX_Conduite_VehiculesMatricule",
                table: "Conduite",
                column: "VehiculesMatricule");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Camion");

            migrationBuilder.DropTable(
                name: "Colis");

            migrationBuilder.DropTable(
                name: "Conduite");

            migrationBuilder.DropTable(
                name: "Voiture");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Livreur");

            migrationBuilder.DropTable(
                name: "Vehicule");
        }
    }
}
