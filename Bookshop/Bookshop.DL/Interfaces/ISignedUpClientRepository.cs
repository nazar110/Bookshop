using Bookshop.DL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DL.Interfaces
{
    public interface ISignedUpClientRepository : IDisposable
    {
        IEnumerable<SignedUpClient> GetSignedUpClients();
        SignedUpClient GetSignedUpClient(int id);
        void Create(SignedUpClient item);
        void Update(SignedUpClient item);
        void Delete(int id);
        void Save();
    }
}
