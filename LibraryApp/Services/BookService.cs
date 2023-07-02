
using LibraryApp.Data;
using LibraryApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApp.Services
{


    public class BookService
    {
        private readonly AppDbContext _db;
        public BookService(AppDbContext appDbContext)
        {
            _db = appDbContext;
        }

        [HttpGet]
        public async Task<List<Book>> GetAll()
        {
            return await _db.Books.ToListAsync();
        }

        [HttpPost]
        public async Task<int> Add(AddBookVm vm)
        {
            var newBook = new Book();
            newBook.Name = vm.Name;
            newBook.Author = vm.Author;
            newBook.Count = vm.Count;
            newBook.BookCategoryId = 1;
           // newBook.AddDate = DateTime.Now;
            _db.Books.Add(newBook);
            return await _db.SaveChangesAsync();
        }


    }
}
