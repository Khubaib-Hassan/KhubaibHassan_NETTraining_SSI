using Library_Manager_Training_App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Library_Manager_Training_App.Services
{
    public class DeserializeService:IDeserializeService
    {
        public List<User> getUsers()
        {
            var json = File.ReadAllText("Files/User.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<User>>(json,options);
        }

        public List<Book> getBooks()
        {

            var json = File.ReadAllText("Files/Book.json");

            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            return JsonSerializer.Deserialize<List<Book>>(json,options);

        }
    }
}
