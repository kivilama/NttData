using NttDataApi.Interfaces;
using NttDataApi.Dto;
using NttDataApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;

namespace NttDataApi.Services
{
    public class TransactionService : ITransactionService
    {

        private readonly ITransactionRepository _transactionRepository;


        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public string CreateTransaction(Models.Transaction transaction)
        {
            string response;
            try
            {
                var lastTransaction = _transactionRepository.GetLastTransactionByAccount(transaction.AccountId);
                _transactionRepository.DeleteContext();
                if (transaction is not null)
                {
                    _transactionRepository.DeleteContext();
                    if (transaction.TransacctionType == "Débito")
                    {
                        transaction.Balance = lastTransaction.Balance - transaction.Value;
                    }
                    else
                    {
                        transaction.Balance = lastTransaction.Balance + transaction.Value;
                    }
                    if (transaction.Balance < 0)
                    {
                        return $"La cuenta no dispone el saldo para realizar la transacción.";
                    }
                    NttDataApi.Entities.Transaction entity = new NttDataApi.Entities.Transaction();
                    Mapeo(transaction, entity);
                    try
                    {
                        _transactionRepository.Add(entity);
                        response = $"La transacción {entity.Id} fue ingresado correctamente.";

                    }
                    catch (Exception ex)
                    {
                        response = $"La transacción no pudo ser creado por el siguiente motivo {ex}";
                    }
                }
                else
                {
                    response = $"La cuenta {transaction.AccountId} no existe.";
                }
            }
            catch (Exception ex)
            {
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }

            return response;
        }

        public string UpdateTransaction(Models.Transaction transaction)
        {
            string response;
            NttDataApi.Entities.Transaction entity = new NttDataApi.Entities.Transaction();
            Mapeo(transaction, entity);
            try
            {
                _transactionRepository.Update(entity);
                response = $"La transacción {entity.Id} fue modificado correctamente.";

            }
            catch (HttpException httpEx)
            {
                response = $"La transacción {entity.Id} no pudo ser creado por el siguiente motivo: {httpEx.FriendlyMessage}.";
                Console.WriteLine(httpEx);
            }
            catch (Exception ex)
            {
                response = $"La transacción {entity.Id} no pudo ser creado por el siguiente motivo {ex}";
            }

            return response;
        }

        public string DeleteTransaction(int id)
        {
            string response;
            try
            {
                var exist = _transactionRepository.GetById(id);
                _transactionRepository.DeleteContext();
                if (exist is not null)
                {
                    _transactionRepository.Remove(exist);
                    response = $"La transacción {exist.Id} fue eliminada correctamente.";
                }
                else
                {
                    response = $"La transacción {exist.Id} no existe.";
                }
            }
            catch (HttpException httpEx)
            {
                response = $"La transacción {id} no pudo ser eliminada por el siguiente motivo: {httpEx.FriendlyMessage}.";
            }
            catch (Exception ex)
            {
                response = $"La transacción {id} no pudo ser eliminada por el siguiente motivo {ex}";
            }

            return response;
        }

        public List<Models.Transaction> GetTransactions()
        {
            List<Models.Transaction> response = null;
            try
            {
                var transactions = _transactionRepository.GetAll();
                if (transactions is not null)
                {
                    response = new List<Models.Transaction>();
                    foreach (var item in transactions)
                    {
                        Models.Transaction c = new Models.Transaction();
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

        public Models.Transaction GetTransactionById(int id)
        {
            Models.Transaction response = null;
            try
            {
                var transaction = _transactionRepository.GetById(id);
                if (transaction is not null)
                {
                    response = new Models.Transaction();
                    _transactionRepository.DeleteContext();
                    MapeoReverso(response, transaction);
                }
            }
            catch (Exception)
            {
                response = null;
            }

            return response;
        }

        public List<TransactionByClient> GetTransactionByClient(int clientId, DateTime startDate, DateTime endDate)
        {
            try
            {
                return _transactionRepository.GetTransactionsByClient(clientId, startDate, endDate);
            }
            catch (Exception)
            {
                return null;
            }
        }

        private static void Mapeo(Models.Transaction model, NttDataApi.Entities.Transaction entity)
        {
            entity.Id = model.Id;
            entity.Date = model.Date;
            entity.TransacctionType = model.TransacctionType;
            entity.Value = model.Value;
            entity.Balance = model.Balance;
            entity.AccountId = model.AccountId;
        }

        private void MapeoReverso(Models.Transaction model, NttDataApi.Entities.Transaction entity)
        {
            model.Id = entity.Id;
            model.Date = entity.Date;
            model.TransacctionType = entity.TransacctionType;
            model.Balance = entity.Balance;
            model.Value = entity.Value;
            model.AccountId = entity.AccountId;
        }
    }
}
