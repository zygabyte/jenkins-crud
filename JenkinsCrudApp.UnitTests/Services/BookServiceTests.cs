using System;
using System.Collections.Generic;
using System.Linq;
using JenkinsCrudApp.Data;
using JenkinsCrudApp.Services.Interfaces;
using NUnit.Framework;

namespace JenkinsCrudApp.UnitTests.Services
{
    [TestFixture]
    public class BookServiceTests
    {
        private IBookService _bookService;
        private Book _beautyAndTheBeast;
        private Book _gameOfThrones;
        private Book _swordOfTruth;
        
        [SetUp]
        public void SetUp()
        {
            _bookService = new BookServiceMock();
            
            _beautyAndTheBeast = new Book
            {
                Isbn = "LKSA46",
                Title = "Beauty and the beast",
                PublicationDate = DateTime.Now.ToString("yyyy-MM-dd"),
                PublicationPlace = "Abuja",
                AuthorLastName = "James",
                AuthorFirstName = "Doe"
            };
            
            _gameOfThrones = new Book
            {
                Isbn = "KKW43",
                Title = "Game of Thrones",
                PublicationDate = DateTime.Now.ToString("yyyy-MM-dd"),
                PublicationPlace = "UK",
                AuthorLastName = "Jane",
                AuthorFirstName = "White"
            };
            
            _swordOfTruth = new Book
            {
                Isbn = "AASQ22",
                Title = "Sword of Truth",
                PublicationDate = DateTime.Now.ToString("yyyy-MM-dd"),
                PublicationPlace = "US",
                AuthorLastName = "Goodkind",
                AuthorFirstName = "Terry"
            };
        }
        
        [Test]
        public void AddBook_PassValidBook_ReturnsTrue() => Assert.That(_bookService.AddBook(_beautyAndTheBeast), Is.EqualTo(true));
        
        [Test]
        public void AddBook_PassInvalidBook_ThrowsArgumentNullException() => Assert.That(() => _bookService.AddBook(null), Throws.ArgumentNullException);
        
        [Test]
        public void GetBooks_RequestAllBooks_ReturnsAllBooks()
        {
            _bookService.AddBook(_beautyAndTheBeast);
            _bookService.AddBook(_gameOfThrones);
            _bookService.AddBook(_swordOfTruth);
            
            Assert.That(_bookService.GetBooks().Count(), Is.EqualTo(3));
            Assert.That(_bookService.GetBooks(), Is.EqualTo(new  List<Book>{_beautyAndTheBeast, _gameOfThrones, _swordOfTruth}));
        }
        
        [Test]
        public void GetBook_GetABookById_ReturnsBook()
        {
            _bookService.AddBook(_beautyAndTheBeast);
            _bookService.AddBook(_gameOfThrones);
            _bookService.AddBook(_swordOfTruth);
            
            Assert.That(_bookService.GetBook(3), Is.EqualTo(_swordOfTruth));
        }
        
        [Test]
        public void GetBook_GetABookByIdUnknownId_ReturnsNull()
        {
            _bookService.AddBook(_beautyAndTheBeast);
            _bookService.AddBook(_gameOfThrones);
            _bookService.AddBook(_swordOfTruth);
            
            Assert.That(_bookService.GetBook(900), Is.EqualTo(null));
        }
        
        [Test]
        public void UpdateBook_PassValidBookAndId_ReturnTrue()
        {
            _bookService.AddBook(_beautyAndTheBeast);
            _bookService.AddBook(_gameOfThrones);
            _bookService.AddBook(_swordOfTruth);

            var newSwordOfTruth = new Book
            {
                Isbn = "AASQ22",
                Title = "NEW LEGEND OF THE SEEKER",
                PublicationDate = DateTime.Now.ToString("yyyy-MM-dd"),
                PublicationPlace = "US",
                AuthorLastName = "GOOD KIND",
                AuthorFirstName = "TERRY"
            };
            
            Assert.That(_bookService.UpdateBook(_swordOfTruth.Id, newSwordOfTruth), Is.True);
        }
        
        [Test]
        public void UpdateBook_PassInvalidBookAndValidId_ThrowArgumentNullException()
        {
            _bookService.AddBook(_beautyAndTheBeast);
            _bookService.AddBook(_gameOfThrones);
            _bookService.AddBook(_swordOfTruth);

            Assert.That(() => _bookService.UpdateBook(_swordOfTruth.Id, null), Throws.ArgumentNullException);
        }
        
        [Test]
        public void UpdateBook_PassValidBookAndInvalidId_ThrowArgumentNullException()
        {
            _bookService.AddBook(_beautyAndTheBeast);
            _bookService.AddBook(_gameOfThrones);
            _bookService.AddBook(_swordOfTruth);

            var newSwordOfTruth = new Book
            {
                Isbn = "AASQ22",
                Title = "NEW LEGEND OF THE SEEKER",
                PublicationDate = DateTime.Now.ToString("yyyy-MM-dd"),
                PublicationPlace = "US",
                AuthorLastName = "GOOD KIND",
                AuthorFirstName = "TERRY"
            };
            
            Assert.That(() => _bookService.UpdateBook(8000, newSwordOfTruth), Throws.ArgumentNullException);
        }
        
        [Test]
        public void DeleteBook_PassValidId_ReturnTrue()
        {
            _bookService.AddBook(_beautyAndTheBeast);
            _bookService.AddBook(_gameOfThrones);
            _bookService.AddBook(_swordOfTruth);
            
            Assert.That(_bookService.DeleteBook(_swordOfTruth.Id), Is.True);
        }
        
        [Test]
        public void DeleteBook_PassInvalidId_ThrowArgumentNullException()
        {
            _bookService.AddBook(_beautyAndTheBeast);
            _bookService.AddBook(_gameOfThrones);
            _bookService.AddBook(_swordOfTruth);
            
            Assert.That(() => _bookService.DeleteBook(9000), Throws.ArgumentNullException);
        }
    }
}
