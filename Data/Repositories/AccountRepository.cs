using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
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
