using Library_Manager_Training_App.Models;
using Library_Manager_Training_App.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Library_Manager_Training_App
{
    public class Runner
    {
        private readonly ILibraryService _libraryService;

        private readonly IDeserializeService _deserializeService;

        private readonly IOptions<AppOptions> _appOptions;

        public Runner(ILibraryService libraryService, IDeserializeService deserializeService,IOptions<AppOptions> appOptions)
        {
            _libraryService = libraryService;
            _deserializeService = deserializeService;
            _appOptions = appOptions;
        }

        public void Run()
        { 
            Book newBook = new Book { ISBN = "XYZ789", Title = "The Alchemist", Quantity = 3 };
            _libraryService.AddBook(newBook, 1);

            User newUser = new User { Id = 3, Name = "Sara", Gender = "Female" };
            _libraryService.AddUser(newUser, 1);

            _libraryService.BorrowBook("ABC123", 2);
            _libraryService.BorrowBook("XYZ789", 3);
            _libraryService.BorrowBook("XYZ789", 3);

            Console.WriteLine("\nUser.json");

            foreach(var user in _deserializeService.getUsers())
            {
                Console.WriteLine($"{user.Email} , {user.Name}, {user.Gender}");
            }

            Console.WriteLine("\nBook.json");

            foreach (var book in _deserializeService.getBooks())
            {
                Console.WriteLine($"{book.ISBN} , {book.Title}, {book.Quantity}");
            }

        }
    }
}
