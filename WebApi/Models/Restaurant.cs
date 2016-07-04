using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Restaurant
    {
        public int RestaurantID { get; set; }
        public string RestaurantName { get; set; }
        public int Rating { get; set; }
        public int NumberOfRatings { get; set; }
        public int SumOfRatings { get; set; }
    }
}