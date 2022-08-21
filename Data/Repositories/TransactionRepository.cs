using Data.Contexts;
using Data.Dto;
using Data.Entities;
using Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class TransactionRepository : GenericRepository<Transaction>, ITransactionRepository
    {
        public TransactionRepository(ApiContext context) : base(context)
        {
        }

        public Transaction GetLastTransactionByAccount(int accountId) => _context.Set<Transaction>().Where(a => a.AccountId == accountId)
                .OrderByDescending(a => a.Id).FirstOrDefault();

        public List<TransactionByClient> GetTransactionsByClient(int clientId, DateTime startDate, DateTime endDate) {
            var x = (from c in _context.Clients
                     join a in _context.Accounts on c.ClientId equals a.ClientId
                     join t in _context.Transactions on a.AccountNumber equals t.AccountId
                     where c.ClientId == clientId &&
                     (t.Date >= startDate && t.Date <= endDate)
                     select (new TransactionByClient()
                     {
                         ClientId = c.ClientId,
                         AccountNumber = a.AccountNumber,
                         AccountType = a.AccountType,
                         Status = a.Status,
                         Date = t.Date,
                         TransactionType = t.TransacctionType,
                         Value = t.Value,
                         Balance = t.Balance
                     })).OrderByDescending(a => a.AccountNumber).ToList();
            return x;
        }
    }
}
