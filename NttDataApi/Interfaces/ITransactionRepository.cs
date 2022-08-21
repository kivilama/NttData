using NttDataApi.Dto;
using NttDataApi.Entities;
using System;
using System.Collections.Generic;

namespace NttDataApi.Interfaces
{
    public interface ITransactionRepository : IGenericRepository<Transaction>
    {
        Transaction GetLastTransactionByAccount(int accountId);
        List<TransactionByClient> GetTransactionsByClient(int clientId, DateTime startDate, DateTime endDate);
    }
}
