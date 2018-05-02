using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayerProject0;

namespace ClassLibraryProject0
{
    public class RestaurantRepo
    {
        Project0_dbCrud dbCrud;

        public RestaurantRepo()
        {
            dbCrud = new Project0_dbCrud();
        }
        
        public RestaurantList GetRestaurants()
        {
            List<restaurant> dbRestaurants = dbCrud.GetRestaurants();
            RestaurantList restaurants = new RestaurantList();
            foreach (restaurant current in dbRestaurants)
            {
                List<Review> toAddReviews = new List<Review>();
                foreach (review currentReview in current.reviews)
                {
                    toAddReviews.Add(new Review(currentReview.reviewerName, currentReview.comment, (decimal)currentReview.rating, currentReview.date));
                }
                restaurants.Add(new Restaurant(current.name, current.address, current.phoneNumber, toAddReviews));
            }
            return restaurants;
        }

    }
}
