using Data.Dto;
using Data.Entities;
using System;
using System.Collections.Generic;

namespace Data.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Transaction GetLastTransactionByAccount(int accountId);
        List<TransactionByClient> GetTransactionsByClient(int clientId, DateTime startDate, DateTime endDate);
    }
}
