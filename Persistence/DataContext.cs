using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        
        }

        public DbSet<Activity> Activities {get;set;}

        public DbSet<Project> Project {get;set;}

        public DbSet<User> User {get;set;}

        public DbSet<UserTasks> UserTasks {get;set;}

    }
}