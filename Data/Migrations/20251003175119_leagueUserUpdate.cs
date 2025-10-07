using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EloGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class leagueUserUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "League");

            migrationBuilder.RenameColumn(
                name: "created",
                table: "League",
                newName: "Created");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "League",
                newName: "created");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "League",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
