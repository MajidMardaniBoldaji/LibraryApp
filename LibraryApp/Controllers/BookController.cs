using LibraryApp.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace LibraryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            _bookService = bookService; 
        }
        //public BookController() { } 
        //public  IActionResult AddBook(string name,int count,string Author,int BookCategoryId, DateTime AddDate,DateTime UpdateDate)
        //{
        //}
        [HttpGet]
        public IActionResult showBooks()
        {
            return Ok(_bookService.showBooks());
        }
    }
}
