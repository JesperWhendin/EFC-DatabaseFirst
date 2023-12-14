using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EFC_DatabaseFirst.Entities;

public partial class EfcDatabaseFirstContext : DbContext
{
    public EfcDatabaseFirstContext()
    {
    }

    public EfcDatabaseFirstContext(DbContextOptions<EfcDatabaseFirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-608UNRB;Initial Catalog=EFC-DatabaseFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
}
