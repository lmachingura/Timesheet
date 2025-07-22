using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimesheetApp.Web.Models;

namespace TimesheetApp.Web.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<Organisation> Organisations { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }
        public DbSet<TimeEntry> TimeEntries { get; set; }
        public DbSet<Permission> Permissions { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Optional: Seed roles, permissions etc here later
        }

    }
}
