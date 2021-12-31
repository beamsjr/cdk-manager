using cdkManager.Models;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace cdkManager.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<IdentityUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }

        public virtual DbSet<Models.Stack>? Stack { get; set; }
        public virtual DbSet<Models.Bucket>? Bucket { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Stack>(entity =>
            {
                entity.Property(e => e.StackName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Models.Bucket>(entity =>
            {
                entity.Property(e => e.BucketName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new RoleConfiguration());
        }

    }
}