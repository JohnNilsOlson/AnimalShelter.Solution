using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class animals : Migration
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

            migrationBuilder.AlterColumn<int>(
                name: "FelineId",
                table: "Animals",
                nullable: true,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "AnimalId",
                table: "Animals",
                nullable: false,
                defaultValue: 0)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Animals",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "CanineId",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Feline_Species",
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
                name: "AnimalId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "CanineId",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "Feline_Species",
                table: "Animals");

            migrationBuilder.RenameTable(
                name: "Animals",
                newName: "Felines");

            migrationBuilder.AlterColumn<int>(
                name: "FelineId",
                table: "Felines",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true)
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

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
