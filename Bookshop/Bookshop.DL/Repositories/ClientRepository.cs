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
    class ClientRepository : IRepository<Client>
    {
        private BookshopContext db;

        public ClientRepository()
        {
            this.db = new BookshopContext();
        }
        public ClientRepository(BookshopContext context)
        {
            this.db = context;
        }
        public void Create(Client client)
        {
            db.Clients.Add(client);
        }
        public void Delete(int id)
        {
            Client guestClient = db.Clients.Find(id);
            if (guestClient != null)
                db.Clients.Remove(guestClient);
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

        public IEnumerable<Client> GetAll()
        {
            return db.Clients.ToList();
        }

        public Client GetItem(int id)
        {
            return db.Clients.Find(id);
        }

        public void Update(Client client)
        {
            db.Entry(client).State = EntityState.Modified;
        }
    }
}
