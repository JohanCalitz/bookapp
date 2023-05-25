using Application;
using Domain;
using Infrastructure;
using Moq;

namespace Tests
{
    /// <summary>
    /// Moq test was used
    /// </summary>
    [TestFixture]
    public class BookServiceTests
    {
        /// <summary>
        /// Moq all the Interfaces
        /// </summary>
        private Mock<IBookRepository> _mockBookRepository;
        private Mock<IErrorLogger> _mockErrorLogger;
        private IBookService _bookService;
        private string errorMessage = "Error: Please contact admin";

        [SetUp]
        public void Setup()
        {
            _mockBookRepository = new Mock<IBookRepository>();
            _mockErrorLogger = new Mock<IErrorLogger>();
            _bookService = new BookService(_mockBookRepository.Object, _mockErrorLogger.Object);
            _bookService.HandleError(errorMessage);
        }

        [Test]
        public void AddBook()
        {
            var book = new Book
            {
                BookID = 1,
                Title = "King kong",
                Author = "Johan Calitz",
                PublicationYear = 1998,
                IsAvailable = true
            };

            _bookService.AddBook(book);

            _mockBookRepository.Verify(r => r.AddBook(book), Times.Once);
            _mockErrorLogger.Verify(x => x.LogError(errorMessage), Times.Once);
        }

        [Test]
        public void RemoveBook()
        {
            var bookID = 1;

            _bookService.RemoveBook(bookID);

            _mockBookRepository.Verify(r => r.RemoveBook(bookID), Times.Once);
            _mockErrorLogger.Verify(x => x.LogError(errorMessage), Times.Once);
        }

        [Test]
        public void UpdateBook()
        {

            var bookID = 1;
            var updatedBook = new Book
            {
                BookID = 1,
                Title = "PWC How To Tax",
                Author = "Johan Calitz",
                PublicationYear = 2021,
                IsAvailable = false
            };

            _bookService.UpdateBook(bookID, updatedBook);

            _mockBookRepository.Verify(r => r.UpdateBook(bookID, updatedBook), Times.Once);
            _mockErrorLogger.Verify(x => x.LogError(errorMessage), Times.Once);
        }

        [Test]
        public void GetBook()
        {
            var bookID = 1;
            var expectedBook = new Book
            {
                BookID = 1,
                Title = "Rich Dad Poor Dad",
                Author = "Robert Kiyosaki",
                PublicationYear = 2008,
                IsAvailable = true
            };
            _mockBookRepository.Setup(r => r.GetBook(bookID)).Returns(expectedBook);

            var actualBook = _bookService.GetBook(bookID);

            Assert.AreEqual(expectedBook, actualBook);
            _mockErrorLogger.Verify(x => x.LogError(errorMessage), Times.Once);
        }

        [Test]
        public void GetAvailableBooks()
        {
            var availableBooks = new List<Book>
            {
                new Book
               {
                BookID = 1,
                Title = "Rich Dad Poor Dad",
                Author = "Robert Kiyosaki",
                PublicationYear = 2008,
                IsAvailable = true
            },
            new Book
                {
                    BookID = 2,
                    Title = "No Title",
                    Author = "Johan Calitz",
                    PublicationYear = 1999,
                    IsAvailable = true
                }
            };
            _mockBookRepository.Setup(r => r.GetAvailableBooks()).Returns(availableBooks);

            var actualBooks = _bookService.GetAvailableBooks();

            Assert.AreEqual(availableBooks, actualBooks);
            _mockErrorLogger.Verify(x => x.LogError(errorMessage), Times.Once);
        }

        [Test]
        public void SearchBooks()
        {
            var keyword = "Clean";
            var matchingBooks = new List<Book>
            {
                new Book
                {
                    BookID = 1,
                    Title = "How to c#",
                    Author = "Johan Calitz",
                    PublicationYear = 2002,
                    IsAvailable = true
                },
                new Book
                {
                    BookID = 3,
                    Title = "Does this work",
                    Author = "Johan Calitz",
                    PublicationYear = 2011,
                    IsAvailable = true
                }
            };
            _mockBookRepository.Setup(r => r.SearchBooks(keyword)).Returns(matchingBooks);

            var actualBooks = _bookService.SearchBooks(keyword);

            Assert.AreEqual(matchingBooks, actualBooks);
            _mockErrorLogger.Verify(x => x.LogError(errorMessage), Times.Once);
        }
    }
}
