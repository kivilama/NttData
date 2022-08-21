using System.Collections.Generic;

namespace NttDataApi.Models
{
    public class Client : Person
    {
        public string password { get; set; }
        public bool status { get; set; }
        public ICollection<Account> Accounts { get; set; }
    }
}
