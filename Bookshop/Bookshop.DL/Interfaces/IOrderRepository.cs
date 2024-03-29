﻿using Bookshop.DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.DL.Interfaces
{
    public interface IOrderRepository : IDisposable
    {
        IEnumerable<Order> GetOrdersList();
        Order GetOrder(int id);
        void Create(Order item);
        void Update(Order item);
        void Delete(int id);
        void Save();
        void MakeOrder(Book book);
    }
}
