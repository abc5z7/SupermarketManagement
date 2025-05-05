using CoreBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.ProductsUseCases
{
    public class GetProductByIdUseCase : IGetProductByIdUseCase
    {
        private readonly IProductRepository productRepository;

        public GetProductByIdUseCase(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        public Product Execute(int Id)
        {
            return productRepository.GetProductById(Id);
        }
    }
}
