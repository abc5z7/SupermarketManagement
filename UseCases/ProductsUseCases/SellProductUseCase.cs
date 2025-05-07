using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class SellProductUseCase : ISellProductUseCase
    {
        private readonly IProductRepository productRepository;
		private readonly IRecordTransactionUseCase recordTransactionUseCase;

		public SellProductUseCase(IProductRepository productRepository
            , IRecordTransactionUseCase recordTransactionUseCase)
        {
            this.productRepository = productRepository;
			this.recordTransactionUseCase = recordTransactionUseCase;
		}
        public void Execute(string cashierName, int id, int qty)
        {
            var product = productRepository.GetProductById(id);
            if (product == null) return;

			recordTransactionUseCase.Execute(cashierName, id, product.Name, qty);
			product.Quantity -= qty;
            productRepository.UpdateProduct(product);
        }
    }
}
