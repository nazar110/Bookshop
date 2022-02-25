using Bookshop.DL.EF;
using Bookshop.DL.Entities;
using Bookshop.DL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookshop.DL.Repositories
{
    class ClientInformationRepository : IRepository<ClientInformation>
    {
        private BookshopContext db;

        public ClientInformationRepository()
        {
            this.db = new BookshopContext();
        }
        public ClientInformationRepository(BookshopContext context)
        {
            this.db = context;
        }
        public void Create(ClientInformation clientInformation)
        {
            db.ClientsInformation.Add(clientInformation);
        }
        public void Delete(int id)
        {
            ClientInformation clientInformation = db.ClientsInformation.Find(id);
            if (clientInformation != null)
                db.ClientsInformation.Remove(clientInformation);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<ClientInformation> GetAll()
        {
            return db.ClientsInformation.ToList();
        }

        public ClientInformation GetItem(int id)
        {
            return db.ClientsInformation.Find(id);
        }

        public void Update(ClientInformation clientInformation)
        {
            db.Entry(clientInformation).State = EntityState.Modified;
        }
    }
}
