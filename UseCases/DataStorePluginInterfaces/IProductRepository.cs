﻿using CoreBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UseCases.DataStorePluginInterfaces
{
	public interface IProductRepository
	{
		public IEnumerable<Product> GetProducts();

		void AddProduct(Product product);

		void UpdateProduct(Product product);
		Product GetProductById(int productId);
		void DeleteProduct(int id);
		IEnumerable<Product> GetProductByCategoryId(int id);
	}
}
