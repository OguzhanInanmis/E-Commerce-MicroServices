using E_Commerce.Cargo.Entity.Concrete;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce.Cargo.DataAccess.Concrete
{
    public class CargoContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1441;initial catalog=E-CommerceCargoDb;user=sa;password=123456aA*;TrustServerCertificate=True");
        }

        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<CargoCustomer> CargoCustomers { get; set; }
        public DbSet<CargoDetail> CargoDetails { get; set; }
        public DbSet<CargoOperation> CargoOperations { get; set; }
    }
}
