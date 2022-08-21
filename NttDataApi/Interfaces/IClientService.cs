using NttDataApi.Models;
using System.Collections.Generic;

namespace NttDataApi.Interfaces
{
    public interface IClientService
    {
        string CreateClient(Client client);
        string DeleteClient(int id);
        Client GetClientById(int id);
        List<Client> GetClients();
        string UpdateClient(Client client);
    }
}
