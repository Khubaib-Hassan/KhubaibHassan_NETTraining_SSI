using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Manager_Training_App.Models
{
    public enum BookStatus
    {
        Available,
        Borrowed
    }
    public class Book
    {
        public string ISBN { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public BookStatus Status { get { return Quantity > 0 ? BookStatus.Available : BookStatus.Borrowed; } }
    }
}
