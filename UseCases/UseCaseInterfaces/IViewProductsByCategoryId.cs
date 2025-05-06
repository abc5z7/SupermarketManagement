using CoreBussiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IViewProductsByCategoryId
    {
        IEnumerable<Product> Execute(int id);
    }
}