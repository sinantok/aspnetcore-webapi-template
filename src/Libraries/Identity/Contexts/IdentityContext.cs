using Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.Contexts
{
    public class IdentityContext
    : IdentityDbContext<
        ApplicationUser, ApplicationRole, int,
        ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin,
        ApplicationRoleClaim, ApplicationUserToken>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "User");
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });

            builder.Entity<ApplicationUserRole>(entity =>
            {
                entity.HasKey(ur => new { ur.UserId, ur.RoleId });

                entity.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                entity.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
                entity.ToTable("UserRoles");
            });

            builder.Entity<ApplicationUserClaim>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<ApplicationUserLogin>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<ApplicationRoleClaim>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<ApplicationUserToken>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
