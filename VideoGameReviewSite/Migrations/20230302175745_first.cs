using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace VideoGameReviewSite.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VideoGame",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublishersId = table.Column<int>(type: "int", nullable: false),
                    Reviews = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cost = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VideoGame", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VideoGame_Publishers_PublishersId",
                        column: x => x.PublishersId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Activision" },
                    { 2, "Electronic Arts" }
                });

            migrationBuilder.InsertData(
                table: "VideoGame",
                columns: new[] { "Id", "Cost", "Description", "Image", "PublishersId", "ReleaseDate", "Reviews", "Title" },
                values: new object[,]
                {
                    { 1, 31.809999999999999, "Call of Duty: Modern Warfare II is a 2022 first-person shooter game developed by Infinity Ward and published by Activision. It is a sequel to the 2019 reboot, and serves as the nineteenth installment in the overall Call of Duty series.", "https://upload.wikimedia.org/wikipedia/en/4/4a/Call_of_Duty_Modern_Warfare_II_Key_Art.jpg", 1, "10/28/2022", "Troll Capital and full of glitches TL;DR: UI is full of bugs and issues. DMZ is full of squad hunting Trolls, multiplayer is full of hyped up Call of Duty League wanna bees, with either Smgs or no scope Snipers. The assault rifles all suck by comparision. ", "Call of Duty: Modern Warfare II" },
                    { 2, 29.949999999999999, "It is a simulation of the daily activities of one or more virtual people,Players control customizable Sims as they pursue career and relationship goals. Players can also use their Sims' income to renovate their living space, and purchase home furnishings, or clothing for their household. Players can also choose to pursue a social and successful life.", "https://upload.wikimedia.org/wikipedia/en/2/22/The_Sims_Coverart.png", 2, "02/04/2000", "This game is so, so, so, good, but has it's problems. The OST is some of the best I've heard in video games as a whole, the gameplay is challenging and exciting, and this game as so much personality to it. However, the game is wayyy too hard to actually relax in it ", "The Sims" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_VideoGame_PublishersId",
                table: "VideoGame",
                column: "PublishersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VideoGame");

            migrationBuilder.DropTable(
                name: "Publishers");
        }
    }
}
