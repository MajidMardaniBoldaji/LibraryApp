
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
        public async Task<int> Add(BookVm vm)
        {
            var newBook = new Book();
            newBook.Name = vm.Name;
            newBook.Author = vm.Author;
            newBook.Count = vm.Count;
            newBook.BookCategoryId = 1;
            newBook.AddDate = vm.AddDate;
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

        public async Task<int> UpdateName(int Id,BookVm book)
        {
            var bookItem = await _db.Books.FirstOrDefaultAsync(m => m.Id == Id);
            if (bookItem != null)
            {
                bookItem.Name = book.Name;
                bookItem.UpdateDate = DateTime.Now; 
                bookItem.Author=book.Author;    
                bookItem.Count=book.Count;
                bookItem.BookCategoryId=book.BookCategoryId;
                return await _db.SaveChangesAsync();
            }
            return 0;
        }

        [HttpPost]
        public async Task<int> BorrowBook()
        {
            var newBorow = new BookBorrow();
            newBorow.BookId = 1;
            newBorow.MemberId = 2;
            newBorow.UserId = 3;    
            newBorow.BorrowDate = DateTime.Now;
            newBorow.Description = "...";
            _db.BookBorrows.Add(newBorow);
            return await _db.SaveChangesAsync();
        }



    }
}
