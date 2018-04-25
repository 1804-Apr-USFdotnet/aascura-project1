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

        public decimal _rating;
        [DataMember]
        public string comment { get; private set; }
        [DataMember]
        public string name { get; private set; }
        [DataMember]
        public DateTime dateTime { get; private set; }

        public Review(string name, string comment, decimal rating, DateTime dateTime)
        {
            this.name = (string)name.Clone();
            this.comment = (string)comment.Clone();
            this.rating = rating;
            this.dateTime = dateTime;
        }

        public Review(Review toCopy)
        {
            name = (string)toCopy.name.Clone();
            comment = (string)toCopy.comment.Clone();
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

        public Review Clone()
        {
            Review toReturn = new Review((string)name.Clone(), (string)comment.Clone(), rating, dateTime);
            return toReturn;
        }
    }
}
