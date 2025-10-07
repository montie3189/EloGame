using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EloGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class gameupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Game_GameId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Player_PlayerId",
                table: "Performance");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "Performance",
                newName: "playerId");

            migrationBuilder.RenameColumn(
                name: "GameId",
                table: "Performance",
                newName: "gameId");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_PlayerId",
                table: "Performance",
                newName: "IX_Performance_playerId");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_GameId",
                table: "Performance",
                newName: "IX_Performance_gameId");

            migrationBuilder.AddColumn<int>(
                name: "leagueId",
                table: "Game",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Game_leagueId",
                table: "Game",
                column: "leagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Game_League_leagueId",
                table: "Game",
                column: "leagueId",
                principalTable: "League",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Game_gameId",
                table: "Performance",
                column: "gameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Player_playerId",
                table: "Performance",
                column: "playerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Game_League_leagueId",
                table: "Game");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Game_gameId",
                table: "Performance");

            migrationBuilder.DropForeignKey(
                name: "FK_Performance_Player_playerId",
                table: "Performance");

            migrationBuilder.DropIndex(
                name: "IX_Game_leagueId",
                table: "Game");

            migrationBuilder.DropColumn(
                name: "leagueId",
                table: "Game");

            migrationBuilder.RenameColumn(
                name: "playerId",
                table: "Performance",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "gameId",
                table: "Performance",
                newName: "GameId");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_playerId",
                table: "Performance",
                newName: "IX_Performance_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_Performance_gameId",
                table: "Performance",
                newName: "IX_Performance_GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Game_GameId",
                table: "Performance",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Performance_Player_PlayerId",
                table: "Performance",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
