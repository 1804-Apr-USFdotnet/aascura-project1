using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using ClassLibraryProject0;

namespace Project1.Web.Models
{
    public class ReviewWeb
    {
        int Id;
        string ReviewerName;
        decimal Rating;
        string Comment;
        DateTime DateTime;

        public ReviewWeb()
        {

        }

        public ReviewWeb (Review toCopy)
        {
            Id = toCopy.Id;
            ReviewerName = toCopy.name;
            Rating = toCopy.rating;
            DateTime = toCopy.dateTime;
        }

        public Review ToLibrary()
        {
            return new Review(ReviewerName, Comment, Rating, DateTime);
        }
        

    }
}