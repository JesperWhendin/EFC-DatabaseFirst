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

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8EBV68R;Initial Catalog=EFC-DatabaseFirst;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Category__3214EC07C652C412");

            entity.ToTable("Category");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC0766F0E418");

            entity.ToTable("Product");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Product__Categor__286302EC");

            entity.HasOne(d => d.Supplier).WithMany(p => p.Products)
                .HasForeignKey(d => d.SupplierId)
                .HasConstraintName("FK__Product__Supplie__29572725");
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Supplier__3214EC07BD422D01");

            entity.ToTable("Supplier");

            entity.Property(e => e.ContactInfo).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    #region CategoryCRUD

    public void CreateCategory(string name)
    {
        Categories.Add(new Category() { Name = name });
        SaveChanges();
    }

    public void ShowAllCategories()
    {
        Console.WriteLine("\n-------------------------");
        foreach (var c in Categories)
        {
            Console.WriteLine($"{c.Id}, {c.Name}");
        }
        Console.WriteLine("-------------------------\n");
    }

    public void UpdateCategoryById(int id, string newName)
    {
        var category = Categories.FirstOrDefault(c => c.Id == id);
        if (category != null)
        {
            category.Name = newName;
            SaveChanges();
        }
    }

    public void RemoveCategoryById(int id)
    {
        var category = Categories.FirstOrDefault(c => c.Id == id);
        Categories.Remove(category);
        SaveChanges();
    }


    #endregion

    #region ProductCrud

    public void CreateProduct(string name, double price, int categoryId)
    {
        var category = Categories.FirstOrDefault(c => c.Id == categoryId);
        if (category != null)
        {
            Products.Add(new Product()
            {
                Name = name,
                Price = price,
                CategoryId = categoryId,
                Category = category
            });
            SaveChanges();
        }
        else
        {
            Console.WriteLine($"Can't Create product. Category ID {categoryId} does not exist.");
        }
    }

    public void UpdateProductCategoryById(int id, int categoryId)
    {
        var product = Products.FirstOrDefault(p => p.Id == id);
        var category = Categories.FirstOrDefault(c => c.Id == categoryId);
        if (product != null && category != null)
        {
            product.CategoryId = categoryId;
            SaveChanges();
        }
        else
        {
            Console.WriteLine($"Can't update product. Category ID {categoryId} does not exist.");
        }
    }

    #endregion

}
