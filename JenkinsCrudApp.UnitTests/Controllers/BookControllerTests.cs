using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JenkinsCrudApp.Controllers;
using JenkinsCrudApp.Data;
using JenkinsCrudApp.Models;
using NUnit.Framework;

namespace JenkinsCrudApp.UnitTests.Controllers
{
    [TestFixture]
    public class BookControllerTests
    {
        private BookController _bookController;
        private Book _beautyAndTheBeast;
        private Book _gameOfThrones;
        private Book _swordOfTruth;
        
        [SetUp]
        public void SetUp()
        {
            _bookController = new BookController(new BookServiceMock());
            
            _beautyAndTheBeast = new Book
            {
                Isbn = "LKSA46",
                Title = "Beauty and the beast",
                PublicationDate = DateTime.Now,
                PublicationPlace = "Abuja",
                AuthorLastName = "James",
                AuthorFirstName = "Doe"
            };
            
            _gameOfThrones = new Book
            {
                Isbn = "KKW43",
                Title = "Game of Thrones",
                PublicationDate = DateTime.Now,
                PublicationPlace = "UK",
                AuthorLastName = "Jane",
                AuthorFirstName = "White"
            };
            
            _swordOfTruth = new Book
            {
                Isbn = "AASQ22",
                Title = "Sword of Truth",
                PublicationDate = DateTime.Now,
                PublicationPlace = "US",
                AuthorLastName = "Goodkind",
                AuthorFirstName = "Terry"
            };
        }
        
        [Test]
        public void CreateBook_ValidBook_ReturnResponseDataWithTrue()
        {
            var response = _bookController.CreateBook(_beautyAndTheBeast);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.True);
            Assert.That(responseData.Message, Does.Contain("Successfully created"));
        }
        
        [Test]
        public void CreateBook_InvalidBook_ReturnResponseDataWithFalse()
        {
            var response = _bookController.CreateBook(null);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.False);
            Assert.That(responseData.Message, Does.Contain("is null"));
        }
        
        [Test]
        public void ReadBooks_RequestBooks_ReturnResponseDataWithAllBooks()
        {
            _bookController.CreateBook(_beautyAndTheBeast);
            _bookController.CreateBook(_gameOfThrones);
            _bookController.CreateBook(_swordOfTruth);

            var response = _bookController.ReadBooks();
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.True);
            Assert.That(((IEnumerable<BookVm>)responseData.Data).Count(), Is.EqualTo(3));
        }
        
        [Test]
        public void ReadBooks_RequestEmptyBooks_ReturnResponseDataWithNoBook()
        {
            var response = _bookController.ReadBooks();
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.True);
            Assert.That(((IEnumerable<BookVm>)responseData.Data).Count(), Is.EqualTo(0));
        }
        
        [Test]
        public void ReadBook_RequestBookWithValidId_ReturnResponseDataBook()
        {
            _bookController.CreateBook(_beautyAndTheBeast);
            _bookController.CreateBook(_gameOfThrones);
            _bookController.CreateBook(_swordOfTruth);

            var response = _bookController.ReadBook(1);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.True);
            Assert.That(responseData.Data, Is.EqualTo(_beautyAndTheBeast));
        }
        
        [Test]
        public void ReadBook_RequestBookWithInvalidId_ReturnResponseDataNullBook()
        {
            _bookController.CreateBook(_beautyAndTheBeast);
            _bookController.CreateBook(_gameOfThrones);
            _bookController.CreateBook(_swordOfTruth);

            var response = _bookController.ReadBook(9999);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.True);
            Assert.That(responseData.Data, Is.EqualTo(null));
        }
        
        [Test]
        public void UpdateBook_BookWithValidIdAndValidBook_ReturnResponseStatusWithTrue()
        {
            _bookController.CreateBook(_beautyAndTheBeast);
            _bookController.CreateBook(_gameOfThrones);
            _bookController.CreateBook(_swordOfTruth);
            
            var newSwordOfTruth = new Book
            {
                Isbn = "AASQ22",
                Title = "NEW LEGEND OF THE SEEKER",
                PublicationDate = DateTime.Now,
                PublicationPlace = "US",
                AuthorLastName = "GOOD KIND",
                AuthorFirstName = "TERRY"
            };

            var response = _bookController.UpdateBook(_swordOfTruth.Id, newSwordOfTruth);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.True);
            Assert.That(responseData.Message, Does.Contain("Successfully updated"));
        }
        
        [Test]
        public void UpdateBook_BookWithInvalidIdAndValidBook_ReturnMessageWithError()
        {
            _bookController.CreateBook(_beautyAndTheBeast);
            _bookController.CreateBook(_gameOfThrones);
            _bookController.CreateBook(_swordOfTruth);
            
            var newSwordOfTruth = new Book
            {
                Isbn = "AASQ22",
                Title = "NEW LEGEND OF THE SEEKER",
                PublicationDate = DateTime.Now,
                PublicationPlace = "US",
                AuthorLastName = "GOOD KIND",
                AuthorFirstName = "TERRY"
            };

            var response = _bookController.UpdateBook(9999, newSwordOfTruth);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.False);
            Assert.That(responseData.Message, Does.Contain("Error in updating"));
        }
        
        [Test]
        public void UpdateBook_BookWithValidIdAndInvalidBook_ReturnMessageWithError()
        {
            _bookController.CreateBook(_beautyAndTheBeast);
            _bookController.CreateBook(_gameOfThrones);
            _bookController.CreateBook(_swordOfTruth);
            
            var response = _bookController.UpdateBook(_swordOfTruth.Id, null);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.False);
            Assert.That(responseData.Message, Does.Contain("is null"));
        }
        
        [Test]
        public void DeleteBook_BookWithValidId_ReturnStatusWithTrue()
        {
            _bookController.CreateBook(_beautyAndTheBeast);
            _bookController.CreateBook(_gameOfThrones);
            _bookController.CreateBook(_swordOfTruth);
            
            var response = _bookController.DeleteBook(_swordOfTruth.Id);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.True);
            Assert.That(responseData.Message, Does.Contain("Successfully deleted"));
        }
        
        [Test]
        public void DeleteBook_BookWithInvalidId_ReturnStatusWithFalse()
        {
            _bookController.CreateBook(_beautyAndTheBeast);
            _bookController.CreateBook(_gameOfThrones);
            _bookController.CreateBook(_swordOfTruth);
            
            var response = _bookController.DeleteBook(9989);
            var responseData = (ResponseData) response.Data;
            
            Assert.That(responseData.Status, Is.False);
            Assert.That(responseData.Message, Does.Contain("Error in deleting"));
        }

    }
}