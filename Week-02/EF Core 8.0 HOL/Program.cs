using Microsoft.EntityFrameworkCore;
using RetailInventory.Data;
using RetailInventory.Models;

using var context = new AppDbContext();

// Create database if it doesn't exist
await context.Database.EnsureCreatedAsync();

// Insert sample data only if empty
if (!await context.Categories.AnyAsync())
{
    var electronics = new Category { Name = "Electronics" };
    var groceries = new Category { Name = "Groceries" };

    await context.Categories.AddRangeAsync(electronics, groceries);

    await context.Products.AddRangeAsync(
        new Product { Name = "Laptop", Price = 75000, Category = electronics },
        new Product { Name = "Rice Bag", Price = 1200, Category = groceries });

    await context.SaveChangesAsync();
}

Console.WriteLine("All Products:");
var products = await context.Products.ToListAsync();
foreach (var p in products)
    Console.WriteLine($"{p.Id}. {p.Name} - ₹{p.Price}");

var product = await context.Products.FindAsync(1);
Console.WriteLine($"\nFound: {product?.Name}");

var expensive = await context.Products.FirstOrDefaultAsync(p => p.Price > 50000);
Console.WriteLine($"Expensive Product: {expensive?.Name}");
