﻿// See https://aka.ms/new-console-template for more information

using EFC_DatabaseFirst.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using EFC_DatabaseFirst;

Console.WriteLine("Executing database queries!");

using var efcDb = new StoreManager();

#region Utkommenterat

//efcDb.CreateCategory("CPU");
//efcDb.CreateCategory("GPU");
//efcDb.CreateCategory("RAM");
//efcDb.CreateCategory("PSU");
//efcDb.CreateCategory("SSD");
//efcDb.CreateCategory("Cooling");
//efcDb.CreateCategory("Chassi");
//efcDb.CreateCategory("Monitor");

//var cpu = efcDb.Products.FirstOrDefault(p => p.Id == 3);
//efcDb.Products.Remove(cpu);
//efcDb.SaveChanges();

//efcDb.ShowAllCategories();

//efcDb.CreateProduct("Intel 14600k", 7290, 1);
//Console.WriteLine(efcDb.Products.FirstOrDefault(p => p.CategoryId == 2));
//efcDb.UpdateProductCategoryById(4, 1);

//Console.WriteLine(efcDb.Products.FirstOrDefault(p => p.CategoryId == 1));

//efcDb.ListCategoryById(1);

//var test = efcDb.Products.SingleOrDefault(p => p.Id == 1);

//Console.WriteLine(test);

//efcDb.CreateSupplier("Inet", "Stora Åvägen 7");
//efcDb.CreateSupplier("Komplett", null);
//efcDb.CreateSupplier("Webhallen", null);
//efcDb.CreateSupplier("Kjell & Co", null);

//efcDb.CreateProduct("Nvidia 4070", 7290, 2);

//var supplier = efcDb.Suppliers.SingleOrDefault(s => s.Id == 4);
//efcDb.UpdateSupplierContactInfo(supplier, "Borgmästaregatan 5");

//var updProdSup = efcDb.Products.SingleOrDefault(p => p.Id == 2);

//efcDb.UpdateProductWithSupplier(updProdSup, 4);


//////////foreach(var p in efcDb.Products)
//////////{
//////////    Console.WriteLine($"{p.Name}, {p.Id}");
//////////}
//////////Console.WriteLine("-----------------------------");

//////////Console.WriteLine("Skriv ett id-nummer?");
//////////var x = Convert.ToInt32(Console.ReadLine());

//////////var test = efcDb.Products.SingleOrDefault(p => p.Id == x);
//////////var tag = efcDb.Tags.SingleOrDefault(t => t.Id == 1);

//////////efcDb.AddTagToProduct(test, tag);

//efcDb.ListExistingTags();

//efcDb.CreateTag("testTag2");
//efcDb.RemoveTag(1);

#endregion



//Console.WriteLine("Skriv ett tagId-nummer?");
//var inputTagId = Convert.ToInt32(Console.ReadLine());
//efcDb.RemoveTag(inputTagId);




Console.WriteLine("Database queries completed!");