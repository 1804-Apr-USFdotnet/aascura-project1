using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClassLibraryProject0;

namespace WebApplicationProject1.Models
{
    public class RestaurantWeb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public List<ReviewWeb> Reviews;

        public RestaurantWeb()
        {
            Reviews = new List<ReviewWeb>();
        }

        public RestaurantWeb(Restaurant restaurantLib)
        {
            Id = restaurantLib.id;
            Name = restaurantLib.name;
            Address = restaurantLib.address;
            PhoneNumber = restaurantLib.phoneNum;
            Reviews = new List<ReviewWeb>();

            foreach (var currentReview in restaurantLib.reviews)
            {
                Reviews.Add(new ReviewWeb(currentReview, this));
            }
        }

        public Restaurant ToLibLayer()
        {
            List<Review> reviewsLib = new List<Review>();
            Restaurant restaurantLib = new Restaurant(Name, Address, PhoneNumber, reviewsLib, Id);
            foreach (var curReviewWeb in Reviews)
            {
                restaurantLib.reviews.Add(curReviewWeb.ToLibLayer(restaurantLib));
            }
            return restaurantLib;
        }

        public float GetAverage()
        {
            Restaurant test = ToLibLayer();
            decimal testD = test.GetAverage();
            float average = (float)testD;//this.ToLibLayer().GetAverage();
            return average;
        }
    }


    public static partial class ListExtensions
    {
        public static RestaurantWeb GetById(this List<RestaurantWeb> list, int id)
        {
            RestaurantWeb target = null;
            foreach (var currentRest in list)
            {
                if (currentRest.Id == id)
                {
                    target = currentRest;
                    break;
                }
            }
            return target;
        }
    }
}