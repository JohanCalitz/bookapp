using Domain;

namespace Application
{
    /// <summary>
    /// This is the IBookService interface
    /// </summary>
    public interface IBookService
    {
        void AddBook(Book book);
        void RemoveBook(int bookID);
        void UpdateBook(int bookID, Book updatedBook);
        Book GetBook(int bookID);
        List<Book> GetAvailableBooks();
        List<Book> SearchBooks(string keyword);
        void HandleError(string errorMessage);
    }
}