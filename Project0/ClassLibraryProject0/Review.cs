using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibraryProject0
{
    [DataContract]
    public class Review
    {
        public static decimal MAX_RATING = 10M;
        public static decimal MIN_RATING = 0M;


        public int id { get; private set; }
        public decimal _rating;
        [DataMember]
        public string comment { get; private set; }
        [DataMember]
        public string name { get; private set; }
        [DataMember]
        public DateTime dateTime { get; private set; }

        public Review(string name, string comment, decimal rating, DateTime dateTime)
        {
            id = -1;
            this.name = String.Copy(name);
            this.comment = String.Copy(comment);
            this.rating = rating;
            this.dateTime = dateTime;
        }

        public Review(string name, string comment, decimal rating, DateTime dateTime, int id)
        {
            this.id = id;
            this.name = String.Copy(name);
            this.comment = String.Copy(comment);
            this.rating = rating;
            this.dateTime = dateTime;
        }


        public Review(Review toCopy)
        {
            id = toCopy.id;
            name = String.Copy(toCopy.name);
            comment = String.Copy(toCopy.comment);
            rating = toCopy.rating;
            dateTime = toCopy.dateTime;
        }

        public decimal rating
        {
            get { return _rating; }
            set
            {
                if (value > MAX_RATING)
                {
                    _rating = MAX_RATING;
                }
                else if (value < MIN_RATING)
                {
                    _rating = MIN_RATING;
                }
                else
                {
                    _rating = value;
                }
            }
        }

        public Review Copy()
        {
            Review toReturn = new Review(String.Copy(name), String.Copy(comment), rating, dateTime);
            return toReturn;
        }
    }
}
