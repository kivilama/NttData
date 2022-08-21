using NttDataApi.Interfaces;
using NttDataApi.Models;
using System;
using System.Collections.Generic;

namespace NttDataApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly ITransactionRepository _transactionRepository;

        public AccountService(IAccountRepository accountRepository, ITransactionRepository transactionRepository)
        {
            _accountRepository = accountRepository;
            _transactionRepository = transactionRepository;
        }

        public string CreateAccount(Account account)
        {
            string response;
            NttDataApi.Entities.Account entity = new NttDataApi.Entities.Account();
            Mapeo(account, entity);
            try
            {
                _accountRepository.Add(entity);
                _accountRepository.DeleteContext();
                NttDataApi.Entities.Transaction transaction = new NttDataApi.Entities.Transaction();
                transaction.AccountId = entity.AccountNumber;
                transaction.Date = DateTime.Now;
                transaction.TransacctionType = "Crédito";
                transaction.Value = entity.InitialBalance;
                transaction.Balance = entity.InitialBalance;
                transaction.AccountId = entity.AccountNumber;
                _transactionRepository.Add(transaction);
                response = $"La cuenta {entity.AccountNumber} fue ingresado correctamente.";

            }
            catch (Exception ex)
            {
                response = $"La cuenta {entity.AccountNumber} no pudo ser creado por el siguiente motivo {ex}";
            }

            return response;
        }

        public string UpdateAccount(Account account)
        {
            string response;
            NttDataApi.Entities.Account entity = new NttDataApi.Entities.Account();
            Mapeo(account, entity);
            try
            {
                _accountRepository.Update(entity);
                response = $"La cuenta {entity.AccountNumber} fue modificado correctamente.";

            }
            catch (Exception ex)
            {
                response = $"La cuenta {entity.AccountNumber} no pudo ser creado por el siguiente motivo {ex}";
            }

            return response;
        }

        public string DeleteAccount(int id)
        {
            string response;
            try
            {
                var exist = _accountRepository.GetById(id);
                _accountRepository.DeleteContext();
                if (exist is not null)
                {
                    _accountRepository.Remove(exist);
                    response = $"La cuenta {exist.AccountNumber} fue eliminada correctamente.";
                }
                else
                {
                    response = $"La cuenta {exist.AccountNumber} no existe.";
                }
            }
            catch (Exception ex)
            {
                response = $"La cuenta {id} no pudo ser eliminada por el siguiente motivo {ex}";
            }

            return response;
        }

        public List<Account> GetAccounts()
        {
            List<Account> response = null;
            try
            {
                var accounts = _accountRepository.GetAll();
                if (accounts is not null)
                {
                    response = new List<Account>();
                    foreach (var item in accounts)
                    {
                        Account c = new Account();
                        MapeoReverso(c, item);
                        response.Add(c);
                    }
                }
            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }

        public Account GetAccountById(int id)
        {
            Account response = null;
            try
            {
                var account = _accountRepository.GetById(id);
                if (account is not null)
                {
                    response = new Account();
                    _accountRepository.DeleteContext();
                    MapeoReverso(response, account);
                }

            }
            catch (Exception)
            {
                response = null;
            }

            return response;
        }

        private static void Mapeo(Account model, NttDataApi.Entities.Account entity)
        {
            entity.AccountNumber = model.AccountNumber;
            entity.AccountType = model.AccountType;
            entity.InitialBalance = model.InitialBalance;
            entity.Status = model.Status;
            entity.ClientId = model.ClientId;
        }

        private void MapeoReverso(Account model, NttDataApi.Entities.Account entity)
        {
            model.AccountNumber = entity.AccountNumber;
            model.AccountType = entity.AccountType;
            model.InitialBalance = entity.InitialBalance;
            model.Status = entity.Status;
            model.ClientId = entity.ClientId;
        }
    }
}
