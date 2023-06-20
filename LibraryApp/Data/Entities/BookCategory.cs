﻿using System;
using System.Collections.Generic;

namespace LibraryApp.Data.Entities;

public partial class BookCategory
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
