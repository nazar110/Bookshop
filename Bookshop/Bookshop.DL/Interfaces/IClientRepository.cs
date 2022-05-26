using Bookshop.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DL.Interfaces
{
    public interface IClientRepository : IDisposable
    {
        IEnumerable<Client> GetSignedUpClients();
        Client GetSignedUpClient(int id);
        void Create(Client item);
        void Update(Client item);
        void Delete(int id);
        void Save();
    }
}
