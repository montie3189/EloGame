namespace EloGame.Models
{
    public class Game
    {

        public int Id { get; set; }

        public DateTime time {  get; set; }

        public int playerNum { get; set; }

        public int leagueId { get; set; }

        public League? league { get; set; }

        public ICollection<Performance> performances { get; set; } = new List<Performance>();
    }
}
