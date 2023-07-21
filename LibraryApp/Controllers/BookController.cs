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
        [Route("AddBook")]
        [HttpPost]
        public IActionResult Add(BookVm vm)
        {
            return Ok(_bookService.Add(vm));
        }
        [HttpDelete]
        public async Task< IActionResult> Delete(int id) 
        {
            return Ok(await _bookService.Remove(id));
        }

        [HttpPut]
        public async Task<IActionResult> Update(int Id, BookVm Vm)
        {
            return Ok(await (_bookService.UpdateName(Id, Vm)));
        }
        [Route("BorrowBook")]
        [HttpPost]
        public async Task<IActionResult> Borrow()
        {
            return Ok(await (_bookService.BorrowBook()));
        }

    }
}
