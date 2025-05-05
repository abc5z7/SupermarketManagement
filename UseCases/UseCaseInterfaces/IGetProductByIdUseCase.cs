using CoreBussiness;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetProductByIdUseCase
    {
        Product Execute(int Id);
    }
}