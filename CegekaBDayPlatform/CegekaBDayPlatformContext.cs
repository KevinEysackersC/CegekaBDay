using CegekaBDayPlatform.Model;
using Microsoft.EntityFrameworkCore;

namespace CegekaBDayPlatform
{
    public class CegekaBDayPlatformContext : DbContext
    {
            public DbSet<Person> Persons { get; set; }
            public DbSet<UserRole> UserRoles { get; set; }
            public DbSet<User> Users { get; set; }


        public CegekaBDayPlatformContext(DbContextOptions<CegekaBDayPlatformContext> options) : base(options)
        {
        }
    }
}
