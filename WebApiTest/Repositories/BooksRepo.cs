using System;
using System.Collections.Generic;
using System.Linq;
using WebApiTest.Entities;

namespace WebApiTest.Repositories
{

    public class BooksRepo : IBooksRepo
    {
                private readonly List<Book> library = new()
        {
            new Book { id = 1, title = "Chutlu", description = " H.P Lovecraft", Excerpt = " ", PublishDate = DateTime.UtcNow },
            new Book { id = 2, title = "Mechanic bird", description = "unknown", Excerpt = " ",PublishDate = DateTime.UtcNow },
            new Book { id = 3, title = "Mil años de soledad", description = " ", Excerpt = "fantasy",PublishDate = DateTime.UtcNow }
        };
        private int index {get; init;}

        

        public BooksRepo()
        {
            index = Convert.ToInt32(library.Count);
        }

        public IEnumerable<Book> GetBooks()
        {
            return library;
        }

        public Book GetBook(int id)
        {
            return library.Where(Book => Book.id == id).SingleOrDefault();
        }

        public void NewBook(Book book)
        {
            library.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var index = library.FindIndex(BookStock => BookStock.id == book.id);
            library[index]= book;

        }

        public void RemoveBook(int id)
        {
            var index = library.FindIndex(BookStock => BookStock.id ==id);
            library.RemoveAt(index);
        }

        public int getIndex()
        {
            return index;
        }
    }


}