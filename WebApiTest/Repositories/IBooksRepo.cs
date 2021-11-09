using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiTest.Entities;

namespace WebApiTest.Repositories
{
    public interface IBooksRepo
    {
        Book GetBook(int id);
        IEnumerable<Book> GetBooks();

        void NewBook(Book book);

        void UpdateBook(Book book);

        void RemoveBook(int id);

        int getIndex();
    }


}