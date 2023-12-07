using System;
using System.Collections.Generic;

namespace EFC_DatabaseFirst.Entities;

public partial class Supplier
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public string? ContactInfo { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
