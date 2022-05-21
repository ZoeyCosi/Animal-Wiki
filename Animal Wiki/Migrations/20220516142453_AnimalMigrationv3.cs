using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal_Wiki.Migrations
{
    public partial class AnimalMigrationv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "KingdomPhotoPath",
                table: "kingdoms",
                newName: "photopath");

            migrationBuilder.RenameColumn(
                name: "KingdomName",
                table: "kingdoms",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "KingdomBasicDesc",
                table: "kingdoms",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "KingdomID",
                table: "kingdoms",
                newName: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "photopath",
                table: "kingdoms",
                newName: "KingdomPhotoPath");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "kingdoms",
                newName: "KingdomName");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "kingdoms",
                newName: "KingdomBasicDesc");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "kingdoms",
                newName: "KingdomID");
        }
    }
}
