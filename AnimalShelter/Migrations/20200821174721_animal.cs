using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class animal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Canines");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Felines",
                table: "Felines");

            migrationBuilder.RenameTable(
                name: "Felines",
                newName: "Animals");

            migrationBuilder.RenameColumn(
                name: "Species",
                table: "Animals",
                newName: "FelineSpecies");

            migrationBuilder.RenameColumn(
                name: "FelineId",
                table: "Animals",
                newName: "AnimalId");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Animals",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "CanineSpecies",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Animals",
                table: "Animals",
                column: "AnimalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Animals",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CanineSpecies",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "Felines");

            migrationBuilder.RenameColumn(
                name: "FelineSpecies",
                table: "Felines",
                newName: "Species");

            migrationBuilder.RenameColumn(
                name: "AnimalId",
                table: "Felines",
                newName: "FelineId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Felines",
                table: "Felines",
                column: "FelineId");

            migrationBuilder.CreateTable(
                name: "Canines",
                columns: table => new
                {
                    CanineId = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Age = table.Column<int>(nullable: false),
                    Bio = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Species = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Canines", x => x.CanineId);
                });
        }
    }
}
