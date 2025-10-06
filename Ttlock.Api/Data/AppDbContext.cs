using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Ttlock.Api.Models;

namespace Ttlock.Api.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<SmartLock> SmartLocks => Set<SmartLock>();
        public DbSet<AccessGrant> AccessGrants => Set<AccessGrant>();
        public DbSet<AccessLog> AccessLogs => Set<AccessLog>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<SmartLock>()
                .HasIndex(l => l.TtlockId)
                .IsUnique();

            builder.Entity<AccessGrant>()
                .HasOne(g => g.User)
                .WithMany()
                .HasForeignKey(g => g.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<AccessGrant>()
                .HasOne(g => g.SmartLock)
                .WithMany(l => l.AccessGrants)
                .HasForeignKey(g => g.SmartLockId);

            builder.Entity<AccessLog>()
                .HasOne(l => l.SmartLock)
                .WithMany()
                .HasForeignKey(l => l.SmartLockId);
        }
    }
}