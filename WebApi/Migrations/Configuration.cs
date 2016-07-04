namespace WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApi.Models;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<WebApi.Models.WebApiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApi.Models.WebApiContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            var restaurants = new List<Restaurant>
            {
             new Restaurant

             {  
                 RestaurantName = "Happy Foods",
                 SumOfRatings = 10,
                 NumberOfRatings = 1,
                 Rating = 10
               

             },

            
            
             new Restaurant

{                 RestaurantName = "Cornucopia",
                 SumOfRatings = 8,
                 NumberOfRatings = 1,
                  Rating = 8
               

             },
             
             new Restaurant

{                 RestaurantName = "Vegan as it should be",
                   SumOfRatings = 10,
                 NumberOfRatings = 1,
                  Rating = 10
               

             }
            };
            restaurants.ForEach(s => context.Restaurants.AddOrUpdate(r => r.RestaurantName, s));
            context.SaveChanges();
         
            
        }
    }
}
