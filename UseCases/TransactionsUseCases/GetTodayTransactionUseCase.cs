using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreBussiness;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.TransactionsUseCases
{
    public class GetTodayTransactionUseCase : IGetTodayTransactionUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTodayTransactionUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName)
        {
            return transactionRepository.GetByDay(cashierName, DateTime.Now);
        }
    }
}
