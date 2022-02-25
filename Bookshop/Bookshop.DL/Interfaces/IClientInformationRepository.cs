using Bookshop.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DL.Interfaces
{
    public interface IClientInformationRepository : IDisposable
    {
        IEnumerable<ClientInformation> GetClientsInformation();
        ClientInformation GetClientInformation(int id);
        void Create(ClientInformation item);
        void Update(ClientInformation item);
        void Delete(int id);
        void Save();
    }
}
