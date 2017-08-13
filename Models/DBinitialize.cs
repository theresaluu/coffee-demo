using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace App.Models
{
    public static class DBinitialize
    {
        public static void EnsureCreated(IServiceProvider serviceProvider)
        {
            var context = new AppzContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppzContext>>());
            context.Database.EnsureCreated();
        }
    }
}