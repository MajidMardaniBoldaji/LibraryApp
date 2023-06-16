using System;
using System.Collections.Generic;

namespace LibraryApp.Data.Entities;

public partial class BookBorrow
{
    public int BookId { get; set; }

    public int MemberId { get; set; }

    public int UserId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? Description { get; set; }
}
