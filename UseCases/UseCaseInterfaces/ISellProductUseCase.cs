namespace UseCases.UseCaseInterfaces
{
    public interface ISellProductUseCase
    {
        void Execute(string cashierName, int id, int qty);
    }
}