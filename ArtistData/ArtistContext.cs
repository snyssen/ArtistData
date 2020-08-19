using ArtistData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistData
{
   public class ArtistContext: DbContext
    {
        public DbSet<Artist> Artists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-5A54U6A;Database=Artist;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}
