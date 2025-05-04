using CoreBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.InMemory
{
	public class ProductInMemoryRepository: IProductRepository
	{
		private List<Product> products;
		public ProductInMemoryRepository() {
			products = new List<Product>()
			{
				new Product(){ProductId = 1,CategoryId=1, Name = "冰茶",Quantity=100, Price=2},
				new Product(){ProductId = 2,CategoryId=1, Name = "加拿大饮料",Quantity=200, Price=5},
				new Product(){ProductId = 3,CategoryId=2, Name = "法棍",Quantity=200, Price=3.5},
				new Product(){ProductId = 4,CategoryId=2, Name = "白酵母面包",Quantity=300, Price=1.5},

			};
		}

        public void AddProduct(Product product)
        {
			if (products.Any(m => m.Equals(product))) return;
			if (products != null && products.Count > 0)
			{
				var maxId = products.Max(m => m.ProductId);

				product.ProductId = maxId + 1;
			}
			else
			{
				product.ProductId = 1;
			}

			products.Add(product);
        }

        public IEnumerable<Product> GetProducts()
		{
			return products;
		}
	}
}
