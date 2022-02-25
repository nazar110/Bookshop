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
    class GuestClientRepository : IRepository<GuestClient>
    {
        private BookshopContext db;

        public GuestClientRepository()
        {
            this.db = new BookshopContext();
        }
        public GuestClientRepository(BookshopContext context)
        {
            this.db = context;
        }
        public void Create(GuestClient guestClient)
        {
            db.GuestClients.Add(guestClient);
        }
        public void Delete(int id)
        {
            GuestClient guestClient = db.GuestClients.Find(id);
            if (guestClient != null)
                db.GuestClients.Remove(guestClient);
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

        public IEnumerable<GuestClient> GetAll()
        {
            return db.GuestClients.ToList();
        }

        public GuestClient GetItem(int id)
        {
            return db.GuestClients.Find(id);
        }

        public void Update(GuestClient guestClient)
        {
            db.Entry(guestClient).State = EntityState.Modified;
        }
    }
}
