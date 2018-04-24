using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace ClassLibraryProject0
{
    //[Serializable()]
    [DataContract]
    public class Review //: ISerializable
    {
        public static decimal MAX_RATING = 10M;
        public static decimal MIN_RATING = 0M;

//        [DataMember]
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

        /*public Review(SerializationInfo info, StreamingContext context)
        {
            
        }*/

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

        /*public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("ReviewerName", name);
            info.AddValue("ReviewRating", rating);
            info.AddValue("ReviewComment", comment);
            info.AddValue("ReviewDate", dateTime);
        }*/
    }
}
