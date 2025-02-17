using Microsoft.EntityFrameworkCore;
using UtilityServiceAPI.Models;

namespace UtilityServiceAPI.Data {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<ServiceRequest> ServiceRequests { get; set; }
        public DbSet<EnergyConsumption> EnergyConsumptions { get; set; }
    }
}