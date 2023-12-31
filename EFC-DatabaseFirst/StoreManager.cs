﻿using EFC_DatabaseFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace EFC_DatabaseFirst
{
    public class StoreManager : EfcDatabaseFirstContext
    {

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

        public void ListCategoryById(int CatId)
        {
            var cat = Categories.FirstOrDefault(c => c.Id == CatId);


            foreach (var product in Products)
            {
                if (product.CategoryId == CatId)
                {
                    Console.WriteLine($"Product: {product.Name} Category: {cat.Name} ");
                }
            }
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
                    Category = category,
                    Tags = new List<Tag>()
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

        public void UpdateProductWithSupplier(Product product, int supplier)
        {
            var updProd = Products.FirstOrDefault(p => p.Id == product.Id);
            var sup = Suppliers.SingleOrDefault(s => s.Id == supplier);
            updProd.SupplierId = supplier;
            SaveChanges();
            Console.WriteLine($"{updProd.Name} has been updated with supplier: {sup.Name}");
        }


        #endregion

        #region SupplierCrud

        public void CreateSupplier(string SupplierName, string? contactInfo)
        {
            if (!(contactInfo is null))
            {
                Add(new Supplier()
                {
                    Name = SupplierName,
                    ContactInfo = contactInfo
                });
                SaveChanges();
                Console.WriteLine($"Supplier added: {SupplierName}");
                return;
            }

            Add(new Supplier() { Name = SupplierName });
            SaveChanges();
            Console.WriteLine($"Supplier added: {SupplierName}");
        }

        public void DisplayAllSuppliers()
        {

            foreach (var supplier in Suppliers)
            {
                Console.WriteLine($"Supplier Id: {supplier.Id} | Supplier Name: {supplier.Name}");
            }

        }

        public void UpdateSupplierContactInfo(Supplier supplier, string adress)
        {
            var sup = Suppliers.SingleOrDefault(s => s.Id == supplier.Id);
            sup.ContactInfo = adress;
            SaveChanges();
        }

        #endregion

        #region TagCrud

        public void CreateTag(string name)
        {
            Tags.Add(new Tag() { Name = name });
            SaveChanges();
            Console.WriteLine($"{name} has been added as a tag.");
        }

        public void RemoveTag(int id)
        {
            var prodTag = Tags.Find(id);
            var prodListWithTag = Products.Where(p => p.Id == id);
            foreach (var p in prodListWithTag)
            {
                p.Tags.Remove(prodTag);
                //Anropa RemoveTagFromProduct istället? V
            }
            //var tag = Tags.Find(id);
            Tags.Remove(prodTag);
            SaveChanges();
            Console.WriteLine($"{prodTag.Name} has been removed.");
        } // Min tabort metod

        public void GRemoveTag(int tagId)
        {

            var tags = Tags.Find(tagId);
            foreach (var product in Products)
            {
                if (product.Tags == tags)

                    product.Tags.Remove(tags);
            }
            Tags.Remove(tags);

            SaveChanges();

        } // Gabriels ta bort-metod




        public void AddTagToProduct(Product product, Tag tag)
        {
            var prod = Products.SingleOrDefault(p => p.Id == product.Id);
            prod.Tags.Add(tag);
            SaveChanges();
            Console.WriteLine($"{prod.Name} has been assigned {tag.Name}-tag");
        }


        public void RemoveTagFromProduct(Product product, int id)
        {
            var tag = Tags.Find(id);
            product.Tags.Remove(tag);
            SaveChanges();
            Console.WriteLine($"{tag.Name}-tag has been removed from {product.Name}.");

        }

        public void ListExistingTags()
        {
            foreach (var tag in Tags)
            {
                Console.WriteLine($"Tag Id: {tag.Id} | Tag Name: {tag.Name}");
            }
        }

        #endregion

        #region SearchFilter

        public void FilterProducts()
        {
            Console.WriteLine("1. Category.\n2. Supplier.\n3. Tag.");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("Vad vill du basera din filtrering på?");
            var choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Clear();
                    foreach (var c in Categories)
                    {
                        Console.WriteLine($"{c.Id}. {c.Name}");
                    }
                    Console.WriteLine($"\nVilken kategori vill du filtrera på?");
                    var categoryChoice = Convert.ToInt32(Console.ReadLine());
                    if (categoryChoice == 1)
                    {
                        var categoryFilter = Products.Where(p => p.CategoryId == 1);
                        foreach (var p in categoryFilter)
                        {
                            Console.WriteLine(p.Name);
                        }
                    }
                    if (categoryChoice == 2)
                    {
                        var categoryFilter = Products.Where(p => p.CategoryId == 2);
                        foreach (var p in categoryFilter)
                        {
                            Console.WriteLine(p.Name);
                        }
                    }
                    if (categoryChoice == 3)
                    {
                        var categoryFilter = Products.Where(p => p.CategoryId == 3);
                        foreach (var p in categoryFilter)
                        {
                            Console.WriteLine(p.Name);
                        }
                    }

                    break;
                case 2:
                    Console.Clear();
                    foreach (var s in Suppliers)
                    {
                        Console.WriteLine($"{s.Id}. {s.Name}");
                    }
                    Console.WriteLine($"\nVilken återförsäljare vill du filtrera på?");
                    var supplierChoice = Convert.ToInt32(Console.ReadLine());
                    if (supplierChoice == 1)
                    {
                        var supplierFilter = Products.Where(p => p.SupplierId == 1);
                        foreach (var p in supplierFilter)
                        {
                            Console.WriteLine(p.Name);
                        }
                    }
                    if (supplierChoice == 2)
                    {
                        var supplierFilter = Products.Where(p => p.SupplierId == 2);
                        foreach (var p in supplierFilter)
                        {
                            Console.WriteLine(p.Name);
                        }
                    }
                    if (supplierChoice == 3)
                    {
                        var supplierFilter = Products.Where(p => p.SupplierId == 3);
                        foreach (var p in supplierFilter)
                        {
                            Console.WriteLine(p.Name);
                        }
                    }

                    break;
                case 3:
                    Console.Clear();
                    foreach (var t in Tags)
                    {
                        Console.WriteLine($"{t.Id}. {t.Name}");
                    }   
                    Console.WriteLine($"\nVilken tag vill du filtrera på?");
                    var tagChoice = Convert.ToInt32(Console.ReadLine());
                    if (tagChoice == 1)
                    {
                        //var retliFgat = Products.Where(p => p.Tags == 1);




                        var tagFilter = Products.Include(p => p.Tags
                            .Where(t => t.Id).Contains()
                            .ToList();



                        Tag tag = Tags.Find(3);
                        if (tag != null)
                        {
                            var productsWithTag = Products
                                .Where(p => p.Tags.Any(t => t.Id == tag.Id));

                            foreach (var product in productsWithTag)
                            {
                                Console.WriteLine(product.Name);
                            }
                        }



                        foreach (var p in tagFilter)
                        {
                            Console.WriteLine(p.Name);
                        }
                    }

                    break;
                default:
                    break;
            }

        }

        #endregion
    }
}
