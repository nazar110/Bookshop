using Bookshop.DL.EF;
using Bookshop.DL.Entities;
using Bookshop.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookshop.DL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private BookshopContext db = new BookshopContext();
        private AuthorRepository authorRepository;
        private AuthorsBooksRepository authorsBooksRepository;
        private BookRepository bookRepository;
        private BooksGenresRepository booksGenresRepository;
        private GenreRepository genreRepository;
        private OrderRepository orderRepository;
        private OrderItemRepository orderItemRepository;
        private ClientInformationRepository clientInformationRepository;
        private GuestClientRepository guestClientRepository;
        private SignedUpClientRepository signedUpClientRepository;
        
        public IRepository<Author> Authors
        {
            get
            {
                if (authorRepository == null)
                    authorRepository = new AuthorRepository(db);
                return authorRepository;
            }
        }
        public IRepository<AuthorsBooks> AuthorsBooks
        {
            get
            {
                if (authorsBooksRepository == null)
                    authorsBooksRepository = new AuthorsBooksRepository(db);
                return authorsBooksRepository;
            }
        }
        public IRepository<Book> Books
        {
            get
            {
                if (bookRepository == null)
                    bookRepository = new BookRepository(db);
                return bookRepository;
            }
        }
        public IRepository<BooksGenres> BooksGenres
        {
            get
            {
                if (booksGenresRepository == null)
                    booksGenresRepository = new BooksGenresRepository(db);
                return booksGenresRepository;
            }
        }
        public IRepository<Genre> Genres
        {
            get
            {
                if (genreRepository == null)
                    genreRepository = new GenreRepository(db);
                return genreRepository;
            }
        }
        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }
        public IRepository<OrderItem> OrderItems
        {
            get
            {
                if (orderItemRepository == null)
                    orderItemRepository = new OrderItemRepository(db);
                return orderItemRepository;
            }
        }

        public IRepository<ClientInformation> ClientsInformation
        {
            get
            {
                if (clientInformationRepository == null)
                    clientInformationRepository = new ClientInformationRepository(db);
                return clientInformationRepository;
            }
        }

        public IRepository<GuestClient> GuestClients
        {
            get
            {
                if (guestClientRepository == null)
                    guestClientRepository = new GuestClientRepository(db);
                return guestClientRepository;
            }
        }

        public IRepository<SignedUpClient> SignedUpClients
        {
            get
            {
                if (signedUpClientRepository == null)
                    signedUpClientRepository = new SignedUpClientRepository(db);
                return signedUpClientRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
