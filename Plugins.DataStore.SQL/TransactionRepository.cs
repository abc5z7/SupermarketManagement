using CoreBussiness;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UseCases.DataStorePluginInterfaces;

namespace Plugins.DataStore.SQL
{
	public class TransactionRepository : ITransactionRepository
	{
		private readonly MarketContext db;

		public TransactionRepository(MarketContext db)
        {
			this.db = db;
		}
        public IEnumerable<Transaction> Get(string cashierName)
		{
			return db.Transactions.ToList();
		}

		public IEnumerable<Transaction> GetByDay(string cashierName, DateTime date)
		{
			if (string.IsNullOrEmpty(cashierName))
			{
				return db.Transactions.Where(m => m.TimeStamp.Date == date.Date);
			}
			else
			{
				return db.Transactions.Where(m => m.CashierName == cashierName && m.TimeStamp.Date == date.Date);
			}
		}

		public void Save(string cashierName, int productId, string productName, double price, int beforeQty, int soldQty)
		{
			var transaction = new Transaction()
			{
				ProductId = productId,
				ProductName = productName,
				Price = price,
				BeforeQty = beforeQty,
				SoldQty = soldQty,
				TimeStamp = DateTime.Now,
				CashierName = cashierName,
			};
			db.Transactions.Add(transaction);
			db.SaveChanges();
		}

		public IEnumerable<Transaction> Search(string cashierName, DateTime startDate, DateTime endDate)
		{
			if (string.IsNullOrEmpty(cashierName))
			{
				return db.Transactions.Where(m => m.TimeStamp.Date >= startDate && m.TimeStamp < endDate.AddDays(1).Date);
			}
			else
			{
				return db.Transactions.Where(m => m.CashierName == cashierName && m.TimeStamp.Date >= startDate && m.TimeStamp < endDate.AddDays(1).Date);
			}
		}
	}
}
