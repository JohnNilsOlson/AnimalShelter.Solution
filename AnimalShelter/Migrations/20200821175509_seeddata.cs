using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "CanineSpecies" },
                values: new object[] { 1, 7, "Loves fetch!", "Canine", "Female", "Rex", 42, "Labrador Retreiver" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "FelineSpecies" },
                values: new object[] { 2, 3, "Loves belly rubs!", "Feline", "Male", "Whiskers", 10, "Tabby" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);
        }
    }
}
