using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class breed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FelineSpecies",
                table: "Animals",
                newName: "FelineBreed");

            migrationBuilder.RenameColumn(
                name: "CanineSpecies",
                table: "Animals",
                newName: "CanineBreed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FelineBreed",
                table: "Animals",
                newName: "FelineSpecies");

            migrationBuilder.RenameColumn(
                name: "CanineBreed",
                table: "Animals",
                newName: "CanineSpecies");
        }
    }
}
