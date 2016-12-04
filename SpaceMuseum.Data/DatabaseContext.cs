using System;
using System.Data.Entity;

namespace SpaceMuseum.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;
    using System.Configuration;

    public class DatabaseContext : IdentityDbContext
    {
        public DatabaseContext()
            : this(ConfigurationManager.ConnectionStrings["DefaultConnectionString"].ConnectionString)
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }
        
        public DbSet<Image> Images { get; set; }
        public DbSet<Exhibit> Exhibits { get; set; }
        public DbSet<Event> Events { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure domain classes using modelBuilder
            // Images
            modelBuilder.Entity<Image>().Property(x => x.Name).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Image>().Property(x => x.URL).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Image>().Property(x => x.MIME).HasMaxLength(256).IsRequired();

            // Exhibits
            modelBuilder.Entity<Exhibit>().Property(x => x.Name).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Exhibit>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Exhibit>()
                .HasMany(x => x.Images)
                .WithMany(y => y.Exhibits)
                .Map(z => z.MapLeftKey("ExhibitID").MapRightKey("ImageID").ToTable("ExhibitImages"));

            // Events
            modelBuilder.Entity<Event>().Property(x => x.Name).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<Event>().Property(x => x.Description).IsRequired();
            modelBuilder.Entity<Event>()
                .HasMany(x => x.Images)
                .WithMany(y => y.Events)
                .Map(z => z.MapLeftKey("EventID").MapRightKey("ImageID").ToTable("EventImages"));
            modelBuilder.Entity<Event>()
                .HasMany(x => x.Exhibits)
                .WithMany(y => y.Events)
                .Map(z => z.MapLeftKey("EventID").MapRightKey("ExhibitID").ToTable("EventExhibits"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
