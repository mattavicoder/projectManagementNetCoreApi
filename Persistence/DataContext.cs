using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Activity> Activities { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<AppUser> AppUser { get; set; }

        public DbSet<UserTasks> UserTasks { get; set; }

    }
}