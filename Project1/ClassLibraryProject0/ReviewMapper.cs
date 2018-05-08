using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using DataAccessLayerProject0;

namespace ClassLibraryProject0
{
    class ReviewMapper
    {
        public static review ToDataLayer(Review reviewLib, restaurant restaurantData)
        {
            review reviewData = new review();
            reviewData.id = reviewLib.id;
            reviewData.reviewerName = reviewLib.name;
            reviewData.comment = reviewLib.comment;
            reviewData.rating = (float)reviewLib.rating;
            reviewData.date = reviewLib.dateTime;
            reviewData.restaurant = restaurantData;

            return reviewData;
        }

        public static Review ToLibLayer(review reviewData, Restaurant restaurantLib)
        {
            Review reviewLib = new Review(reviewData.reviewerName, reviewData.comment, (decimal) reviewData.rating, reviewData.date, reviewData.id, restaurantLib);
            return reviewLib;
        }
    }
}
