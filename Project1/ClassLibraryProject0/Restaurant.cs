using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;
using DataAccessLayerProject0;

namespace ClassLibraryProject0
{
    [DataContract]
    public class Restaurant : IEntity
    {
        [DataMember]
        public string name { get; private set; }
        [DataMember]
        public string address { get; private set; }
        [DataMember]
        public string phoneNum { get; private set; }
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime Modified { get; set; }

        [DataMember]
        private List<Review> reviews;

        public Restaurant()
        {
            reviews = new List<Review>();
        }

        public Restaurant(string name, string address, string phoneNum, List<Review> reviews, int id)
        {
            this.Id = id;
            this.name = String.Copy(name);
            this.address = String.Copy(address);
            this.phoneNum = String.Copy(phoneNum);
            this.reviews = new List<Review>();

            foreach (Review current in reviews)
            {
                this.reviews.Add(new Review(current));
            }
        }

        public Restaurant(string name, string address, string phoneNum, List<Review> reviews)
        {
            Id = -1;
            this.name = String.Copy(name);
            this.address = String.Copy(address);
            this.phoneNum = String.Copy(phoneNum);
            this.reviews = new List<Review>();

            foreach (Review current in reviews)
            {
                this.reviews.Add(new Review(current));
            }
        }

        public Restaurant(Restaurant toCopy)
        {
            Id = toCopy.Id;
            name = String.Copy(toCopy.name);
            address = String.Copy(toCopy.address);
            phoneNum = String.Copy(toCopy.phoneNum);
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
                toReturn.Add(current.Copy());
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
            return (reviews.Count > 0)? (ratingSum / reviews.Count) : 0;
        }

        public bool Contains(string toFind)
        {
            bool isFound = false;

            if (name.ToUpper().Contains(toFind.ToUpper()))
            {
                isFound = true;
            }
            if (address.ToUpper().Contains(toFind.ToUpper()))
            {
                isFound = true;
            }
            if (phoneNum.ToUpper().Contains(toFind.ToUpper()))
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
