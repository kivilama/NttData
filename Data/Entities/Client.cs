using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Client : Person
    {
        public string password { get; set; }
        public bool status { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
