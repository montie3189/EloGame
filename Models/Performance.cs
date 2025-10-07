using Microsoft.Identity.Client;

namespace EloGame.Models
{
    public class Performance
    {

        public int Id {  get; set; }

        public int gameId  { get; set; }

        public  Game? Game { get; set; }

        public int playerId { get; set; }

        public Player? Player { get; set; }

        public int startElo { get; set; }

        public int endElo { get; set; }
        
        public int position { get; set; }

    }
}
