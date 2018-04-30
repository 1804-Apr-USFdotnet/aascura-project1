using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using ClassLibraryProject0;
using DataAccessLayerProject0;
namespace Project0
{
    partial class Program
    {
        public static void InitializeFromDb(out RestaurantList restaurants, Project0_dbCrud dbCrud)
        {
            List<restaurant> dbRestaurants = dbCrud.GetRestaurants();
            restaurants = new RestaurantList();
            foreach (restaurant current in dbRestaurants)
            {
                List<Review> toAddReviews = new List<Review>();
                foreach (review currentReview in current.reviews)
                {
                    toAddReviews.Add(new Review(currentReview.reviewerName, currentReview.comment, (decimal)currentReview.rating, currentReview.date));
                }
                restaurants.Add(new Restaurant(current.name, current.address, current.phoneNumber, toAddReviews));
            }
        }
    }
}
