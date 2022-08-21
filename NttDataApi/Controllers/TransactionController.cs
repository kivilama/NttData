using NttDataApi.Dto;
using Microsoft.AspNetCore.Mvc;
using NttDataApi.Interfaces;
using NttDataApi.Models;
using System;
using System.Collections.Generic;

namespace NttDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransactionController : ControllerBase
    {

        private readonly ITransactionService _transactionService;

        public TransactionController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet("{id}")]
        public ActionResult<Transaction> GetTransaction(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);

            if (transaction is null)
            {
                return NotFound();
            }

            return transaction;
        }


        [HttpGet("clientId={clientId},startDate={startDate},endDate={endDate}")]
        public ActionResult<List<TransactionByClient>> GetTransaction(int clientId, DateTime startDate, DateTime endDate)
        {
            var transaction = _transactionService.GetTransactionByClient(clientId, startDate, endDate);

            if (transaction is null)
            {
                return NotFound();
            }

            return transaction;
        }

        [HttpPost]
        public ActionResult<string> CreateTransaction(Transaction transaction)
        {
            string msg;
            try
            {
                msg = _transactionService.CreateTransaction(transaction);
            }
            catch (Exception ex)
            {
                msg = $"La transacción no se ingreso por el siguiente motivo: {ex}";
            }

            return msg;
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public ActionResult<string> UpdateTransaction(int id, Transaction transaction)
        {
            if (id != transaction.Id)
            {
                return BadRequest();
            }
            var exist = _transactionService.GetTransactionById(id);
            string response;
            if (exist is not null)
            {
                response = _transactionService.UpdateTransaction(transaction);
            }
            else
            {
                return NotFound();
            }

            return response;
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteTransaction(int id)
        {
            string response;
            try
            {
                response = _transactionService.DeleteTransaction(id);
            }
            catch (Exception ex)
            {
                response = $"La transacción {id} no pudo ser eliminada por el siguiente motivo: {ex}";
            }
            return response;
        }
    }
}
