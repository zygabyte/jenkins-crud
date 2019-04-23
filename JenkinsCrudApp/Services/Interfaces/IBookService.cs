using System.Collections.Generic;
using JenkinsCrudApp.Data;

namespace JenkinsCrudApp.Services.Interfaces
{
    public interface IBookService
    {
        bool AddBook(Book book);
        IEnumerable<Book> GetBooks();
        Book GetBook(int bookId);
        bool UpdateBook(Book book, int bookId);
        bool DeleteBook(int bookId);
    }
}