using NttDataApi.Contexts;
using NttDataApi.Entities;
using NttDataApi.Interfaces;

namespace NttDataApi.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ApiContext context) : base(context)
        {
        }

    }
}
