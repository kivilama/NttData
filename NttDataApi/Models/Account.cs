using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NttDataApi.Models
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
