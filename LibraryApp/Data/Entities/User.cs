using System;
using System.Collections.Generic;

namespace LibraryApp.Data.Entities;

public partial class User
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string Password { get; set; } = null!;

    public bool? Status { get; set; }

    public virtual ICollection<BookBorrow> BookBorrows { get; set; } = new List<BookBorrow>();
}
