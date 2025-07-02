using Library_Manager_Training_App.Models;
using Library_Manager_Training_App.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Eventing.Reader;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library_Manager_Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILibraryService _libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            _libraryService = libraryService;
        }
        [HttpGet]
        public List<Book> Get()
        {
            return _libraryService.GetBooks();
        }


        [HttpPost]
        public void Post([FromBody] Book book,int userId)
        {
            _libraryService.AddBook(book,userId);
        }

        [HttpPut("{id}")]
        public void Put(string bookId, int userId)
        {
            _libraryService.BorrowBook(bookId, userId);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _libraryService.deleteBook(id);
        }
    }
}
