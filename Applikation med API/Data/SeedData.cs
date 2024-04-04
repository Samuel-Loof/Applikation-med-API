//using Applikation_med_API.Data;
//using Applikation_med_API.Models;
//using Microsoft.EntityFrameworkCore;

//public static class SeedData
//{
//    public static void Initialize(IServiceProvider serviceProvider)
//    {
//        using (var context = new AppDbContext(
//            serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
//        {
//            // Look for any products.
//            if (context.Products.Any())
//            {
//                return;   // DB has been seeded
//            }

//            //context.Products.AddRange(
//            //new Product { Id = 1, Name = "Kaffe", ImageFileName = "kaffe.jpg", Price = 59.99m, Category = "Drycker", Description = "Ett fint malet kaffe från Colombia." },
//            //new Product { Id = 2, Name = "Te", ImageFileName = "te.jpg", Price = 39.99m, Category = "Drycker", Description = "Grönt te med en fräsch smak av citron." },
//            //new Product { Id = 3, Name = "Laptop", ImageFileName = "laptop.jpg", Price = 9999.99m, Category = "Elektronik", Description = "En kraftfull laptop perfekt för både arbete och spel." },
//            //new Product { Id = 4, Name = "Hörlurar", ImageFileName = "horlurar.jpg", Price = 799.99m, Category = "Elektronik", Description = "Brusreducerande hörlurar med kristallklart ljud." },
//            //new Product { Id = 5, Name = "E-boksläsare", ImageFileName = "ebook.jpg", Price = 1399.99m, Category = "Elektronik", Description = "Håll tusentals böcker i handen med vår lättviktiga e-boksläsare." },
//            //new Product { Id = 6, Name = "Köksknivar", ImageFileName = "knivar.jpg", Price = 899.99m, Category = "Hem", Description = "Ett set med professionella köksknivar för varje tillfälle." },
//            //new Product { Id = 7, Name = "Grytset", ImageFileName = "grytor.jpg", Price = 1499.99m, Category = "Hem", Description = "Högkvalitativa grytor och pannor för dina matlagningsbehov." },
//            //new Product { Id = 8, Name = "Roman", ImageFileName = "roman.jpg", Price = 199.99m, Category = "Böcker", Description = "En fängslande roman som du inte kan lägga ifrån dig." },
//            //new Product { Id = 9, Name = "Facklitteratur", ImageFileName = "facklitteratur.jpg", Price = 249.99m, Category = "Böcker", Description = "Expandera dina kunskaper med vår facklitteratur." },
//            //new Product { Id = 10, Name = "T-shirt", ImageFileName = "tshirt.jpg", Price = 149.99m, Category = "Kläder", Description = "Bekväm och stilren t-shirt i 100% bomull." },
//            //new Product { Id = 11, Name = "Jeans", ImageFileName = "jeans.jpg", Price = 499.99m, Category = "Kläder", Description = "Slitstarka jeans som passar till allt." },
//            //new Product { Id = 12, Name = "Klocka", ImageFileName = "klocka.jpg", Price = 2599.99m, Category = "Accessoarer", Description = "En elegant klocka som kompletterar varje outfit." },
//            //new Product { Id = 13, Name = "Backpack", ImageFileName = "backpack.jpg", Price = 699.99m, Category = "Resor", Description = "Rymlig ryggsäck perfekt för vandring eller stadsliv." },
//            //new Product { Id = 14, Name = "Bluetooth Speaker", ImageFileName = "speaker.jpg", Price = 299.99m, Category = "Elektronik", Description = "Portabel högtalare med otroligt ljud för storleken." },
//            //new Product { Id = 15, Name = "Yogamatta", ImageFileName = "yogamatta.jpg", Price = 349.99m, Category = "Sport", Description = "Högkvalitativ yogamatta för din dagliga yoga." },
//            //new Product { Id = 16, Name = "Löparskor", ImageFileName = "loparskor.jpg", Price = 849.99m, Category = "Sport", Description = "Lätta och bekväma löparskor för alla terränger." },
//            //new Product { Id = 17, Name = "Sängkläder", ImageFileName = "sangklader.jpg", Price = 499.99m, Category = "Hem", Description = "Mjuka och behagliga sängkläder för en god natts sömn." },
//            //new Product { Id = 18, Name = "Plånbok", ImageFileName = "planbok.jpg", Price = 299.99m, Category = "Accessoarer", Description = "Stilren plånbok i äkta läder." },
//            //new Product { Id = 19, Name = "Handväska", ImageFileName = "handvaska.jpg", Price = 1199.99m, Category = "Accessoarer", Description = "Elegant handväska i högkvalitativt material." },
//            //new Product { Id = 20, Name = "Solglasögon", ImageFileName = "solglasogon.jpg", Price = 899.99m, Category = "Accessoarer", Description = "Moderna solglasögon som skyddar mot UV-strålning." },
//            //new Product { Id = 21, Name = "Skäggolja", ImageFileName = "skaggolja.jpg", Price = 249.99m, Category = "Skönhet", Description = "Naturlig skäggolja för ett mjukt och välvårdat skägg." },
//            //new Product { Id = 22, Name = "Ansiktskräm", ImageFileName = "ansiktskram.jpg", Price = 349.99m, Category = "Skönhet", Description = "Återfuktande ansiktskräm för alla hudtyper." },
//            //new Product { Id = 23, Name = "Parfym", ImageFileName = "parfym.jpg", Price = 699.99m, Category = "Skönhet", Description = "Förförisk doft som håller hela dagen." },
//            //new Product { Id = 24, Name = "Kökshandduk", ImageFileName = "kokshandduk.jpg", Price = 99.99m, Category = "Hem", Description = "Absorberande kökshandduk i snygg design." },
//            //new Product { Id = 25, Name = "Vattenflaska", ImageFileName = "vattenflaska.jpg", Price = 199.99m, Category = "Sport", Description = "Återanvändbar vattenflaska i rostfritt stål." }
//            //);

//            //context.SaveChanges();
//        }
//    }
//}