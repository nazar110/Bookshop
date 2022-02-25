using Bookshop.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DL.Interfaces
{
    public interface IGuestClientRepository : IDisposable
    {
        IEnumerable<GuestClient> GetGuestClients();
        GuestClient GetGuestClient(int id);
        void Create(GuestClient item);
        void Update(GuestClient item);
        void Delete(int id);
        void Save();
    }
}
