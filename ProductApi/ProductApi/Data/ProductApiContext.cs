using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.Data
{
    public class ProductApiContext : DbContext
    {
        public ProductApiContext (DbContextOptions<ProductApiContext> options)
            : base(options)
        {
        }

        public DbSet<ProductApi.Models.Product> Product { get; set; } = default!;
    }
}
