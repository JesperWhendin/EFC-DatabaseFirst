// See https://aka.ms/new-console-template for more information

using EFC_DatabaseFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

Console.WriteLine("Executing database queries!");

using var efcDb = new EfcDatabaseFirstContext();

#region Utkommenterat

//efcDb.CreateCategory("CPU");
//efcDb.CreateCategory("GPU");
//efcDb.CreateCategory("RAM");
//efcDb.CreateCategory("PSU");
//efcDb.CreateCategory("SSD");
//efcDb.CreateCategory("Mobo");
//efcDb.CreateCategory("Cooler");
//efcDb.CreateCategory("Chassi");
//efcDb.CreateCategory("MonitorTESTTESTTESTTEST");

//efcDb.CreateCategory("Motherboard");
//efcDb.UpdateCategoryById(9, "Monitor");
//efcDb.UpdateCategoryById(7, "Cooling");
//efcDb.RemoveCategoryById(6);


#endregion

//var cpu = efcDb.Products.FirstOrDefault(p => p.Id == 3);
//efcDb.Products.Remove(cpu);
//efcDb.SaveChanges();

efcDb.ShowAllCategories();

//efcDb.CreateProduct("Intel 14600k", 3990, 2);
Console.WriteLine(efcDb.Products.FirstOrDefault(p => p.CategoryId == 2));
efcDb.UpdateProductCategoryById(4, 1);
Console.WriteLine(efcDb.Products.FirstOrDefault(p => p.CategoryId == 1));


Console.WriteLine("Database queries completed!");