using System.Data.Entity;

namespace SpaceMuseum.Data
{
    using Models;

    class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Configure domain classes using modelBuilder here
            modelBuilder.Entity<User>()
                .HasMany(u => u.Roles)
                .WithMany(r => r.Users)
                .Map(ur => ur.MapLeftKey("UserID").MapRightKey("RoleID").ToTable("UserRoles"));

            base.OnModelCreating(modelBuilder);
        }
    }
}
