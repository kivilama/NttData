using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NttDataApi.Models
{
    public class Person
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string Identification { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

    }
}
