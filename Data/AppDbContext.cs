using AvanceradDotNet_Labb4.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace AvanceradDotNet_Labb4.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Person>().
                HasData(new Person { PersonId = -3, Name = "Sven Svensson", Phone = "0743524435" });
            modelBuilder.Entity<Person>().
                HasData(new Person { PersonId = -2, Name = "Klara Larsson", Phone = "0774563455" });
            modelBuilder.Entity<Person>().
                HasData(new Person{ PersonId = -1, Name = "Janne Josefsson", Phone = "0797534262"});

            modelBuilder.Entity<Interest>().
                HasData(new Interest { InterestId = -4, Title = "Surf", Description = "Att åka på vågor med en bräda." });
            modelBuilder.Entity<Interest>().
                HasData(new Interest { InterestId = -3, Title = "Fotografering", Description = "Springer runt med en kamera runt halsen." });
            modelBuilder.Entity<Interest>().
                HasData(new Interest {InterestId = -2, Title = "Musik", Description = "Plinka på ett piano eller en gitarr typ." });
            modelBuilder.Entity<Interest>().
                HasData(new Interest {InterestId = -1, Title = "Spelutveckling", Description = "Programmering i Unity." });

            modelBuilder.Entity<Link>().
                HasData(new Link { LinkId = -6, LinkName = "Surf.se", LinkUrl = "https://www.surf.se/" });
            modelBuilder.Entity<Link>().
                HasData(new Link { LinkId = -5, LinkName = "Kamera & Bild", LinkUrl = "https://www.kamerabild.se/fotoskolor/fotografering" });
            modelBuilder.Entity<Link>().
                HasData(new Link { LinkId = -4, LinkName = "Musiksidan", LinkUrl = "https://www.musiksidan.nu/" });
            modelBuilder.Entity<Link>().
                HasData(new Link{ LinkId = -3, LinkName = "Unity Homepage", LinkUrl = "https://unity.com/" });
            modelBuilder.Entity<Link>().
                HasData(new Link{ LinkId = -2, LinkName = "Surfskolan", LinkUrl = "https://surfskolan.se/" });
            modelBuilder.Entity<Link>().
                HasData(new Link{ LinkId = -1, LinkName = "Fotosidan", LinkUrl = "https://www.fotosidan.se/" });



        }

    }
}
