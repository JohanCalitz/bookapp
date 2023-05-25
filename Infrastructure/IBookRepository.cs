using Domain;

namespace Infrastructure
{
    /// <summary>
    /// This is the book repository interface with all the implimentations
    /// </summary>
    public interface IBookRepository
    {
        void AddBook(Book book);
        void RemoveBook(int bookID);
        void UpdateBook(int bookID, Book updatedBook);
        Book GetBook(int bookID);
        List<Book> GetAvailableBooks();
        List<Book> SearchBooks(string keyword);
    }
}
