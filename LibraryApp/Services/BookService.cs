
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
        [HttpDelete]
        public async Task<int> Remove(int Id)
        {
            var book = _db.Books.Where(c => c.Id == Id).FirstOrDefault();
            if (book != null)
            {
                _db.Books.Remove(book);
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateName(int Id, string name)
        {
            var bookItem = await _db.Books.FirstOrDefaultAsync(m => m.Id == Id);
            if (bookItem != null)
            {
                bookItem.Name = name;
                return await _db.SaveChangesAsync();
            }
            return 0;
        }
    }
}
