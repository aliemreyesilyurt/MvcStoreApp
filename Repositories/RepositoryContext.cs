using Entities.Models;
using Entities.Models.Common;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repositories
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.User) // Bir siparişin bir kullanıcıya ait olduğunu belirtiyoruz
                .WithMany() // Kullanıcıda çok sayıda sipariş olabilir, fakat Order tablosunda sadece bir kullanıcıya ait olacağını belirtiyoruz
                .HasForeignKey(o => o.UserId); // Kullanıcı ile ilişkili olan UserId'yi belirtiyoruz

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public override int SaveChanges()
        {
            var datas = ChangeTracker
                .Entries<BaseEntity>();

            foreach (var data in datas)
            {
                if (data.State == EntityState.Added)
                {
                    data.Entity.CreatedDate = DateTime.Now;
                }

                if (data.State == EntityState.Modified)
                {
                    data.Property(nameof(data.Entity.CreatedDate)).IsModified = false;
                    data.Entity.UpdatedDate = DateTime.Now;
                }
            }

            return base.SaveChanges();
        }
    }
}
