  _                 _                     
 | |               | |                    
 | |__   ___   ___ | | ____ _ _ __  _ __  
 | '_ \ / _ \ / _ \| |/ / _` | '_ \| '_ \ 
 | |_) | (_) | (_) |   < (_| | |_) | |_) |
 |_.__/ \___/ \___/|_|\_\__,_| .__/| .__/ 
                             | |   | |    
                             |_|   |_|  

AUTHOR: JOHAN CALITZ

-> Prerequisites
.NET 6 SDK (LTS)

-> Getting Started
To get the BookApp up and running on your machine, follow these steps:
•Download the source code
•Build the project
•Run the application

-> Alternative
Run the exe shortcut (bookApp.exe - Shortcut) which will start the program.

-> Usage:
The BookApp CLI provides the following actions:

•Add a new book: Allows you to add a new book to the library by providing the book details such as title, author, publication year, and availability.
•Remove a book by ID: Removes a book from the library based on its ID.
•Update book information: Updates the information of a book by specifying its ID and providing the updated book details.
•Search for a book: Searches for books that match a provided keyword in the title or author's name.
•List all available books: Retrieves a list of all available books in the library.
•Exit the application: Exits the BookApp.

-> Data Persistence
The BookApp utilizes a simple file-based storage system to persist the book data. The book data is saved and loaded from a local JSON file.

By default, the application uses a file named books.json located in the project directory to store the book data. If the file doesn't exist, it will be created when the application starts. 

-> Unit Tests
The BookApp includes unit tests to verify the functionality. To run the unit tests, navigate to the project directory and execute the following command:

•dotnet test 

or 

•Run the test project using Visual Studio

-> License
The BookApp is released under the MIT License.