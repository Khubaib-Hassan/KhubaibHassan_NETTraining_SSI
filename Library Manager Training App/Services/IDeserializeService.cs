using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library_Manager_Training_App.Models;

namespace Library_Manager_Training_App.Services
{
    public interface IDeserializeService
    {
        public List<User> getUsers();
        public List<Book> getBooks();
    }
}
