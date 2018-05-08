using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DataAccessLayerProject0;

namespace ClassLibraryProject0
{
    public static class RestaurantMapper
    {
        public static restaurant ToDataLayer(Restaurant restaurantLib)
        {
            restaurant restaurantData = new restaurant();
            restaurantData.id = restaurantLib.id;
            restaurantData.name = restaurantLib.name;
            restaurantData.address = restaurantLib.address;
            restaurantData.phoneNumber = restaurantLib.phoneNum;


            foreach (var curReviewLib in restaurantLib.reviews)
            {
                restaurantData.reviews.Add(ReviewMapper.ToDataLayer(curReviewLib, restaurantData));
            }

            return restaurantData;
        }

        public static Restaurant ToLibLayer(restaurant restaurantData)
        {
            List<Review> reviewsLib = new List<Review>();
            Restaurant restaurantLib = new Restaurant(restaurantData.name, restaurantData.address, restaurantData.phoneNumber, reviewsLib, restaurantData.id);
            foreach(review curRevData in restaurantData.reviews)
            {
                restaurantLib.reviews.Add(ReviewMapper.ToLibLayer(curRevData, restaurantLib));
            }
            return restaurantLib;
        }
    }
}
