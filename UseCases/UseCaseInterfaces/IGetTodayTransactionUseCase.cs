using CoreBussiness;
using System.Collections.Generic;

namespace UseCases.UseCaseInterfaces
{
    public interface IGetTodayTransactionUseCase
    {
        IEnumerable<Transaction> Execute(string cashierName);
    }
}