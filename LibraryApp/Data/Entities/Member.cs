using System;
using System.Collections.Generic;

namespace LibraryApp.Data.Entities;

public partial class Member
{
    public int Id { get; set; }

    public string FullName { get; set; } = null!;

    public DateTime BirthDate { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime AddDate { get; set; }

    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<BookBorrow> BookBorrows { get; set; } = new List<BookBorrow>();
}
