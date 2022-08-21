using Microsoft.EntityFrameworkCore;
using System;

namespace Data.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientRepository Clients { get; }
        IAccountRepository Accounts { get; }
        ITransactionRepository Transactions { get; }

        int Complete();
    }
}
