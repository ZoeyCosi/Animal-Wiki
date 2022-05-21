using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal_Wiki.Migrations
{
    public partial class AnimalMigrationv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "SpeciesPhotoPath",
                table: "species",
                newName: "photopath");

            migrationBuilder.RenameColumn(
                name: "SpeciesBasicDesc",
                table: "species",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "SpeciesID",
                table: "species",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "PhyliumPhotoPath",
                table: "phylia",
                newName: "photopath");

            migrationBuilder.RenameColumn(
                name: "PhyliumName",
                table: "phylia",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "PhyliumBasicDesc",
                table: "phylia",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "PhyliumID",
                table: "phylia",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "OrderPhotoPath",
                table: "orders",
                newName: "photopath");

            migrationBuilder.RenameColumn(
                name: "OrderName",
                table: "orders",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "OrderBasicDesc",
                table: "orders",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "OrderID",
                table: "orders",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "GeniusPhotoPath",
                table: "genius",
                newName: "photopath");

            migrationBuilder.RenameColumn(
                name: "GeniusName",
                table: "genius",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "GeniusBasicDesc",
                table: "genius",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "GeniusID",
                table: "genius",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "FamilyPhotoPath",
                table: "families",
                newName: "photopath");

            migrationBuilder.RenameColumn(
                name: "FamilyName",
                table: "families",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "FamilyBasicDescription",
                table: "families",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "FamilyID",
                table: "families",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "ClassPhotoPath",
                table: "classes",
                newName: "photopath");

            migrationBuilder.RenameColumn(
                name: "ClassBasicDesc",
                table: "classes",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "AnimalClassName",
                table: "classes",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "AnimalClassID",
                table: "classes",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photopath",
                table: "species",
                newName: "SpeciesPhotoPath");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "species",
                newName: "SpeciesBasicDesc");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "species",
                newName: "SpeciesID");

            migrationBuilder.RenameColumn(
                name: "photopath",
                table: "phylia",
                newName: "PhyliumPhotoPath");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "phylia",
                newName: "PhyliumName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "phylia",
                newName: "PhyliumBasicDesc");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "phylia",
                newName: "PhyliumID");

            migrationBuilder.RenameColumn(
                name: "photopath",
                table: "orders",
                newName: "OrderPhotoPath");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "orders",
                newName: "OrderName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "orders",
                newName: "OrderBasicDesc");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "orders",
                newName: "OrderID");

            migrationBuilder.RenameColumn(
                name: "photopath",
                table: "genius",
                newName: "GeniusPhotoPath");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "genius",
                newName: "GeniusName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "genius",
                newName: "GeniusBasicDesc");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "genius",
                newName: "GeniusID");

            migrationBuilder.RenameColumn(
                name: "photopath",
                table: "families",
                newName: "FamilyPhotoPath");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "families",
                newName: "FamilyName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "families",
                newName: "FamilyBasicDescription");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "families",
                newName: "FamilyID");

            migrationBuilder.RenameColumn(
                name: "photopath",
                table: "classes",
                newName: "ClassPhotoPath");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "classes",
                newName: "ClassBasicDesc");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "classes",
                newName: "AnimalClassName");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "classes",
                newName: "AnimalClassID");
        }
    }
}
