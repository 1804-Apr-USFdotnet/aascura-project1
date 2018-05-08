using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClassLibraryProject0;

namespace WebApplicationProject1.Models
{
    public class ReviewWeb
    {
        public int Id { get; set; }
        public string ReviewerName { get; set; }
        public string Comment { get; set; }
        public float Rating { get; set; }
        public DateTime DateTime { get; set; }

        public RestaurantWeb Restaurant { get; set; }

        public ReviewWeb()
        {

        }

        public ReviewWeb (Review reviewLib, RestaurantWeb owner)
        {
            Id = reviewLib.id;
            ReviewerName = reviewLib.name;
            Rating = (float) reviewLib.rating;
            Comment = reviewLib.comment;
            DateTime = reviewLib.dateTime;
            Restaurant = owner;
        }

        public Review ToLibLayer(Restaurant owner)
        {
            Review reviewLib = new Review(ReviewerName, Comment, (decimal) Rating, DateTime, Id, owner);

            return reviewLib;
        }
    }

    public static partial class ListExtensions
    {
        public static ReviewWeb GetById(this List<ReviewWeb> list, int id)
        {
            ReviewWeb target = null;
            foreach (var currentRev in list)
            {
                if (currentRev.Id == id)
                {
                    target = currentRev;
                    break;
                }
            }
            return target;
        }
    }
}