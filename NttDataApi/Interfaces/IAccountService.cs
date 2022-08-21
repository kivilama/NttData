using NttDataApi.Models;

namespace NttDataApi.Interfaces
{
    public interface IAccountService
    {
        string CreateAccount(Account account);
        string DeleteAccount(int id);
        Account GetAccountById(int id);
        string UpdateAccount(Account account);
    }
}
