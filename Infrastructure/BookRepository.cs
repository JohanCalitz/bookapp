using Domain;
using Newtonsoft.Json;

namespace Infrastructure
{
    public class BookRepository : IBookRepository
    {
        /// <summary>
        /// This is the repository of the book system used to communicate with the data file
        /// </summary>
        private IDictionary<int, Book> _books; // I used a dictonary since it is faster to search for books then using lists (BIG O NOTATION)
        private readonly string filePath = "books.json";
        public BookRepository()
        {
            LoadBooks();
        }
        /// <summary>
        /// This method adds a book to the json file
        /// </summary>
        /// <param name="book"></param>
        /// <exception cref="Exception"></exception>
        public void AddBook(Book book)
        {
            if (book != null)
            {
                var booksCheck = _books.ContainsKey(book.BookID);
                if (booksCheck == false)
                {
                    _books.Add(book.BookID, book);
                    SaveChanges();
                }
                else
                {
                    throw new Exception("The book already exists");
                }

            }

        }
        /// <summary>
        /// This method removes a book to the json file
        /// </summary>
        /// <param name="bookID"></param>
        /// <exception cref="Exception"></exception>
        public void RemoveBook(int bookID)
        {
            var booksCheck = _books.ContainsKey(bookID);
            if (booksCheck == true)
            {
                _books.Remove(bookID);
                SaveChanges();
            }
            else
            {
                throw new Exception("The book is not found");
            }
        }
        /// <summary>
        /// This method updates a book to the json file
        /// </summary>
        /// <param name="bookID"></param>
        /// <param name="updatedBook"></param>
        /// <exception cref="Exception"></exception>
        public void UpdateBook(int bookID, Book updatedBook)
        {
            var booksCheck = _books.ContainsKey(bookID);
            if (booksCheck == true)
            {
                var book = _books[bookID];
                book.Title = updatedBook.Title;
                book.Author = updatedBook.Author;
                book.PublicationYear = updatedBook.PublicationYear;
                book.IsAvailable = updatedBook.IsAvailable;
                SaveChanges();
            }
            else
            {
                throw new Exception("The book is not found");
            }
        }
        /// <summary>
        /// This method gets a book to the json file
        /// </summary>
        /// <param name="bookID"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public Book GetBook(int bookID)
        {
            var booksCheck = _books.ContainsKey(bookID);
            if (booksCheck == true)
            {
                var book = _books[bookID];
                return book;
            }
            else
            {
                throw new Exception("The book is not found");
            }
        }
        /// <summary>
        /// This method gets all available books from the json file
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Book> GetAvailableBooks()
        {
            var book = _books.Values.Where(b => b.IsAvailable).ToList();
            if (book.Count == 0)
            {
                throw new Exception("No available books.");
            }
            return book;
        }
        /// <summary>
        /// This method searches for books from the json file
        /// </summary>
        /// <param name="keyword"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<Book> SearchBooks(string keyword)
        {
            var book = _books.Values.Where(b => b.Title.Contains(keyword) || b.Author.Contains(keyword)).ToList();
            if (book.Count == 0)
            {
                throw new Exception("No books found matching the keyword.");
            }
            return book;

        }
        /// <summary>
        /// This method saves the changes to the json file
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void SaveChanges()
        {
            try
            {
                string json = JsonConvert.SerializeObject(_books, Formatting.Indented);
            File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {

                throw new Exception($"Error working with Json file, more details follow: {ex}");
            }
        }
        /// <summary>
        /// This method loads data from the json file
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void LoadBooks()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string json = File.ReadAllText(filePath);
                    _books = JsonConvert.DeserializeObject<IDictionary<int, Book>>(json);
                }
                else
                {
                    _books = new Dictionary<int, Book>();
                    SaveChanges();
                }
            }
            catch (Exception ex)
            {

                throw new Exception($"Error working with Json file, more details follow: {ex}");
            }

        }

    }
}
