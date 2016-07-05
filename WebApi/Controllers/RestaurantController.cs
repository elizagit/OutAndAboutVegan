using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

using WebApi.Models;

namespace WebApi.Controllers
{
    public class RestaurantController : ApiController
    {
        private WebApiContext db = new WebApiContext();

        // GET api/Restaurant
    
        public IEnumerable<Restaurant> GetRestaurants()
        {
            return db.Restaurants.AsEnumerable();
        }

      


        //GET api/Restaurant/Cornucopia   ----> Get restaurant by name
        
        public Restaurant Get(string name)
        {


            return db.Restaurants.FirstOrDefault<Restaurant>(r => r.RestaurantName == name);
        }


        // PUT api/Restaurant/Cornucopia  ---> update a restaurant
  
        public HttpResponseMessage PutRestaurant(string name, Restaurant restaurant)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }

            if (name != restaurant.RestaurantName)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            db.Entry(restaurant).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // POST api/Restaurant
       
        public HttpResponseMessage PostRestaurant(Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                db.Restaurants.Add(restaurant);
                db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, restaurant);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = restaurant.RestaurantID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // DELETE api/Restaurant/RestaurantName
        public HttpResponseMessage DeleteRestaurant(int RestaurantID )
        {
           Restaurant restaurant = db.Restaurants.Find(RestaurantID);
            if (restaurant == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
           
            db.Restaurants.Remove(restaurant);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }

            return Request.CreateResponse(HttpStatusCode.OK, restaurant);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}