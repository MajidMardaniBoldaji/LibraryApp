using System;
using System.Collections.Generic;

namespace LibraryApp.Data.Entities;

public partial class Book
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Count { get; set; }

    public string Author { get; set; } = null!;

    public int BookCategoryId { get; set; }

    public DateTime? AddDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<BookBorrow> BookBorrows { get; set; } = new List<BookBorrow>();

    public virtual BookCategory BookCategory { get; set; } = null!;
}
