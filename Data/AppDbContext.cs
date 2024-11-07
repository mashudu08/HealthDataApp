using HealthDataApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HealthDataApp.Data
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients { get; set; }
        public DbSet<HealthData> HealthData { get; set; }
        public DbSet<Alert> Alerts { get; set; }
    }
}
