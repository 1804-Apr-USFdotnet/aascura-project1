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

            string expectedName = String.Copy(name);
            string expectedComment = String.Copy(comment);
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

            Assert.AreNotSame(expectedName, review.name);
            Assert.AreNotSame(expectedName, review.comment);
            Assert.AreNotSame(expectedRating, review.rating);
            Assert.AreNotSame(expectedDateTime, review.dateTime);

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
            Assert.AreNotSame(expectedReview, review);

            Assert.AreEqual(expectedReview.name, review.name);
            Assert.AreEqual(expectedReview.rating, review.rating);
            Assert.AreEqual(expectedReview.dateTime, review.dateTime);
            Assert.AreEqual(expectedReview.comment, review.comment);

            Assert.AreNotSame(expectedReview.name, review.name);
            Assert.AreNotSame(expectedReview.rating, review.rating);
            Assert.AreNotSame(expectedReview.dateTime, review.dateTime);
            Assert.AreNotSame(expectedReview.comment, review.comment);
        }

        [TestMethod]
        public void TestCopy()
        {
            //Arrange
            string baseName = "Miek Russ";
            string baseComment = "God-like food.";
            decimal baseRating = 10.0M;
            DateTime baseDate = DateTime.UtcNow;

            Review baseReview = new Review(baseName, baseComment, baseRating, baseDate);

            Review expected, actual;
            //Act
            expected = baseReview.Copy();
            actual = baseReview.Copy();
            baseReview = new Review("Not Miek Russ", "Trash-tier", 0M, new DateTime(1,1,1));


            //Assert
            Assert.AreNotSame(expected, actual);
            Assert.AreEqual(expected.name, actual.name);
            Assert.AreEqual(expected.comment, actual.comment);
            Assert.AreEqual(expected.rating, actual.rating);
            Assert.AreEqual(expected.dateTime, actual.dateTime);
            Assert.AreNotSame(expected.name, actual.name);
            Assert.AreNotSame(expected.comment, actual.comment);
            Assert.AreNotSame(expected.rating, actual.rating);
            Assert.AreNotSame(expected.dateTime, actual.dateTime);
        }
    }
}
