using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicrosoftIdentityApi.Models
{
    public class AppDbContext:IdentityDbContext<AppUser,AppRole,Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<AppUserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<AppUserRole>().HasKey(x => new { x.RoleId, x.UserId }); //composite key

            builder.Ignore<IdentityUserLogin<Guid>>();
            builder.Ignore<IdentityUserToken<Guid>>();
            builder.Ignore<IdentityUserClaim<Guid>>();
            builder.Ignore<IdentityRoleClaim<Guid>>();
            builder.Ignore<IdentityUserRole<Guid>>();
        }
    }
}
