using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EloGame.Data.Migrations
{
    /// <inheritdoc />
    public partial class eloupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaguePos_League_LeagueId",
                table: "LeaguePos");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaguePos_Player_PlayerId",
                table: "LeaguePos");

            migrationBuilder.RenameColumn(
                name: "PlayerId",
                table: "LeaguePos",
                newName: "playerId");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "LeaguePos",
                newName: "leagueId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaguePos_PlayerId",
                table: "LeaguePos",
                newName: "IX_LeaguePos_playerId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaguePos_LeagueId",
                table: "LeaguePos",
                newName: "IX_LeaguePos_leagueId");

            migrationBuilder.AddColumn<int>(
                name: "elo",
                table: "LeaguePos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaguePos_League_leagueId",
                table: "LeaguePos",
                column: "leagueId",
                principalTable: "League",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaguePos_Player_playerId",
                table: "LeaguePos",
                column: "playerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LeaguePos_League_leagueId",
                table: "LeaguePos");

            migrationBuilder.DropForeignKey(
                name: "FK_LeaguePos_Player_playerId",
                table: "LeaguePos");

            migrationBuilder.DropColumn(
                name: "elo",
                table: "LeaguePos");

            migrationBuilder.RenameColumn(
                name: "playerId",
                table: "LeaguePos",
                newName: "PlayerId");

            migrationBuilder.RenameColumn(
                name: "leagueId",
                table: "LeaguePos",
                newName: "LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaguePos_playerId",
                table: "LeaguePos",
                newName: "IX_LeaguePos_PlayerId");

            migrationBuilder.RenameIndex(
                name: "IX_LeaguePos_leagueId",
                table: "LeaguePos",
                newName: "IX_LeaguePos_LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_LeaguePos_League_LeagueId",
                table: "LeaguePos",
                column: "LeagueId",
                principalTable: "League",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LeaguePos_Player_PlayerId",
                table: "LeaguePos",
                column: "PlayerId",
                principalTable: "Player",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
