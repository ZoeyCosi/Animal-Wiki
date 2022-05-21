using Microsoft.EntityFrameworkCore.Migrations;

namespace Animal_Wiki.Migrations
{
    public partial class AnimalMigrationv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhyliumName",
                table: "phylia",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OrderName",
                table: "orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KingdomName",
                table: "kingdoms",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "GeniusName",
                table: "genius",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FamilyName",
                table: "families",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnimalClassName",
                table: "classes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhyliumName",
                table: "phylia");

            migrationBuilder.DropColumn(
                name: "OrderName",
                table: "orders");

            migrationBuilder.DropColumn(
                name: "KingdomName",
                table: "kingdoms");

            migrationBuilder.DropColumn(
                name: "GeniusName",
                table: "genius");

            migrationBuilder.DropColumn(
                name: "FamilyName",
                table: "families");

            migrationBuilder.DropColumn(
                name: "AnimalClassName",
                table: "classes");
        }
    }
}
