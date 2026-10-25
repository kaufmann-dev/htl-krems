using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace warehouse.model
{
    class Program
    {
        static async Task Main(string[] args) {
            Console.WriteLine("Hello World!");
            Console.WriteLine("Hello World!");

            var factory = new WarehouseContextFactory();
            var context = factory.CreateDbContext(args);

            var porridge = new Dish{Title = "Breakfast Porridge", Description = "fantastic"};
            context.dishes.Add(porridge);

            await context.SaveChangesAsync();
            Console.WriteLine("Added Porridge successfull");

            var dishes = await (from d in context.dishes where d.Title.Contains("Porridge") select d).ToListAsync();
            Console.WriteLine($"{dishes[0].Id}");
    
        }
    }
}