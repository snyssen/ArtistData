using System.Reflection;
using System;
using Microsoft.EntityFrameworkCore;
using Context.Models;

namespace Context
{
    public class ArtistContext : DbContext
       
    {
        public ArtistContext()
        {
        }

        public ArtistContext(DbContextOptions<ArtistContext> options)
            : base(options)
        {
        }

        public DbSet<Artist> Artists { get; set; }
        public  DbSet<Release> Releases { get; set; }
    }
}