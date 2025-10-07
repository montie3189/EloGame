using System.ComponentModel.DataAnnotations;

namespace EloGame.Models
{
    public class Player
    {

        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime dateTime { get; set; }

        public ICollection<Performance> Performances { get; set; } = new List<Performance>();

        public ICollection<LeaguePos> LeaguePositions { get; set; } = new List<LeaguePos>();
    }
}
