using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using EloGame.Models;

namespace EloGame.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<EloGame.Models.Game> Game { get; set; } = default!;
        public DbSet<EloGame.Models.League> League { get; set; } = default!;
        public DbSet<EloGame.Models.LeaguePos> LeaguePos { get; set; } = default!;
        public DbSet<EloGame.Models.Performance> Performance { get; set; } = default!;
        public DbSet<EloGame.Models.Player> Player { get; set; } = default!;
    }
}
