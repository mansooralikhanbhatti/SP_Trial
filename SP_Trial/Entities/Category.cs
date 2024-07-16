using System;
using System.Collections.Generic;

namespace SP_Trial.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? Description { get; set; }

    public string? IsActive { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
