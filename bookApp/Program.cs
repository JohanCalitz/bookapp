using Application;
using Domain;
using Infrastructure;

namespace bookApp
{
    public class Program
    {
        private static IBookService _bookService;
        /// <summary>
        /// Main method with error handling
        /// </summary>
        public static void Main()
        {
            _bookService = new BookService(new BookRepository(), new ErrorLogger());

            while (true)
            {
                Console.WriteLine("Menu:");
                Console.WriteLine("1. Add a new book");
                Console.WriteLine("2. Remove a book by ID");
                Console.WriteLine("3. Update book information");
                Console.WriteLine("4. Search for a book");
                Console.WriteLine("5. List all available books");
                Console.WriteLine("0. Exit");

                Console.Write("Enter your option: ");
                var option = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.Clear();
                            Add();
                            break;
                        case "2":
                            Console.Clear();
                            Remove();
                            break;
                        case "3":
                            Console.Clear();
                            Update();
                            break;
                        case "4":
                            Console.Clear();
                            Search();
                            break;
                        case "5":
                            Console.Clear();
                            AvailableBooks();
                            break;
                        case "0":
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _bookService.HandleError(ex.Message); // uses the error handling method to display error messages
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// Private method to display add functionality to cli
        /// </summary>
        private static void Add()
        {
            var book = new Book();

            Console.Write("Enter BookID: ");
            book.BookID = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter Title: ");
            book.Title = Console.ReadLine();

            Console.Write("Enter Author: ");
            book.Author = Console.ReadLine();

            Console.Write("Enter Publication Year: ");
            book.PublicationYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Is Available? (true/false): ");
            book.IsAvailable = Convert.ToBoolean(Console.ReadLine());

            _bookService.AddBook(book);
            Console.WriteLine("Book added successfully.");
        }
        /// <summary>
        /// Private method to display remove functionality to cli
        /// </summary>
        private static void Remove()
        {
            Console.Write("Enter BookID: ");
            var bookID = Convert.ToInt32(Console.ReadLine());

            _bookService.RemoveBook(bookID);
            Console.WriteLine("Book removed successfully.");
        }
        /// <summary>
        /// Private method to display update functionality to cli
        /// </summary>
        private static void Update()
        {
            Console.Write("Enter BookID: ");
            var bookID = Convert.ToInt32(Console.ReadLine());

            var book = _bookService.GetBook(bookID);

            Console.WriteLine("Current book information:");
            ShowBook(book);

            Console.WriteLine("Enter updated information:");

            Console.Write("Enter Title: ");
            book.Title = Console.ReadLine();

            Console.Write("Enter Author: ");
            book.Author = Console.ReadLine();

            Console.Write("Enter Publication Year: ");
            book.PublicationYear = Convert.ToInt32(Console.ReadLine());

            Console.Write("Is Available? (true/false): ");
            book.IsAvailable = Convert.ToBoolean(Console.ReadLine());


            _bookService.UpdateBook(bookID, book);
            Console.WriteLine("Book updated successfully.");
        }
        /// <summary>
        /// Private method to display search functionality to cli
        /// </summary>
        private static void Search()
        {
            Console.Write("Enter keyword to search: ");
            var search = Console.ReadLine();

            var books = _bookService.SearchBooks(search);

            Console.WriteLine("Books found:");
            foreach (var book in books)
            {
                ShowBook(book);
            }
        }
        /// <summary>
        /// Private method to display available functionality to cli
        /// </summary>
        private static void AvailableBooks()
        {
            var books = _bookService.GetAvailableBooks();
            Console.WriteLine("Available Books:");
            foreach (var book in books)
            {
                ShowBook(book);
            }
        }
        /// <summary>
        /// Private method to display book functionality to cli
        /// </summary>
        private static void ShowBook(Book book)
        {
            Console.WriteLine($"BookID: {book.BookID}");
            Console.WriteLine($"Title: {book.Title}");
            Console.WriteLine($"Author: {book.Author}");
            Console.WriteLine($"Publication Year: {book.PublicationYear}");
            Console.WriteLine($"Is Available: {book.IsAvailable}");
            Console.WriteLine();
        }
    }
}