using NttDataApi.Contexts;
using NttDataApi.Entities;
using NttDataApi.Interfaces;

namespace NttDataApi.Repositories
{
    public class AccountRepository : GenericRepository<Account>, IAccountRepository
    {
        public AccountRepository(ApiContext context) : base(context)
        {
        }

        public Account CreateAccount(Account account) {
            //_context.Database.sql("SET IDENTITY_INSERT [dbo].[User] ON");

            _context.Accounts.Add(account);
            return account;
        }
    }
}
