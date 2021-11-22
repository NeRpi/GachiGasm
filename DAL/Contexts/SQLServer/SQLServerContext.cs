using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Contexts.SQLServer
{
    public class SQLServerContext : DbContext
    {
        public SQLServerContext()
        { 
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost;Database=Manga;Trusted_Connection=True;");
        }

        public DbSet<Manga> Mangas { get; set; } 
    }
}
