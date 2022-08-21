using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NttDataApi.Contexts
{
    public static class ApiContextInitilizer
    {
        public static void Initialize(ApiContext context)
        {
            context.Database.EnsureCreatedAsync().Wait();
        }
    }
}
