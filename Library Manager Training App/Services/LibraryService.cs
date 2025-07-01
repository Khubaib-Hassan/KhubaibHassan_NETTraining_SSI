using Library_Manager_Training_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager_Training_App.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly LibraryDbContext library;
        public LibraryService(LibraryDbContext libraryDb) {
            library = libraryDb;
        }

        public async Task AddBook(Book book, int userId)
        {
            var user = library.Users.FirstOrDefault(u => u.Id == userId);

            if (user == null || user.Role != UserRole.Librarian)
            {
                Console.WriteLine("Only Librarians can add Books");
                return;
            }

            if (library.Books.Any(b => b.ISBN == book.ISBN))
            {
                Console.WriteLine("Book already exists.");
                return;
            }

            library.Books.Add(book);
            await library.SaveChangesAsync();

            Console.WriteLine("Book Added");
        }

        public async Task AddUser(User newUser, int adderId)
        {
            var user = library.Users.FirstOrDefault(u => u.Id == adderId);

            if (user == null || user.Role != UserRole.Librarian)
            {
                Console.WriteLine("Only Librarians can add Users");
                return;
            }

            if (library.Users.Any(u => u.Id == newUser.Id))
            {
                Console.WriteLine("User already exists.");
                return;
            }

            library.Users.Add(newUser);
            await library.SaveChangesAsync();

            Console.WriteLine("User Added");
        }

        public List<Book> GetBooks()
        {
            return library.Books.ToList();
        }

        public async Task<bool> BorrowBook(string bookId,int userId)
        {
            var book = library.Books.FirstOrDefault(b => b.ISBN == bookId);

            var user = library.Users.FirstOrDefault(u => u.Id == userId);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return false;
            }

            if (user == null)
            {
                Console.WriteLine("User not found");
                return false;
            }

            if( library.BorrowRecords.Any(b => b.UserId == userId && b.BookISBN == bookId))
            {
                Console.WriteLine("User has already borrowed this book");
                return false;
            }

            if (book.Status == BookStatus.Borrowed)
            {
                Console.WriteLine("Book is not Available");
                return false;
            }

            book.Quantity--;

            library.BorrowRecords.Add(new BorrowRecord { UserId = userId, BookISBN = bookId });
            await library.SaveChangesAsync();

            Console.WriteLine("Book Borrowed");

            return true;
        }

        public async Task deleteBook(string bookId)
        {
            var book = library.Books.FirstOrDefault(b => b.ISBN == bookId);
            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            if (book.Status == BookStatus.Borrowed)
            {
                Console.WriteLine("Book is not Available");
                return;
            }

            library.Books.Remove(book);
            await library.SaveChangesAsync();
        }
    }
}
