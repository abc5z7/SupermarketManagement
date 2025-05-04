using CoreBussiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductsUseCase
    {
        System.Collections.Generic.IEnumerable<Product> Execute();
    }
}