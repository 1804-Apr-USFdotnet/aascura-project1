using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayerProject0;

namespace ClassLibraryProject0
{
    public class RestaurantRepo : IRepository<Restaurant>
    {
        Project0_dbCrud dbCrud;

        public RestaurantRepo()
        {
            dbCrud = new Project0_dbCrud();
        }

        public void Create(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Restaurant entity)
        {
            throw new NotImplementedException();
        }

        public Restaurant GetById(int id)
        {
            throw new NotImplementedException();
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
                    toAddReviews.Add(new Review(currentReview.reviewerName, currentReview.comment, (decimal)currentReview.rating, currentReview.date, current.id));
                }
                restaurants.Add(new Restaurant(current.name, current.address, current.phoneNumber, toAddReviews, current.id));
            }
            return restaurants;
        }

        public void Update(Restaurant entity)
        {
            throw new NotImplementedException();
        }
    }
}
