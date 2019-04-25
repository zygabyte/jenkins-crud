using System.Collections.Generic;
using JenkinsCrudApp.Data;

namespace JenkinsCrudApp.Services.Interfaces
{
    public interface IBookService
    {
        bool AddBook(Book book);
        IEnumerable<Book> GetBooks();
        Book GetBook(int bookId);
        bool UpdateBook(int bookId, Book book);
        bool DeleteBook(int bookId);
    }
}