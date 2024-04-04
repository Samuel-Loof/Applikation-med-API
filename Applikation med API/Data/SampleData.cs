using Applikation_med_API.Models;

namespace Applikation_med_API.Data
{
    public class SampleData
    {
        public static void Create(AppDbContext database)
        {
            // If there are no fake accounts, add some.
            string fakeIssuer = "https://example.com";
            if (!database.Accounts.Any(a => a.OpenIDIssuer == fakeIssuer))
            {
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "1111111111",
                    Name = "Brad"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "2222222222",
                    Name = "Angelina"
                });
                database.Accounts.Add(new Account
                {
                    OpenIDIssuer = fakeIssuer,
                    OpenIDSubject = "3333333333",
                    Name = "Will"
                });
            }

            //database.Products.Add(new Product { Id = 1, Name = "Kaffe", ImageFileName = "kaffe.jpg", Price = 59.99m, Category = "Drycker", Description = "Ett fint malet kaffe från Colombia." });
            if (!database.Products.Any())
            {
                database.Products.Add(new Product
                {
                    Name = "Kafe",
                    Price = 10,
                    Category = "dricka",
                    Description = "gott"
                }); 
            }

            database.SaveChanges();
        }
    }
}
