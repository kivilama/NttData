using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Transaction
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string TransacctionType { get; set; }
        public decimal Value { get; set; }
        public decimal Balance { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
    }
}

