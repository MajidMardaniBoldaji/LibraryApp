using System;
using System.Collections.Generic;

namespace LibraryApp.Data.Entities;

public partial class BookBorrow
{
    public int Id { get; set; }

    public int BookId { get; set; }

    public int MemberId { get; set; }

    public int UserId { get; set; }

    public DateTime BorrowDate { get; set; }

    public DateTime? ReturnDate { get; set; }

    public string? Description { get; set; }

    public virtual Book Book { get; set; } = null!;

    public virtual Member Member { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
