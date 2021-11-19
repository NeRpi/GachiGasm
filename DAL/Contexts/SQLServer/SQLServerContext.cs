using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts.SQLServer
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext()
        {
            // Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=labirint;Trusted_Connection=True;");
        }

        public DbSet<Manga> Mangas { get; set; } 
    }
}
