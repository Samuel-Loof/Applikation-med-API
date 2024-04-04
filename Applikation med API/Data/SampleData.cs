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

                {
                    database.Products.Add(new Product
                    {
                        Name = "Kaffe",
                        Price = 60,
                        Category = "Livsmedel",
                        Description = "Ett fint malet kaffe från Colombia."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Te",
                        Price = 40,
                        Category = "Livsmedel",
                        Description = "Grönt te med en fräsch smak av citron."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Laptop",
                        Price = 10000,
                        Category = "Elektronik",
                        Description = "En kraftfull laptop perfekt för både arbete och spel."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Hörlurar",
                        Price = 800,
                        Category = "Elektronik",
                        Description = "Brusreducerande hörlurar med kristallklart ljud."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "E-boksläsare",
                        Price = 1400,
                        Category = "Elektronik",
                        Description = "Håll tusentals böcker i handen med vår lättviktiga e-boksläsare."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Köksknivar",
                        Price = 900,
                        Category = "Hem",
                        Description = "Ett set med professionella köksknivar för varje tillfälle."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Grytset",
                        Price = 1500,
                        Category = "Hem",
                        Description = "Högkvalitativa grytor och pannor för dina matlagningsbehov."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Roman",
                        Price = 200,
                        Category = "Böcker",
                        Description = "En fängslande roman som du inte kan lägga ifrån dig."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Facklitteratur",
                        Price = 250,
                        Category = "Böcker",
                        Description = "Expandera dina kunskaper med vår facklitteratur."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "T-shirt",
                        Price = 150,
                        Category = "Kläder",
                        Description = "Bekväm och stilren t-shirt i 100% bomull."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Jeans",
                        Price = 500,
                        Category = "Kläder",
                        Description = "Slitstarka jeans som passar till allt."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Klocka",
                        Price = 2600,
                        Category = "Accessoarer",
                        Description = "En elegant klocka som kompletterar varje outfit."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Backpack",
                        Price = 700,
                        Category = "Resor",
                        Description = "Rymlig ryggsäck perfekt för vandring eller stadsliv."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Bluetooth Speaker",
                        Price = 300,
                        Category = "Elektronik",
                        Description = "Portabel högtalare med otroligt ljud för storleken."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Yogamatta",
                        Price = 350,
                        Category = "Sport",
                        Description = "Högkvalitativ yogamatta för din dagliga yoga."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Löparskor",
                        Price = 850,
                        Category = "Sport",
                        Description = "Lätta och bekväma löparskor för alla terränger."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Sängkläder",
                        Price = 500,
                        Category = "Hem",
                        Description = "Mjuka och behagliga sängkläder för en god natts sömn."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Plånbok",
                        Price = 300,
                        Category = "Accessoarer",
                        Description = "Stilren plånbok i äkta läder."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Handväska",
                        Price = 1200,
                        Category = "Accessoarer",
                        Description = "Elegant handväska i högkvalitativt material."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Solglasögon",
                        Price = 900,
                        Category = "Accessoarer",
                        Description = "Moderna solglasögon som skyddar mot UV-strålning."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Skäggolja",
                        Price = 250,
                        Category = "Skönhet",
                        Description = "Naturlig skäggolja för ett mjukt och välvårdat skägg."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Ansiktskräm",
                        Price = 350,
                        Category = "Skönhet",
                        Description = "Återfuktande ansiktskräm för alla hudtyper."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Parfym",
                        Price = 700,
                        Category = "Skönhet",
                        Description = "Förförisk doft som håller hela dagen."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Kökshandduk",
                        Price = 100,
                        Category = "Hem",
                        Description = "Absorberande kökshandduk i snygg design."
                    });
                }

                {
                    database.Products.Add(new Product
                    {
                        Name = "Vattenflaska",
                        Price = 200,
                        Category = "Sport",
                        Description = "Återanvändbar vattenflaska i rostfritt stål."
                    });
                }
            }

            database.SaveChanges();
        }
    }
}
