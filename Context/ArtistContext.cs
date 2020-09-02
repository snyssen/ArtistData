using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using Context.Models;

namespace Context
{
    public class ArtistContext : DbContext
       
    {
        

        public ArtistContext(DbContextOptions<ArtistContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public  DbSet<Release> Releases { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5A54U6A;Database=ArtistContext;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}