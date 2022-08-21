using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Entities
{
    public class Account 
    {
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public decimal InitialBalance { get; set; }
        public bool Status { get; set; }
        public int ClientId { get; set; }
        public Client Client { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
