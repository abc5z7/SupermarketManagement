using CoreBussiness;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
	public class ProductRepository:IProductRepository
	{
		private readonly MarketContext db;

		public ProductRepository(MarketContext db)
        {
			this.db = db;
		}

		public void AddProduct(Product product)
		{
			db.Products.Add(product);
			db.SaveChanges();
		}

		public void DeleteProduct(int id)
		{
			var product = db.Products.Find(id);
			if (product == null) return;

			db.Products.Remove(product);
			db.SaveChanges();
		}

		public IEnumerable<Product> GetProductByCategoryId(int id)
		{
			return db.Products.Where(m => m.CategoryId == id).ToList();
		}

		public Product GetProductById(int productId)
		{
			return db.Products.Find(productId);
		}

		public IEnumerable<Product> GetProducts()
		{
			return db.Products.ToList();
		}

		public void UpdateProduct(Product product)
		{
			var prod = db.Products.Find(product.ProductId);
			prod.CategoryId = product.CategoryId;
			prod.Name = product.Name;
			prod.Price = product.Price;
			prod.Quantity = product.Quantity;
			db.SaveChanges();
		}
	}
}
