
using LibraryApp.Data;
using LibraryApp.Data.Entities;
using Microsoft.AspNetCore.Mvc;

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
        public List<Book> showBooks()
        {
            return _db.Books.ToList();
        }

    }
}
