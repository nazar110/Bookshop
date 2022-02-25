using Bookshop.DL.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.DL.Interfaces
{
    public interface IUnitOfWork
    {
        public IRepository<Author> Authors { get; }
        public IRepository<AuthorsBooks> AuthorsBooks { get; }
        public IRepository<Book> Books { get; }
        public IRepository<BooksGenres> BooksGenres { get; }
        public IRepository<Genre> Genres { get; }
        public IRepository<Order> Orders { get; }
        public IRepository<ClientInformation> ClientsInformation { get; }
        public IRepository<GuestClient> GuestClients { get; }
        public IRepository<SignedUpClient> SignedUpClients { get; }
        public IRepository<OrderItem> OrderItems { get; }
        public void Save();

    }
}
