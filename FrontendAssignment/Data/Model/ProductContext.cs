using Microsoft.EntityFrameworkCore;

namespace FrontendAssignment.Data.Model
{
    public class ProductContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=products.db");
    }

    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string FromPrice { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int TimesViewed { get; set; }
        public string UrlSegment { get; set; }
    }
}