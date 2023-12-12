using System;
using System.Collections.Generic;

namespace EFC_DatabaseFirst.Entities;

public partial class Product
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }

    public int? CategoryId { get; set; }

    public int? SupplierId { get; set; }

    public virtual Category? Category { get; set; }

    public virtual Supplier? Supplier { get; set; }

    public virtual ICollection<Tag> Tags { get; set; } = new List<Tag>();
}
