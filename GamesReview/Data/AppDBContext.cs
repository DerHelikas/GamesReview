using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GamesReview.Data
{
    public class AppDBContext : DbContext
    {
        protected readonly IConfiguration configuration;

        public AppDBContext(IConfiguration configuration)
        {
            this.configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(configuration.GetConnectionString("WebApiDatabase"));
        }

        public List<Game> GetTheBest()
        {
            return Games
                .Where(game => game.Rate != 0)
                .OrderByDescending(gm => gm.Rate)
                .ThenBy(elm => elm.Name)
                .Take(5)
                .ToList() ?? new List<Game>();
        }

        public List<Game> GetGamesWithoutRate()
        {
            return
                Games
                .Where(game => game.Rate == 0)
                .ToList();
        }

        public List<Game> GetGamesOnlyWithRate()
        {
            return
                Games
                .Where(game => game.Rate != 0)
                .ToList();
        }

        public List<Game> GetLatestGames()
        {
            return Games
                .OrderByDescending(elm => elm.ReleaseDate)
                .Take(6)
                .ToList();
        }

        public List<ReviewClass> GetAllGameReview(string GameID)
        {
            if (Games == null)
                return new List<ReviewClass>();

            string[] reviews =
                Games
               .ToList()
               .Find(g => g.ID == GameID)
               .ReviewsID ?? new string[0] { };

            return Reviews.Where(rew => reviews.Contains(rew.ReviewID)).ToList();

        }

        public DbSet<Game> Games { get; set; }
        public DbSet<ReviewClass> Reviews { get; set; }
    }
}
