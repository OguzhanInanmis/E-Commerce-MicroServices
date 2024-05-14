using E_Commerce.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Order.Persistence.Context
{
    public class OrderContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1440;initial catalog=E-CommerceOrderDb;user=sa;password=123456aA*;TrustServerCertificate=True");
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Ordering> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
    }
}
