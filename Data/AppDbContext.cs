using Microsoft.EntityFrameworkCore;
using rental_system.Models.Entities;

namespace rental_system.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        { 
        }

        public DbSet<UserEntity> Users { get; set; }
        public DbSet<AddPropertyEntity> Properties { get; set; }
        public DbSet<AddRoomEntity> Rooms { get; set; }
        public DbSet<AddTenantEntity> Tenants { get; set; }
        public DbSet<PropertyTenantMapEntity> PropertyTenantMap { get; set; }
        public DbSet<TotalBillEntity> MonthlyBills { get; set; }

  
   }
}
