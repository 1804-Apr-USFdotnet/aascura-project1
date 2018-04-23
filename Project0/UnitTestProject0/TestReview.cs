using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClassLibraryProject0;

namespace UnitTestProject0
{
    [TestClass]
    public class TestReview
    {
        [TestMethod]
        public void TestConstructorParam()
        {
            //Assemble
            string name = "Miek Russ";
            string comment = "This place is the best";
            decimal rating = 10M;
            DateTime dateTime = new DateTime(2009, 9, 9, 9, 9, 9);

            Review review;

            string expectedName = (string)name.Clone();
            string expectedComment = (string)comment.Clone();
            decimal expectedRating = rating;
            DateTime expectedDateTime = dateTime;

            //Act
            review = new Review(name, comment, rating, dateTime);

            name = "Not Mike Russ";
            comment = "Garbage place to eat";
            rating = 4M;
            dateTime = dateTime.AddTicks(1L);

            //Assert

            Assert.AreEqual(expectedName, review.name);
            Assert.AreEqual(expectedRating, review.rating);
            Assert.AreEqual(expectedComment, review.comment);
            Assert.AreEqual(expectedDateTime, review.dateTime);

            Assert.AreNotEqual(name, review.name);
            Assert.AreNotEqual(rating, review.rating);
            Assert.AreNotEqual(comment, review.comment);
            Assert.AreNotEqual(dateTime, review.dateTime);
        }

        [TestMethod]
        public void TestConstructorCopy()
        {
            //Assemble
            string name = "Floe";
            string comment = "This place is the not 4th, unlike Mike Ross.";
            decimal rating = 7M;
            DateTime dateTime = new DateTime(2011, 11, 11, 11, 11, 11);

            Review baseReview = new Review(name, comment, rating, dateTime);
            Review expectedReview = new Review(name, comment, rating, dateTime);
            Review review;

            //Act
            review = new Review(baseReview);
            baseReview = new Review("Peter Rosa", "Man, why are my games so good?  Like this food?", 9.5M, new DateTime(2017, 2, 14, 7, 8, 54));
            //Assert

            Assert.AreNotEqual(baseReview, review);
            Assert.AreEqual(expectedReview.name, review.name);
            Assert.AreEqual(expectedReview.rating, review.rating);
            Assert.AreEqual(expectedReview.dateTime, review.dateTime);
            Assert.AreEqual(expectedReview.comment, review.comment);
        }
    }
}
