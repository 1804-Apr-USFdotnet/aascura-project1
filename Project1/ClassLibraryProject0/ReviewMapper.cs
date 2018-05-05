using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayerProject0;

namespace ClassLibraryProject0
{
    public static class ReviewMapper
    {
        public static Review ToLibLayer(review review)
        {
            return new Review(review.reviewerName, review.comment, (decimal)review.rating, review.date, review.id);
        }

        public static review ToDataLayer(Review reviewLib)
        {
            review reviewData = new review();

            reviewData.reviewerName  = reviewLib.name;
            reviewData.comment  = reviewLib.comment;
            reviewData.rating  = (float) reviewLib.rating;
            reviewData.date  = reviewLib.dateTime;

            return reviewData;
        }
    }
}
