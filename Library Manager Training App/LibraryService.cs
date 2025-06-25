using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager_Training_App
{
    public class LibraryService
    {
        List<Book> Books = new List<Book>
        {
            new Book{ISBN="ABC123",Title="Harry Potter",Quantity=5},
            new Book{ISBN="ABC567",Title="LOTR",Quantity=2}
        };

        List<User> Users = new List<User>
        {
            new User{Id=1,Name="Ali",Gender="Male",Role=UserRole.Librarian},
            new User{Id=2,Name="Ahmad",Gender="Male"},
        };

        List<BorrowRecord> BorrowRecords = new List<BorrowRecord>();

        public void AddBook(Book book, int userId)
        {
            var user = Users.FirstOrDefault(u => u.Id == userId);

            if (user == null || user.Role != UserRole.Librarian)
            {
                Console.WriteLine("Only Librarians can add Books");
                return;
            }

            if (Books.Any(b => b.ISBN == book.ISBN))
            {
                Console.WriteLine("Book already exists.");
                return;
            }

            Books.Add(book);

            Console.WriteLine("Book Added");
        }

        public void AddUser(User newUser, int adderId)
        {
            var user = Users.FirstOrDefault(u => u.Id == adderId);

            if (user == null || user.Role != UserRole.Librarian)
            {
                Console.WriteLine("Only Librarians can add Users");
                return;
            }

            if (Users.Any(u => u.Id == newUser.Id))
            {
                Console.WriteLine("User already exists.");
                return;
            }

            Users.Add(newUser);

            Console.WriteLine("User Added");
        }

        public void BorrowBook(string bookId,int userId)
        {
            var book = Books.FirstOrDefault(b => b.ISBN == bookId);

            var user = Users.FirstOrDefault(u => u.Id == userId);

            if (book == null)
            {
                Console.WriteLine("Book not found");
                return;
            }

            if (user == null)
            {
                Console.WriteLine("User not found");
                return;
            }

            if(BorrowRecords.Any(b => b.UserId == userId && b.BookISBN == bookId))
            {
                Console.WriteLine("User has already borrowed this book");
                return;
            }

            if (book.Status == BookStatus.Borrowed)
            {
                Console.WriteLine("Book is not Available");
                return;
            }

            book.Quantity--;

            BorrowRecords.Add(new BorrowRecord { UserId = userId, BookISBN = bookId });

            Console.WriteLine("Book Borrowed");
        }
    }
}
