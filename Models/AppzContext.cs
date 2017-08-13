using Microsoft.EntityFrameworkCore;

namespace App.Models
{
    public class AppzContext : DbContext
    {
        public AppzContext (DbContextOptions<AppzContext> options)
            : base(options)
        {
        }

        public DbSet<App.Models.Coffee> Coffee { get; set; }
    }
}