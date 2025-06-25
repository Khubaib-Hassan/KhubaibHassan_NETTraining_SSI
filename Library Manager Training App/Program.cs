namespace Library_Manager_Training_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            LibraryService library = new LibraryService();

            Book newBook = new Book { ISBN = "XYZ789", Title = "The Alchemist", Quantity = 3 };
            library.AddBook(newBook, 1);

            User newUser = new User { Id = 3, Name = "Sara", Gender = "Female" };
            library.AddUser(newUser, 1);

            library.BorrowBook("ABC123", 2);
            library.BorrowBook("XYZ789", 3);
            library.BorrowBook("XYZ789", 3);
        }
    }
}
