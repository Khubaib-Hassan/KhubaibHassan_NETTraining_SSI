using Microsoft.AspNetCore.Mvc;
using Library_Manager_Training_App.Services;
using Library_Manager_Training_App.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryWebApp.Controllers
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

        // GET api/<LibraryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<LibraryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<LibraryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<LibraryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
