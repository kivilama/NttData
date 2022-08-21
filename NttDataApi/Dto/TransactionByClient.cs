using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataApi.Dto
{
    public class TransactionByClient
    {
        public int ClientId { get; set; }
        public int AccountNumber { get; set; }
        public string AccountType { get; set; }
        public bool Status { get; set; }
        public DateTime Date { get; set; }
        public string TransactionType { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
    }
}
