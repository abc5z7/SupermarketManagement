using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;
using CoreBussiness;

namespace Plugins.DataStore.InMemory
{
	public class TransactionInMemoryRepository : ITransactionRepository
	{
		private List<Transaction> transactions;

        public TransactionInMemoryRepository()
        {
			transactions = new List<Transaction>();
        }

		public IEnumerable<Transaction> Get(string cashierName)
		{
			if (string.IsNullOrEmpty(cashierName))
			{
				return transactions;
			}
			else
			{
				return transactions.Where(m => string.Equals(m.CashierName, cashierName));
			}
		}

		public IEnumerable<Transaction> GetByDay(string cashierName,DateTime date)
		{
			if (string.IsNullOrEmpty(cashierName))
			{
				return transactions.Where(m => m.TimeStamp.Date == date.Date);
			}
			else
			{
				return transactions.Where(m => string.Equals(m.CashierName, cashierName) && m.TimeStamp.Date == date.Date);
			}
		}

		public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
		{
			int transactionId = 0;
			if (transactions != null && transactions.Count > 0)
			{
				int maxId = transactions.Max(m => m.ProductId);
				transactionId = maxId + 1;	
			}
			else
			{
				transactionId = 1;
			}

			transactions.Add(new Transaction()
			{
				TransactionId = transactionId,
				ProductId = productId,
				ProductName	= productName,
				TimeStamp = DateTime.Now,
				Price = price,
				BeforeQty = beforeQty,
				SoldQty = soldQty,
				CashierName = cashierName,
			});
		}
	}
}
