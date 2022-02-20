using Microsoft.EntityFrameworkCore;
using VideoGame.DAL.Model;

namespace VideoGame.DAL
{
    public class GameContext : DbContext
    {

        public DbSet<Game> Games { get; set; }

        public void CreateDataBase()
        {
            Database.EnsureCreated();
        }

        public GameContext(DbContextOptions options) : base(options)
        {
            CreateDataBase();
        }

        public override void Dispose()
        {
            //Database?.EnsureDeleted();
        }
    }
}

