using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal_Wiki.Migrations
{
    public partial class AnimalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kingdoms",
                columns: table => new
                {
                    KingdomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KingdomBasicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KingdomPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kingdoms", x => x.KingdomID);
                });

            migrationBuilder.CreateTable(
                name: "phylia",
                columns: table => new
                {
                    PhyliumID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhyliumBasicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhyliumPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KingdomID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_phylia", x => x.PhyliumID);
                    table.ForeignKey(
                        name: "FK_phylia_kingdoms_KingdomID",
                        column: x => x.KingdomID,
                        principalTable: "kingdoms",
                        principalColumn: "KingdomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "classes",
                columns: table => new
                {
                    AnimalClassID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassBasicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClassPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhyliumID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_classes", x => x.AnimalClassID);
                    table.ForeignKey(
                        name: "FK_classes_phylia_PhyliumID",
                        column: x => x.PhyliumID,
                        principalTable: "phylia",
                        principalColumn: "PhyliumID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "orders",
                columns: table => new
                {
                    OrderID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderBasicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnimalClassID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_orders", x => x.OrderID);
                    table.ForeignKey(
                        name: "FK_orders_classes_AnimalClassID",
                        column: x => x.AnimalClassID,
                        principalTable: "classes",
                        principalColumn: "AnimalClassID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "families",
                columns: table => new
                {
                    FamilyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FamilyBasicDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OrderID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_families", x => x.FamilyID);
                    table.ForeignKey(
                        name: "FK_families_orders_OrderID",
                        column: x => x.OrderID,
                        principalTable: "orders",
                        principalColumn: "OrderID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "genius",
                columns: table => new
                {
                    GeniusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeniusPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeniusBasicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FamilyID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genius", x => x.GeniusID);
                    table.ForeignKey(
                        name: "FK_genius_families_FamilyID",
                        column: x => x.FamilyID,
                        principalTable: "families",
                        principalColumn: "FamilyID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "species",
                columns: table => new
                {
                    SpeciesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    scientificname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeciesPhotoPath = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpeciesBasicDesc = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GeniusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_species", x => x.SpeciesID);
                    table.ForeignKey(
                        name: "FK_species_genius_GeniusID",
                        column: x => x.GeniusID,
                        principalTable: "genius",
                        principalColumn: "GeniusID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_classes_PhyliumID",
                table: "classes",
                column: "PhyliumID");

            migrationBuilder.CreateIndex(
                name: "IX_families_OrderID",
                table: "families",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_genius_FamilyID",
                table: "genius",
                column: "FamilyID");

            migrationBuilder.CreateIndex(
                name: "IX_orders_AnimalClassID",
                table: "orders",
                column: "AnimalClassID");

            migrationBuilder.CreateIndex(
                name: "IX_phylia_KingdomID",
                table: "phylia",
                column: "KingdomID");

            migrationBuilder.CreateIndex(
                name: "IX_species_GeniusID",
                table: "species",
                column: "GeniusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "species");

            migrationBuilder.DropTable(
                name: "genius");

            migrationBuilder.DropTable(
                name: "families");

            migrationBuilder.DropTable(
                name: "orders");

            migrationBuilder.DropTable(
                name: "classes");

            migrationBuilder.DropTable(
                name: "phylia");

            migrationBuilder.DropTable(
                name: "kingdoms");
        }
    }
}
