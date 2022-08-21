using NttDataApi.Interfaces;
using NttDataApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace NttDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {

        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET: api/Account/5
        [HttpGet("{id}")]
        public ActionResult<Account> GetAccount(int id)
        {
            var account = _accountService.GetAccountById(id);

            if (account is null)
            {
                return NotFound();
            }

            return account;
        }

        [HttpPost]
        public ActionResult<string> CreateAccount(Account account)
        {
            string msg;
            try
            {
                msg = _accountService.CreateAccount(account);
            }
            catch (Exception ex)
            {
                msg = $"La cuenta {account.AccountNumber} no se ingreso por el siguiente motivo: {ex}";
            }

            return msg;
        }

        // PUT: api/Accounts/5
        [HttpPut("{id}")]
        public ActionResult<string> UpdateAccount(int id, Account account)
        {
            if (id != account.AccountNumber)
            {
                return BadRequest();
            }
            var exist = _accountService.GetAccountById(id);
            string response;
            if (exist is not null)
            {
                response = _accountService.UpdateAccount(account);
            }
            else
            {
                return NotFound();
            }

            return response;
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteAccount(int id)
        {
            string response;
            try
            {
                response = _accountService.DeleteAccount(id);
            }
            catch (Exception ex)
            {
                response = $"La cuenta {id} no pudo ser eliminada por el siguiente motivo: {ex}";
            }
            return response;
        }
    }
}
