﻿using SP_Trial.Models;
using System.Collections.Generic;

public class DashboardViewModel
{
    public List<Product> Products { get; set; }
    public List<User> Users { get; set; }
    public List<Category> Categories { get; set; }
    public List<CategoryProductCount> CategoryProductCounts { get; set; }
}
