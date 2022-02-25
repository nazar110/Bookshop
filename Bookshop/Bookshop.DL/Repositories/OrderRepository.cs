using Bookshop.DL.EF;
using Bookshop.DL.Entities;
using Bookshop.DL.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookshop.DL.Repositories
{
    public class OrderRepository : IRepository<Order>
    {
        private BookshopContext db;

        public OrderRepository()
        {
            this.db = new BookshopContext();
        }
        public OrderRepository(BookshopContext context)
        {
            this.db = context;
        }
        public void Create(Order order)
        {
            db.Orders.Add(order);
        }
        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order);
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

        public IEnumerable<Order> GetAll()
        {
            return db.Orders.ToList();
        }

        public Order GetItem(int id)
        {
            return db.Orders.Find(id);
        }

        public void Update(Order item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
