using NttDataApi.Models;
using NttDataApi.Dto;
using System;
using System.Collections.Generic;

namespace NttDataApi.Interfaces
{
    public interface ITransactionService
    {
        string CreateTransaction(Transaction transaction);
        string DeleteTransaction(int id);
        List<TransactionByClient> GetTransactionByClient(int clientId, DateTime startDate, DateTime endDate);
        Transaction GetTransactionById(int id);
        List<Transaction> GetTransactions();
        string UpdateTransaction(Transaction transaction);
    }
}
