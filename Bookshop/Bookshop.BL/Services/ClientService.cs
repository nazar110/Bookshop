using Bookshop.BL.DTOs;
using Bookshop.DL.EF;
using Bookshop.DL.Entities;
using Bookshop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.BL.Services
{
    public class ClientService
    {
        private readonly IUnitOfWork _uow;
        public ClientService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        /// <returns>
        /// ID of added client
        /// </returns>
        public int? SignUp(ClientCreateDto client)
        {
            Client signedUpClient = new Client()
            {
                Name = client.Name,
                Surname = client.Surname,
                Email = client.Email,
                Number = client.Number,
                Password = client.Password,
            };
            _uow.Clients.Create(signedUpClient);
            _uow.Save();

            int? idOfAddedClient = _uow.Clients.GetAll().Last()?.ID;
            return idOfAddedClient;
        }
        public bool SignIn(ClientCreateDto client)
        {
            return true;
        }
        public void SignOut(ClientCreateDto client)
        {

        }
        public void Remove(ClientCreateDto client)
        {

        }
        public void ChangePassword(ClientCreateDto client)
        {

        }
    }
}
