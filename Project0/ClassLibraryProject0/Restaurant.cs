using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ClassLibraryProject0
{
    [DataContract]
    public class Restaurant : IComparable<Restaurant>
    {
        [DataMember]
        public string name { get; private set; }
        [DataMember]
        public string address { get; private set; }
        [DataMember]
        public string phoneNum { get; private set; }

        [DataMember]
        private List<Review> reviews;

        public Restaurant(string name, string address, string phoneNum, List<Review> reviews)
        {
            this.name = (string)name.Clone();
            this.address = (string)address.Clone();
            this.phoneNum = (string)phoneNum.Clone();
            this.reviews = new List<Review>();

            foreach (Review current in reviews)
            {
                this.reviews.Add(new Review(current));
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

        public List<Review> GetReviews()
        {
            List<Review> toReturn = new List<Review>();
            foreach (Review current in reviews)
            {
                toReturn.Add(current.Clone());
            }
            return toReturn;
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

        public int CompareTo(Restaurant other)
        {
            decimal difference;
            if (other == null)
            {
                return 1;
            }
            difference = this.GetAverage() - other.GetAverage();
            return (int) difference;
        }

        public bool Contains(string toFind)
        {
            bool isFound = false;

            if (name.Contains(toFind))
            {
                isFound = true;
            }
            if (address.Contains(toFind))
            {
                isFound = true;
            }
            if (phoneNum.Contains(toFind))
            {
                isFound = true;
            }
            return isFound;
        }

        public Restaurant Copy ()
        {
            Restaurant copy = new Restaurant(this);
            return copy;
        }
    }
}
