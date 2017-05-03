using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Capstone5.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<MondayBars> MondayBars { get; set; }
        public DbSet<TuesdayBars> TuesdayBars { get; set; }
        public DbSet<WednesdayBars> WednesdayBars { get;set;}
        public DbSet<ThursdayBars> ThursdayBars { get; set; }
        public DbSet<FridayBars> FridayBars { get; set; }
        public DbSet<SaturdayBars> SaturdayBars { get; set; }
        public DbSet<SundayBars> SundayBars { get; set; }

        public DbSet<FavoriteBars> FavoriteBars { get; set; }
        public object AspNetUsers { get; internal set; }
    }
}