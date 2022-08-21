using NttDataApi.Interfaces;
using NttDataApi.Interfaces;
using NttDataApi.Models;
using System;
using System.Collections.Generic;
using System.Net;

namespace NttDataApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public List<Client> GetClients()
        {
            List<Client> response = null;
            try
            {
                var clients = _clientRepository.GetAll();
                if (clients is not null)
                {
                    response = new List<Client>();
                    foreach (var item in clients)
                    {
                        Client c = new Client();
                        MapeoReverso(c, item);
                        response.Add(c);
                    }
                }

            }
            catch (Exception ex)
            {
                response = null;
            }
            return response;
        }

        public string CreateClient(Client client)
        {
            string response = string.Empty;
            NttDataApi.Entities.Client entity = new NttDataApi.Entities.Client();
            client.ClientId = 0;
            Mapeo(client, entity);
            try
            {
                _clientRepository.Add(entity);
                response = $"El cliente  {entity.ClientId}-{entity.Name} fue ingresado correctamente.";

            }
            catch (Exception ex)
            {
                response = $"El cliente {entity.Name} no pudo ser creado por el siguiente motivo {ex}";
            }

            return response;
        }

        public string UpdateClient(Client client)
        {
            string response = string.Empty;
            NttDataApi.Entities.Client entity = new NttDataApi.Entities.Client();
            Mapeo(client, entity);
            try
            {
                _clientRepository.Update(entity);
                response = $"El cliente  {entity.ClientId}-{entity.Name} fue modificado correctamente.";

            }
            catch (Exception ex)
            {
                response = $"El cliente {entity.Name} no pudo ser creado por el siguiente motivo {ex}";
            }

            return response;
        }

        public string DeleteClient(int id)
        {
            string response = string.Empty;
            try
            {
                var exist = _clientRepository.GetById(id);
                _clientRepository.DeleteContext();
                if (exist is not null)
                {
                    _clientRepository.Remove(exist);
                    response = $"El cliente  {exist.ClientId}-{exist.Name} fue eliminado correctamente.";
                }
                else
                {
                    response = $"El cliente  {id} no existe.";
                }
            }
            catch (Exception ex)
            {
                response = $"El cliente {id} no pudo ser eliminado por el siguiente motivo {ex}";
            }

            return response;
        }

        public Client GetClientById(int id)
        {
            Client response = null;
            try
            {
                var client = _clientRepository.GetById(id);
                if (client is not null)
                {
                    response = new Client();
                    MapeoReverso(response, client);
                }

            }
            catch (Exception ex)
            {
                response = null;
                var friendlyMessage = "Lamentamos los inconvenientes, por favor intente de nuevo.";
                var httpStatusCode = (int)HttpStatusCode.InternalServerError;
                throw new HttpException(ex.Message, friendlyMessage, httpStatusCode, ex.InnerException);
            }
            return response;
        }

        private void Mapeo(Client model, NttDataApi.Entities.Client entity)
        {
            entity.ClientId = model.ClientId;
            entity.Name = model.Name;
            entity.Gender = model.Gender;
            entity.Age = model.Age;
            entity.Identification = model.Identification;
            entity.Address = model.Address;
            entity.PhoneNumber = model.PhoneNumber;
            entity.password = model.password;
            entity.status = model.status;
        }
        private void MapeoReverso(Client model, NttDataApi.Entities.Client entity)
        {
            model.ClientId = entity.ClientId;
            model.Name = entity.Name;
            model.Gender = entity.Gender;
            model.Age = entity.Age;
            model.Identification = entity.Identification;
            model.Address = entity.Address;
            model.PhoneNumber = entity.PhoneNumber;
            model.password = entity.password;
            model.status = entity.status;
        }
    }
}
