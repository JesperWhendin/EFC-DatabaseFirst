using EFC_DatabaseFirst.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void UpdateProductWithTag(Product product, Tag tag)
        {
            var prod = Products.SingleOrDefault(p => p.Id == product.Id);
            prod.Tags.Add(tag);
            SaveChanges();
            Console.WriteLine($"{prod.Name} har fått tagen {tag.Name}");
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
        }

        public void RemoveTag(int id)
        {
            var tag = Tags.Find(id);
            Tags.Remove(tag);
            SaveChanges();
            Console.WriteLine($"{tag.Name} has been removed.");

        }

        public void RemoveTagFromProduct(int id)
        {
            var tag = Tags.Find(id);
            Tags.Remove(tag);
            SaveChanges();
            Console.WriteLine($"{tag.Name} has been removed.");

        }

        public void ListExistingTags()
        {
            foreach(var tag in Tags)
            {
                Console.WriteLine($"Tag Id: {tag.Id} | Tag Name: {tag.Name}");
            }
        }

        #endregion
    }
}
