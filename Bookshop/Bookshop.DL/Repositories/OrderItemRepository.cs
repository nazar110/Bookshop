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
    public class OrderItemRepository : IRepository<OrderItem>
    {
        private BookshopContext db;

        public OrderItemRepository()
        {
            this.db = new BookshopContext();
        }
        public OrderItemRepository(BookshopContext context)
        {
            this.db = context;
        }
        public void Create(OrderItem item)
        {
            db.OrderItems.Add(item);
        }

        public void Delete(int id)
        {
            var orderItem = db.OrderItems.Find(id);
            if (orderItem != null)
                db.OrderItems.Remove(orderItem);
        }

        public OrderItem GetItem(int id)
        {
            return db.OrderItems.Find(id);
        }

        public IEnumerable<OrderItem> GetAll()
        {
            return db.OrderItems.ToList();
        }
        public void Update(OrderItem item)
        {
            db.Entry(item).State = EntityState.Modified;
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
    }
}
