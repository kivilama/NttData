using Microsoft.AspNetCore.Mvc;
using NttDataApi.Interfaces;
using NttDataApi.Models;
using System;
using System.Collections.Generic;

namespace NttDataApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService)
        {
            _clientService = clientService;
        }

        // GET: api/Client
        [HttpGet]
        public ActionResult<IEnumerable<Client>> GetClients()
        {
            return _clientService.GetClients();
        }


        // GET: api/Client/5
        [HttpGet("{id}")]
        public ActionResult<Client> GetClient(int id)
        {
            var client = _clientService.GetClientById(id);

            if (client is null)
            {
                return NotFound();
            }

            return client;
        }

        [HttpPost]
        public ActionResult<string> CreateClient(Client client)
        {
            string msg;
            try
            {
                msg = _clientService.CreateClient(client);
            }
            catch (Exception ex)
            {
                msg = $"El cliente {client.Name} no se ingreso por el siguiente motivo: {ex}";
            }

            return msg;
        }

        // PUT: api/Clients/5
        [HttpPut("{id}")]
        public ActionResult<string> UpdateClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }
            var exist = _clientService.GetClientById(id);
            string response;
            if (exist is not null)
            {
                response = _clientService.UpdateClient(client);
            }
            else
            {
                return NotFound();
            }

            return response;
        }

        // DELETE: api/TodoItems/5
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteClient(int id)
        {
            string response;
            try
            {
                response = _clientService.DeleteClient(id);
            }
            catch (Exception ex)
            {
                response = $"El cliente {id} no pudo ser eliminado por el siguiente motivo: {ex}";
            }
            return response;
        }
    }
}
