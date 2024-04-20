using Lab_2_MVC.Models.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lab_2_MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Classes> Classes { get; set; }

        public DbSet<Teachers> Teachers { get; set; }

        public DbSet<Students> Students { get; set; }
        public DbSet<Search> Searches { get; set; }

    }
}
