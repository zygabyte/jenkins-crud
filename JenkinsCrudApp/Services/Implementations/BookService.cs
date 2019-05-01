using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using JenkinsCrudApp.Data;
using JenkinsCrudApp.Services.Interfaces;

namespace JenkinsCrudApp.Services.Implementations
{
    public class BookService : IBookService
    {
        public bool AddBook(Book book)
        {
            try
            {
                using (var jenkinsContext = new JenkinsCrudContext())
                {
                    jenkinsContext.Books.Add(book);

                    return jenkinsContext.SaveChanges() > 0;
                }
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public IEnumerable<Book> GetBooks() => new JenkinsCrudContext().Books.Where(x => !x.IsDeleted).ToList();

        public Book GetBook(int bookId) => new JenkinsCrudContext().Books.FirstOrDefault(x => !x.IsDeleted && x.Id == bookId);

        public bool UpdateBook(int bookId, Book book)
        {
            try
            {
                using (var jenkinsContext = new JenkinsCrudContext())
                {
                    var currentBook = jenkinsContext.Books.FirstOrDefault(x => !x.IsDeleted && x.Id == bookId);

                    if (currentBook == null) return false;
                    
                    currentBook.Isbn = book.Isbn;
                    currentBook.PublicationDate = book.PublicationDate;
                    currentBook.PublicationPlace = book.PublicationPlace;
                    currentBook.Title = book.Title;
                    currentBook.AuthorFirstName = book.AuthorFirstName;
                    currentBook.AuthorLastName = book.AuthorLastName;

                    jenkinsContext.Entry(currentBook).State = EntityState.Modified;

                    return jenkinsContext.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool DeleteBook(int bookId)
        {
            try
            {
                using (var jenkinsContext = new JenkinsCrudContext())
                {
                    var currentBook = jenkinsContext.Books.FirstOrDefault(x => x.Id == bookId);

                    if (currentBook == null) return false;
                    
                    currentBook.IsDeleted = true;

                    jenkinsContext.Entry(currentBook).State = EntityState.Modified;

                    return jenkinsContext.SaveChanges() > 0;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}