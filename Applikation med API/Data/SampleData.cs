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


            if (!database.Products.Any())
            {

                
                    database.Products.Add(new Product
                    {
                        Name = "Kaffe",
                        Price = 60,
                        Category = "Livsmedel",
                        Description = "Ett fint malet kaffe från Colombia.",
                        ImagePath = "kaffe.jpg"
                    });


                
                    database.Products.Add(new Product
                    {
                        Name = "Te",
                        Price = 40,
                        Category = "Livsmedel",
                        Description = "Grönt te med en fräsch smak av citron.",
                        ImagePath = "tea.jpg"
                    });


                
                    database.Products.Add(new Product
                    {
                        Name = "Laptop",
                        Price = 10000,
                        Category = "Elektronik",
                        Description = "En kraftfull laptop perfekt för både arbete och spel.",
                        ImagePath = "laptop.jpg"
                    });


                
                    database.Products.Add(new Product
                    {
                        Name = "Hörlurar",
                        Price = 800,
                        Category = "Elektronik",
                        Description = "Brusreducerande hörlurar med kristallklart ljud.",
                        ImagePath = "headphones.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "iPad",
                        Price = 4000,
                        Category = "Elektronik",
                        Description = "Underhållning vart du än befinner dig med denna utmärkta iPad.",
                        ImagePath = "ipad.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Köksknivar",
                        Price = 1000,
                        Category = "Hem",
                        Description = "Ett set med professionella köksknivar för varje tillfälle.",
                        ImagePath = "knivset.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Gjutjärnsgryta",
                        Price = 2000,
                        Category = "Hem",
                        Description = "Högkvalitativ gryta som håller i många år framöver.",
                        ImagePath = "gryta.jpg"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "A Song Of Ice And Fire",
                        Price = 500,
                        Category = "Böcker",
                        Description = "Prisbelönade fantasy böcker.",
                        ImagePath = "bok.jpg"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Harry Potter",
                        Price = 500,
                        Category = "Böcker",
                        Description = "Hela Harry Potter serien.",
                        ImagePath = "bok2.jpg"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "T-shirt",
                        Price = 150,
                        Category = "Kläder",
                        Description = "Bekväm och stilren t-shirt i 100% bomull.",
                        ImagePath = "t-shirt.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Jeans",
                        Price = 600,
                        Category = "Kläder",
                        Description = "Slitstarka jeans som passar till allt.",
                        ImagePath = "jeans.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Klocka",
                        Price = 3000,
                        Category = "Accessoarer",
                        Description = "En elegant klocka som kompletterar varje outfit.",
                        ImagePath = "klocka.png"
                        
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Ryggsäck",
                        Price = 700,
                        Category = "Resor",
                        Description = "Rymlig ryggsäck perfekt för vandring eller stadsliv.",
                        ImagePath = "ryggsäck.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Högtalare",
                        Price = 1000,
                        Category = "Elektronik",
                        Description = "Portabel högtalare med otroligt ljud för storleken.",
                        ImagePath = "högtalare.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Yogamatta",
                        Price = 350,
                        Category = "Sport",
                        Description = "Högkvalitativ yogamatta för din dagliga yoga.",
                        ImagePath = "yogamatta.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Löparskor",
                        Price = 850,
                        Category = "Sport",
                        Description = "Lätta och bekväma löparskor för alla terränger.",
                        ImagePath = "skor.jpg"
                        
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Stekpanna",
                        Price = 700,
                        Category = "Hem",
                        Description = "Bäst i test stekpanna.",
                        ImagePath = "stekpanna.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Plånbok",
                        Price = 300,
                        Category = "Accessoarer",
                        Description = "Stilren plånbok i äkta läder.",
                        ImagePath = "plånbok.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Fotboll",
                        Price = 600,
                        Category = "Sport",
                        Description = "En mycket hållbar fotboll för både match och träning.",
                        ImagePath = "fotboll.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Solglasögon",
                        Price = 900,
                        Category = "Accessoarer",
                        Description = "Moderna solglasögon som skyddar mot UV-strålning.",  
                        ImagePath = "solglasögon.jpg"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Skäggolja",
                        Price = 200,
                        Category = "Skönhet",
                        Description = "Naturlig skäggolja för ett mjukt och välvårdat skägg.",
                        ImagePath = "skäggolja.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Ansiktskräm",
                        Price = 150,
                        Category = "Skönhet",
                        Description = "Återfuktande ansiktskräm för alla hudtyper.",
                        ImagePath = "ansiktskräm.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Parfym",
                        Price = 700,
                        Category = "Skönhet",
                        Description = "Förförisk doft som håller hela dagen.",
                        ImagePath = "parfym.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Glas",
                        Price = 50,
                        Category = "Hem",
                        Description = "Glas för valfri dryck.",
                        ImagePath = "glas.webp"
                    });
                

                
                    database.Products.Add(new Product
                    {
                        Name = "Vattenflaska",
                        Price = 200,
                        Category = "Sport",
                        Description = "Återanvändbar vattenflaska i rostfritt stål.",
                        ImagePath = "vattenflaska.jpg"
                    });
                
            }

            database.SaveChanges();
        }
    }
}
