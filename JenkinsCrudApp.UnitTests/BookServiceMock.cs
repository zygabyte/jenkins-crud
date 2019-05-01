using System;
using System.Collections.Generic;
using System.Linq;
using JenkinsCrudApp.Data;
using JenkinsCrudApp.Services.Interfaces;

namespace JenkinsCrudApp.UnitTests
{
    public class BookServiceMock : IBookService
    {
        private readonly List<Book> _books = new List<Book>();
        
        public bool AddBook(Book book)
        {
            if (book == null) throw new ArgumentNullException();
            
            var count = _books.Count;
            book.Id = ++count;
            _books.Add(book);
            
            return _books.Count > count - 1;
        }

        public IEnumerable<Book> GetBooks() => _books;

        public Book GetBook(int bookId) => _books.FirstOrDefault(x => x.Id == bookId);

        public bool UpdateBook(int bookId, Book book)
        {
            var currentBook = _books.FirstOrDefault(x => x.Id == bookId);

            if (currentBook == null || book == null) throw new ArgumentNullException();
            if (!_books.Remove(currentBook)) return false;
            
            book.Id = currentBook.Id;
            _books.Add(book);

            return true;
        }

        public bool DeleteBook(int bookId)
        {
            var currentBook = _books.FirstOrDefault(x => x.Id == bookId);

            if (currentBook == null) throw new ArgumentNullException();
            
            return _books.Remove(currentBook);
        }
    }
}