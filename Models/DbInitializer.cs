using LostandFoundAnimals.Models;
using System;
using System.Linq;
using System.Diagnostics;
//namespace ContosoUniversity.Data
namespace LostandFoundAnimals.Models
{
    public static class DbInitializer
    {
        public static void Initialize(LostandFoundAnimalsContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Posts.
            if (context.Post.Any())
            {
                return;   // DB has been seeded
            }

            //var users = new User[]
            //{
            //    new User{UserName="Carson",EmailAddress="carson@pipo.edu"},
            //    new User{UserName="Meredith",EmailAddress="meredith@pipo.edu"}
            //};
            //foreach (User s in users)
            //{
            //    context.User.Add(s);
            //}
            //context.SaveChanges();
            var addresses = new Address[]
            {
                new Address{Line1="204 Apple Core Lane",City="Daytona Beach",ZipOrPostcode="20019",StateProvinceCounty="Florida"},
                new Address{Line1="8713 Biscuit and Gravy Street",City="Pensacola",ZipOrPostcode="42213",StateProvinceCounty="Florida"}

            };
            foreach (Address e in addresses)
            {
                context.Address.Add(e);
            }
            context.SaveChanges();


            var posts = new Post[]
            {
                new Post{PostText="Hi, I'm looking for my dog named Sally. " +
                            "She's just a coupl years old and I think I lost her maybe two or three weeks ago." +
                            "If you find her please let me know as soon as possible. Thanks!", AddressID=2, Date=DateTime.Parse("2005-09-01"),
                        LostOrFound="Lost",Resolved=false },
                new Post{PostText="Hi, I'm looking for my dog named Sally. " +
                            "She's just a coupl years old and I think I lost her maybe two or three weeks ago." +
                            "If you find her please let me know as soon as possible. Thanks!", AddressID=1, Date=DateTime.Parse("2005-05-23"),
                        LostOrFound="Found",Resolved=false }
            };
            foreach (Post c in posts)
            {
                context.Post.Add(c);
            }
            context.SaveChanges();

            var animals = new Animal[]
{
                new Animal{Gender="Male", PostID=1},
                new Animal{Gender="Female", PostID=2}
};
            foreach (Animal e in animals)
            {
                context.Animal.Add(e);
            }
            context.SaveChanges();
            var breeds = new Breed[]
            {
                new Breed{AnimalID=1,BreedName="Pug"},
                new Breed{AnimalID=2,BreedName="Poodle"},
                new Breed{AnimalID=2,BreedName="Pomeranian"}
            };
            foreach (Breed e in breeds)
            {
                context.Breed.Add(e);
            }
            context.SaveChanges();





        }
    }
}