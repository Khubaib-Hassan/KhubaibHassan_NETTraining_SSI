using Library_Manager_Training_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager_Training_App.Services
{
    public interface ILibraryService
    {
        public void AddBook(Book book, int userId);

        public void AddUser(User newUser, int adderId);

        public void BorrowBook(string bookId, int userId);
    }
}
