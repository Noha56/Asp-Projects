using Assignment2Noha.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment2Noha.Data
{
    public class ClientOrderDBContext : DbContext
    {
        public ClientOrderDBContext(DbContextOptions<ClientOrderDBContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClientOrder>().HasKey(ci => new { ci.ClientId, ci.OrderId });
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientOrder> ClientOrders { get; set; }= default!;
    }
}