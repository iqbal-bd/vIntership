using InventoryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagementSystem.Data
{
    public class ApplicationContext:DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }
        public DbSet<Header> Purchase { get; set; }
        public DbSet<Detail> PurchaseDetails { get; set; }
    }
}
