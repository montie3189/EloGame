using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EloGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class leagueUserUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "League",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(21)",
                maxLength: 21,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_League_OwnerId",
                table: "League",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_League_AspNetUsers_OwnerId",
                table: "League",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_League_AspNetUsers_OwnerId",
                table: "League");

            migrationBuilder.DropIndex(
                name: "IX_League_OwnerId",
                table: "League");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "League");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
