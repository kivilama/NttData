using Data.Contexts;
using Data.Entities;
using Data.Interfaces;

namespace Data.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(ApiContext context) : base(context)
        {
        }

    }
}
