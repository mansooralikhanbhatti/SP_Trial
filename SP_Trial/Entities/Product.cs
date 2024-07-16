﻿using System;
using System.Collections.Generic;

namespace SP_Trial.Entities;

public partial class Product
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public decimal? Price { get; set; }

    public string? Description { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;
}
