using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryProject0
{
    public class Restaurant
    {
        string name;
        string address;
        string phoneNum;

        List<Review> reviews;

        public Restaurant(string name, string address, string phoneNum, List<Review> reviews)
        {
            this.name = (string)name.Clone();
            this.address = (string)address.Clone();
            this.phoneNum = (string)phoneNum.Clone();
            this.reviews = new List<Review>();

            foreach (Review current in reviews)
            {
                reviews.Add(new Review(current));
            }
        }

        public Restaurant(Restaurant toCopy)
        {
            name = (string)toCopy.name.Clone();
            address = (string)toCopy.address.Clone();
            phoneNum = (string)toCopy.phoneNum.Clone();
            reviews = new List<Review>();

            foreach (Review current in toCopy.reviews)
            {
                reviews.Add(new Review(current));
            }
        }

        public decimal GetAverage()
        {
            decimal ratingSum = 0;
            foreach (Review current in reviews)
            {
                ratingSum += current.rating;
            }
            return (ratingSum / reviews.Count);
        }
    }
}
