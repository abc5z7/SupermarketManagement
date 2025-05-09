using CoreBussiness;
using Microsoft.EntityFrameworkCore;
using System;

namespace Plugins.DataStore.SQL
{
	public class MarketContext:DbContext
	{
        public MarketContext(DbContextOptions options):base(options)
        {
            
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>()
				.HasMany(c => c.Products)
				.WithOne(p => p.Category)
				.HasForeignKey(p => p.CategoryId);

			// 随机数据
			modelBuilder.Entity<Category>().HasData(
				 new Category() { CategoryId = 1, Name = "饮料", Description = "水" },
				new Category() { CategoryId = 2, Name = "烘焙", Description = "豆制品" },
				new Category() { CategoryId = 3, Name = "火腿", Description = "肉类" });
			modelBuilder.Entity<Product>().HasData(
				new Product() { ProductId = 1, CategoryId = 1, Name = "冰茶", Quantity = 100, Price = 2 },
				new Product() { ProductId = 2, CategoryId = 1, Name = "加拿大饮料", Quantity = 200, Price = 5 },
				new Product() { ProductId = 3, CategoryId = 2, Name = "法棍", Quantity = 200, Price = 3.5 },
				new Product() { ProductId = 4, CategoryId = 2, Name = "白酵母面包", Quantity = 300, Price = 1.5 });
		}
	}
}
