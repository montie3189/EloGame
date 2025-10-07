namespace EloGame.Models
{
    public class LeaguePos
    {
        public int Id { get; set; }

        public int leagueId { get; set; }

        public int elo { get; set; }
        public required League  League { get; set; }

        public int playerId { get; set; }

        public required Player Player { get; set; }
    }
}
