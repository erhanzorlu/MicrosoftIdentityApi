using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MicrosoftIdentityApi.Models
{
    public class AppDbContext:IdentityDbContext<AppUser,IdentityRole<Guid>,Guid>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

    }
}
