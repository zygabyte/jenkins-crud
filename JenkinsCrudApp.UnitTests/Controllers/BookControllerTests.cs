using JenkinsCrudApp.Services.Interfaces;
using NUnit.Framework;

namespace JenkinsCrudApp.UnitTests.Controllers
{
    [TestFixture]
    public class BookControllerTests
    {
        private IBookService _bookService;
        [SetUp]
        public void SetUp()
        {
            _bookService = new BookServiceMock();
        }
        
        [Test]
        public void CreateBook_ValidBook_ReturnTrue()
        {
        }
    }
}