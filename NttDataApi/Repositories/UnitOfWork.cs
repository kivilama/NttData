using NttDataApi.Contexts;
using NttDataApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataApi.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApiContext _context;
        public UnitOfWork(ApiContext context)
        {
            _context = context;
            Clients = new ClientRepository(_context);
            Accounts = new AccountRepository(_context);
            Transactions = new TransactionRepository(_context);
        }

        public IClientRepository Clients { get; private set; }

        public IAccountRepository Accounts { get; private set; }

        public ITransactionRepository Transactions { get; private set; }

        public int Complete()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
