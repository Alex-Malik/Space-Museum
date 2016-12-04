using System;
using System.Data.Entity;

namespace SpaceMuseum.Data
{
    using Models;

    public class DatabaseContext : DbContext
    {
        public readonly Guid ID = Guid.NewGuid();

        public DatabaseContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Image> Images { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure domain classes using modelBuilder
            // Users and Roles
            modelBuilder.Entity<Role>().Property(r => r.Name).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Username).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).HasMaxLength(256).IsRequired();
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(ur => ur.MapLeftKey("UserID").MapRightKey("RoleID").ToTable("UserRoles"));

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
