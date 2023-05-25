using Domain;
using Infrastructure;

namespace Application
{
    public class BookService: IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IErrorLogger _errorLogger;
        /// <summary>
        /// This is the application layer which communicates between the infrastructure and the domain
        /// </summary>
        /// <param name="bookRepository"></param>
        /// <param name="errorLogger"></param>
        public BookService(IBookRepository bookRepository, IErrorLogger errorLogger)
        {
            _bookRepository = bookRepository;
            _errorLogger = errorLogger;
        }
        /// <summary>
        /// This method is used to add a new book
        /// </summary>
        /// <param name="book"></param>
        public void AddBook(Book book)
        {
            _bookRepository.AddBook(book);
        }
        /// <summary>
        /// This method is used to remove a book
        /// </summary>
        /// <param name="bookID"></param>
        public void RemoveBook(int bookID)
        {
            _bookRepository.RemoveBook(bookID);
        }
        /// <summary>
        /// This method is used to update a book using the supplied ID
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="updatedBook"></param>
        public void UpdateBook(int bookID, Book updatedBook)
        {
            _bookRepository.UpdateBook(bookID, updatedBook);
        }
        /// <summary>
        /// This method gets the book
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        public Book GetBook(int bookID)
        {
            return _bookRepository.GetBook(bookID);
        }
        /// <summary>
        /// This method gets all the available books
        /// </summary>
        /// <returns></returns>
        public List<Book> GetAvailableBooks()
        {
            return _bookRepository.GetAvailableBooks();
        }
        /// <summary>
        /// This method searches for books
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        public List<Book> SearchBooks(string keyword)
        {
            return _bookRepository.SearchBooks(keyword);
        }
        /// <summary>
        /// This method is used to catch errors and display it to the user
        /// </summary>
        /// <param name="errorMessage"></param>
        public void HandleError(string errorMessage)
        {
            _errorLogger.LogError(errorMessage);
        }
    }
}
