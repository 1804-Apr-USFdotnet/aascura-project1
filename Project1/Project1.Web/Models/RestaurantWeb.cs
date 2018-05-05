using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClassLibraryProject0;

namespace Project1.Web.Models
{
    public class RestaurantWeb
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNum { get; set; }
        List<ReviewWeb> Reviews;

        public RestaurantWeb()
        {
            Reviews = new List<ReviewWeb>();
        }

        public RestaurantWeb(Restaurant toCopy)
        {
            Id = toCopy.Id;
            Name = toCopy.name;
            Address = toCopy.address;
            PhoneNum = toCopy.phoneNum;
            Reviews = new List<ReviewWeb>();

            foreach (Review item in toCopy.GetReviews())
            {
                Reviews.Add(new ReviewWeb(item));
            }
        }

        public Restaurant ToLibrary()
        {
            List<Review> reviewsLibrary = new List<Review>();
            foreach (var current in Reviews)
            {
                reviewsLibrary.Add(current.ToLibrary());
            }
            return new Restaurant(Name, Address, PhoneNum, reviewsLibrary, Id);
        }

    }
}