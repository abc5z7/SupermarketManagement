﻿using CoreBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using UseCases.UseCaseInterfaces;

namespace UseCases.TransactionsUseCases
{
    public class GetTransactionsUseCase : IGetTransactionsUseCase
    {
        private readonly ITransactionRepository transactionRepository;

        public GetTransactionsUseCase(ITransactionRepository transactionRepository)
        {
            this.transactionRepository = transactionRepository;
        }
        public IEnumerable<Transaction> Execute(string cashierName,
            DateTime startDate, DateTime endDate)
        {
            return transactionRepository.Search(cashierName, startDate, endDate);
        }
    }
}
