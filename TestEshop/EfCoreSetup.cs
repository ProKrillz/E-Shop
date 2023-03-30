using Bogus;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace TestEshop
{
    public class EfCoreSetup
    {
        public static EfCoreContext CreateContext([CallerMemberName]string dbName = "")
        {
            DbContextOptionsBuilder builder = new();
            builder.UseInMemoryDatabase(dbName);
            var context = new EfCoreContext(builder.Options);
            context.Database.EnsureCreated();

            context.Add(new ZipCode()
            {
                ZipCodeId = 6400,
                City = "Sønderborg"
            });
            context.Add(new User()
            {
                UserId = Guid.Parse("ea28b4cc-065b-414a-a8a3-59224d2fb567"),
                FirstName = "Thomas",
                Lastname = "Damkjær",
                Email = "thomasdamkjaer@gmail.com",
                Address = "Alsgade 42 A",
                Disable = false,
                Fk_ZipCodeId = 6400
            });
            context.Add(new Category()
            {
                CategoryId = 1,
                Name = "Sodavand",
            });
            context.AddRange(new Brand()
            {
                BrandId = 1,
                Name = "Faxekondi"
            },
            new Brand()
            {
                BrandId = 2,
                Name = "Konami"
            });
            context.AddRange(new Product()
            {
                Name = "Booster",
                Description = "Smager godt",
                Price = 10,
                Fk_BrandId = 1,
            },
            new Product()
            {
                Name = "card",
                Description = "Hygge spil",
                Price = 20,
                Fk_BrandId = 2,
            });
            context.Add(new Delivery()
            {
                DeliveryId = 1,
                DeliveryOption = "Postnord"
            });
            context.Add(new Payment()
            {
                PaymentId = 1,
                PaymentOption = "Master kort"
            });
            context.Add(new Ordre()
            {
                OrdreId = 1,
                Fk_DeliveryId = 1,
                Fk_PayementId = 1,
                Fk_UserId = Guid.Parse("ea28b4cc-065b-414a-a8a3-59224d2fb567")
            });
            context.Add(new OrdreProduct()
            {
                Fk_OrdreId = 1,
                Fk_ProductId = 1,
            });

            context.SaveChanges();

            return context;
        }
    }
}
