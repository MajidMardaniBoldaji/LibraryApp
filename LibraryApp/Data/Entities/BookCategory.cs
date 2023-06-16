using System;
using System.Collections.Generic;

namespace LibraryApp.Data.Entities;

public partial class BookCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;
}
