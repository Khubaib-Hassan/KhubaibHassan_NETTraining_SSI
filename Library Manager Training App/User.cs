using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager_Training_App
{
    public enum UserRole
    {
        Librarian,
        Member
    }
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Gender { get; set; }

        public UserRole Role { get; set; } = UserRole.Member;
    }
}
