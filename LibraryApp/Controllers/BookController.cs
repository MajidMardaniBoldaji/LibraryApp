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

        [HttpGet]
        public   IActionResult GetAll()
        {
            return  Ok(_bookService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(AddBookVm vm)
        {
            return Ok(_bookService.Add(vm));
        }
    }
}
