using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    /// <summary>
    /// This is the base object of the system
    /// </summary>
    public class BookDTO
    {
        public int BookID { get; set; }
        [MinLength(1, ErrorMessage = "Title is required")]
        [MaxLength(40, ErrorMessage = "The max length is 40")]
        public string Title { get; set; }
        [MinLength(1, ErrorMessage = "Author is required")]
        [MaxLength(40, ErrorMessage = "The max length is 40")]
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public bool IsAvailable { get; set; }
    }
    /// <summary>
    /// This object wrappes around the BookDTO object for validation
    /// </summary>
    public class Book
    {
        private readonly BookDTO _book;

        public Book()
        {
            _book = new BookDTO();
        }
        public int BookID
        {
            get => _book.BookID;
            set
            {
                _book.BookID = value;
                Validate();
            }
        }

        public string Title
        {
            get => _book.Title;
            set
            {
                _book.Title = value;
                Validate();
            }
        }

        public string Author
        {
            get => _book.Author;
            set
            {
                _book.Author = value;
                Validate();
            }
        }
        /// <summary>
        /// This validation makes sure the year is correct
        /// </summary>
        private int _publicationYear;
        public int PublicationYear
        {
            get => _publicationYear;
            set
            {
                if (value >= 1000 && value <= DateTime.Now.Year)
                {
                    _publicationYear = value;
                    Validate();
                }
                else
                {
                    throw new Exception("Invalid publication year.");
                }
            }
        }
        public bool IsAvailable
        {
            get => _book.IsAvailable;
            set
            {
                _book.IsAvailable = value;
                Validate();
            }
        }
        /// <summary>
        /// This method is used to check the attributes and see if the object is valid
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool Validate()
        {
            var validationResults = new List<ValidationResult>();
            var validationContext = new ValidationContext(_book);
            var isValid = Validator.TryValidateObject(_book, validationContext, validationResults, true);

            if (!isValid)
            {
                var sb = new StringBuilder();
                foreach (var validationResult in validationResults)
                {
                    sb.AppendLine(validationResult.ErrorMessage);
                }

                throw new Exception(sb.ToString());
            }

            return isValid;
        }
    }


}