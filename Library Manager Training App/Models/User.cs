using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Library_Manager_Training_App.Models
{
    public enum UserRole
    {
        Librarian,
        Member
    }
    public class User
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }

        public string Gender { get; set; }

        public string? Email { get; set; }

        public UserRole Role { get; set; } = UserRole.Member;
    }
}
