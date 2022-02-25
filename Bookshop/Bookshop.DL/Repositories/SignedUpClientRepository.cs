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
    class SignedUpClientRepository : IRepository<SignedUpClient>
    {
        private BookshopContext db;

        public SignedUpClientRepository()
        {
            this.db = new BookshopContext();
        }
        public SignedUpClientRepository(BookshopContext context)
        {
            this.db = context;
        }
        public void Create(SignedUpClient signedUpClient)
        {
            db.SignedUpClients.Add(signedUpClient);
        }
        public void Delete(int id)
        {
            SignedUpClient guestClient = db.SignedUpClients.Find(id);
            if (guestClient != null)
                db.SignedUpClients.Remove(guestClient);
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

        public IEnumerable<SignedUpClient> GetAll()
        {
            return db.SignedUpClients.ToList();
        }

        public SignedUpClient GetItem(int id)
        {
            return db.SignedUpClients.Find(id);
        }

        public void Update(SignedUpClient signedUpClient)
        {
            db.Entry(signedUpClient).State = EntityState.Modified;
        }
    }
}
