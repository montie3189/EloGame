using Microsoft.IdentityModel;
using System;
//using Microsoft.Identity;
using Microsoft.AspNetCore.Identity;

namespace EloGame.Models
{
    public class League
    {

        public int Id { get; set; }

        public required string Name { get; set; }

        public DateTime Created { get; set; }

        //public ApplicationUser? Owner { get; set; }

        public ICollection<LeaguePos> LeaguePositions { get; set; } = new List<LeaguePos>();
    }
}
