using Microsoft.EntityFrameworkCore;
using System;

namespace WebApplication3.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }

    public class YoutubeDbContext : DbContext
    {
        public YoutubeDbContext(DbContextOptions<YoutubeDbContext> options)
            :base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
    }



    public class Product
    {
        public Product(){
            ProductId = Guid.NewGuid().ToString();
        }
        public string ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
    }
}