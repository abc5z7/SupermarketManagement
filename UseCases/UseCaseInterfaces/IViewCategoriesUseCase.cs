using CoreBussiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewCategoriesUseCase
    {
        IEnumerable<Category> Execute();
    }
}