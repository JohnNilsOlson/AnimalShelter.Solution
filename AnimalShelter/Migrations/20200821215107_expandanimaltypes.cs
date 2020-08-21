using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalShelter.Migrations
{
    public partial class expandanimaltypes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.AddColumn<string>(
                name: "BirdBreed",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EquineBreed",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ReptileBreed",
                table: "Animals",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RodentBreed",
                table: "Animals",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "BirdBreed" },
                values: new object[] { 11, 3, "Very communicative!", "Bird", "Male", "Chirpy", 1, "Parakeet" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "ReptileBreed" },
                values: new object[,]
                {
                    { 23, 3, "Loves a good maze!", "Reptile", "Female", "Creampuff", 2, null },
                    { 22, 1, "Goes west!", "Reptile", "Male", "Fievel", 1, null },
                    { 21, 2, "Loves cheese!", "Reptile", "Male", "Templeton", 1, null },
                    { 20, 2, "Has a British Accent!", "Reptile", "Male", "Geico", 1, "Gecko" },
                    { 19, 8, "Loves to wrestle!", "Reptile", "Female", "Alli", 46, "Alligator" },
                    { 18, 5, "Loves lounging in the sun!", "Reptile", "Male", "Puff", 24, "Kimodo Dragon" },
                    { 17, 13, "Gives great hugs!", "Reptile", "Female", "Kaa", 47, "Boa Constrictor" },
                    { 16, 4, "Will bite!", "Reptile", "Female", "Chompy", 1, "Snapping Turtle" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "FelineBreed" },
                values: new object[,]
                {
                    { 10, 8, "Hypo-allergenic!", "Feline", "Female", "Fluffy", 9, "Sphynx" },
                    { 9, 4, "Dumb but loveable!", "Feline", "Male", "Stimpy", 15, "Manx" },
                    { 8, 9, "Loves chasing toys!", "Feline", "Female", "Snowball", 2, "Persian" },
                    { 7, 6, "Ornery!", "Feline", "Male", "Simba", 12, "Maine Coon" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "ReptileBreed" },
                values: new object[] { 24, 4, "Cuddly!", "Reptile", "Female", "Cookie", 3, null });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "FelineBreed" },
                values: new object[] { 6, 3, "Loves belly rubs!", "Feline", "Male", "Whiskers", 10, "Tabby" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "EquineBreed" },
                values: new object[,]
                {
                    { 29, 7, "Can do math!", "Equine", "Female", "Einstein", 564, "Miniature" },
                    { 28, 5, "Kind hearted!", "Equine", "Male", "Black Beauty", 1124, "American Quarter" },
                    { 27, 12, "Very fast!", "Equine", "Male", "Secretariat", 986, "Thoroughbred" },
                    { 26, 6, "Adventurous!", "Equine", "Male", "Artax", 1256, "Arabian" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "CanineBreed" },
                values: new object[,]
                {
                    { 5, 5, "Courageous!", "Canine", "Female", "Spot", 41, "Dalmation" },
                    { 4, 3, "Very loyal!", "Canine", "Male", "Lassie", 47, "Border Collie" },
                    { 3, 6, "Yappy!", "Canine", "Male", "Ren", 12, "Chihuahua" },
                    { 2, 2, "Needs leash traning!", "Canine", "Female", "Ramona", 55, "German Shepard" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "BirdBreed" },
                values: new object[,]
                {
                    { 15, 14, "Extremely fast!", "Bird", "Female", "Ozzie", 45, "Emu" },
                    { 14, 5, "Regal!", "Bird", "Female", "Sam", 12, "Bald Eagle" },
                    { 13, 9, "Not friendly!", "Bird", "Male", "Blue", 3, "Macaw" },
                    { 12, 12, "Escape artist!", "Bird", "Female", "Stripes", 1, "Zebra Finch" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "EquineBreed" },
                values: new object[] { 30, 9, "A former movie star!", "Equine", "Male", "Cojo Rojo", 1347, "Appaloosa" });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "ReptileBreed" },
                values: new object[] { 25, 2, "Loves to play hide and seek!", "Reptile", "Male", "Slinky", 3, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Animals",
                keyColumn: "AnimalId",
                keyValue: 25);

            migrationBuilder.DropColumn(
                name: "BirdBreed",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "EquineBreed",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "ReptileBreed",
                table: "Animals");

            migrationBuilder.DropColumn(
                name: "RodentBreed",
                table: "Animals");

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "Bio", "Discriminator", "Gender", "Name", "Weight", "FelineBreed" },
                values: new object[] { 2, 3, "Loves belly rubs!", "Feline", "Male", "Whiskers", 10, "Tabby" });
        }
    }
}
