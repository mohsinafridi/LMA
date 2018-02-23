using LMA.Data.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace LMA.Data
{
    public class DbInitialize
    {
        public static void Seed(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<LMADbContext>();

                // add Customer
                var mohsin = new Customer { Name = "Mohsin Azam" };
                var basit = new Customer { Name = "Basit" };
                var mehak = new Customer { Name = "Mehak" };
                var hayat = new Customer { Name = "Hayat" };

                context.Cusotmers.Add(mohsin);
                context.Cusotmers.Add(basit);
                context.Cusotmers.Add(mehak);
                context.Cusotmers.Add(hayat);

                //Add Author
                var author = new Author
                {
                    Name = "Umaira Ahmad",
                    Books = new List<Book>()
                    {
                        new Book{ Name ="Abe e Hayat" },
                        new Book{ Name ="Pir e Kamil" },
                    }
                };

                var author1 = new Author
                {
                    Name = "Mehak Hayat",
                    Books = new List<Book>()
                    {
                        new Book{ Name ="Jannat k Patay" },
                        new Book{ Name ="abe e Mohsin" },
                        new Book{ Name ="Abe Zam Zam" },
                    }
                };
                context.Authors.Add(author);
                context.Authors.Add(author1);


                context.SaveChanges();
            }

        }
    }
}
