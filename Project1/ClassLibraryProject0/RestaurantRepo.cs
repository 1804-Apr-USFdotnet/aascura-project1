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

        public void CreateRestaurant(Restaurant toCreate)
        {
            dbCrud.Create(RestaurantMapper.ToDataLayer(toCreate));
        }

        public void DeleteRestaurant(int toDeleteId)
        {
            dbCrud.Delete(dbCrud.GetRestaurantById(toDeleteId));
        }

        public IEnumerable<Restaurant> GetRestaurants()
        {
            IEnumerable<restaurant> dbRestaurants = dbCrud.GetRestaurants();
            List<Restaurant> restaurants = new List<Restaurant>();
            foreach (restaurant current in dbRestaurants)
            {
                List<Review> toAddReviews = new List<Review>();
                Restaurant newRestLib = new Restaurant(current.name, current.address, current.phoneNumber, toAddReviews, current.id);
                foreach (review currentReview in current.reviews)
                {
                    newRestLib.reviews.Add(new Review(currentReview.reviewerName, currentReview.comment, (decimal)currentReview.rating, currentReview.date, currentReview.id, newRestLib));
                }
                restaurants.Add(newRestLib);
            }
            return restaurants;
        }

        public IEnumerable<Review> GetReviews()
        {
            List<Review> reviewsLib = new List<Review>();
            IEnumerable<review> dbReviews = dbCrud.GetReviews();

            foreach (review curRevData in dbReviews)
            {
                Restaurant restLib = RestaurantMapper.ToLibLayer(curRevData.restaurant);
                reviewsLib.Add(new Review(curRevData.reviewerName, curRevData.comment, (decimal)curRevData.rating, curRevData.date, curRevData.id, restLib));
            }

            return reviewsLib;
        }

        public void UpdateRestaurant(Restaurant editFrom)
        {
            dbCrud.Update(RestaurantMapper.ToDataLayer(editFrom));
        }

        public void CreateReview(Review toCreate)
        {
            dbCrud.Create(ReviewMapper.ToDataLayer(toCreate, RestaurantMapper.ToDataLayer(toCreate.restaurant)));
        }

        public void DeleteReview(int toDeleteId)
        {
            dbCrud.Delete(dbCrud.GetReviewById(toDeleteId));
        }

        public void UpdateReview(Review editFrom)
        {
            dbCrud.Update(ReviewMapper.ToDataLayer(editFrom, RestaurantMapper.ToDataLayer(editFrom.restaurant)));
        }

        public Restaurant GetRestaurantById(int id)
        {
            Restaurant restLib = RestaurantMapper.ToLibLayer(dbCrud.GetRestaurantById(id));
            return restLib;
        }

        /*public Review GetReviewById(int id)
        {
            Review revLib = ReviewMapper.ToLibLayer(dbCrud.GetReviewById(id));
        }*/

    }
}
