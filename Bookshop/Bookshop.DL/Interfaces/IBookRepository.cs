using System;
using System.Collections.Generic;
using System.Text;
using Bookshop.DL.Entities;

namespace Bookshop.DL.Interfaces
{
    public interface IBookRepository : IDisposable
    {
        IEnumerable<Book> GetBookList();
        Book GetBook(int id);
        void Create(Book item);
        void Update(Book item);
        void Delete(int id);
        void Save();
    }
}
