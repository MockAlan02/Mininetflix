using Microsoft.EntityFrameworkCore;
using MiniNetflix.Core.Entities;
using System.Reflection;

namespace MiniNetflix.InfraEstructure.Context
{
    public class MiniNetflixContext : DbContext
    {
        public MiniNetflixContext(DbContextOptions<MiniNetflixContext> options) : base(options)
        {
            
        }
        public DbSet<Serie> Serie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<Production> Production { get; set; }
        public DbSet<GenreSerie> GenreSeries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        }

    }
}
