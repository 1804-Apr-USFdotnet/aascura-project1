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
        public static Restaurant ToLibLayer(restaurant restData)
        {

            Restaurant restLib;
            List<Review> reviewsLib = new List<Review>();

            foreach (var reviewData in restData.reviews)
            {
                reviewsLib.Add(ReviewMapper.ToLibLayer(reviewData));
            }

            restLib = new Restaurant(restData.name, restData.address, restData.phoneNumber, reviewsLib, restData.id);

            return restLib;
        }

        public static restaurant ToDataLayer(Restaurant restLib)
        {
            restaurant restData = new restaurant();

            restData.id  = restLib.Id;
            restData.address = restLib.address;
            restData.phoneNumber  = restLib.phoneNum;
            restData.name = restLib.name;

            foreach (Review reviewLib in restLib.GetReviews())
            {
                restData.reviews.Add(ReviewMapper.ToDataLayer(reviewLib));
            }

            return restData;
        }
    }
}
