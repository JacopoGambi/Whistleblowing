using Whistleblowing.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Whistleblowing.Services.Shared;

namespace Whistleblowing.Services
{
    public class WhistleblowingDbContext : DbContext
    {
        public WhistleblowingDbContext()
        {
        }

        public WhistleblowingDbContext(DbContextOptions<WhistleblowingDbContext> options) : base(options)
        {
            DataGenerator.InitializeUsers(this);
        }

        public DbSet<User> Users { get; set; }
    }
}
