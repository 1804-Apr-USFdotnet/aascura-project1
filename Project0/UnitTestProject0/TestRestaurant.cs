using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClassLibraryProject0;
using System.Collections.Generic;

namespace UnitTestProject0
{
    [TestClass]
    public class TestRestaurant
    {
        [TestMethod]
        public void TestConstructorParam()
        {
            //Arrange
            string restaurantName = "Ryu's House of Pound Cakes";
            string restaurantAddress = "245 Challenger Path";
            string restaurantPhoneNumber = "7194328331";

            string reviewName = "Daigo \"THE BEAST\" Umehara";
            string reviewComment = "They're good.";
            decimal reviewRating = 7M;
            DateTime reviewDateTime = new DateTime(1999, 12, 28, 15, 37, 29);
            Review review = new Review(reviewName, reviewComment, reviewRating, reviewDateTime);
            List<Review> reviewList = new List<Review>();
            reviewList.Add(review);
            Restaurant actualRestaurant;
            Restaurant expectedRestaurant;
            //Act
            actualRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhoneNumber, reviewList);
            expectedRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhoneNumber, reviewList);

            //Assert

            Assert.AreEqual(expectedRestaurant.name, actualRestaurant.name);
            Assert.AreNotSame(expectedRestaurant.name, actualRestaurant.name);

            Assert.AreEqual(expectedRestaurant.address, actualRestaurant.address);
            Assert.AreNotSame(expectedRestaurant.address, actualRestaurant.address);

            Assert.AreEqual(expectedRestaurant.phoneNum, actualRestaurant.phoneNum);
            Assert.AreNotSame(expectedRestaurant.phoneNum, actualRestaurant.phoneNum);            
        }

        [TestMethod]
        public void TestConstructorCopy()
        {
            //Arrange
            string restaurantName = "Ryu's House of Pound Cakes";
            string restaurantAddress = "245 Challenger Path";
            string restaurantPhoneNumber = "7194328331";

            string reviewName = "Daigo \"THE BEAST\" Umehara";
            string reviewComment = "They're good.";
            decimal reviewRating = 7M;
            DateTime reviewDateTime = new DateTime(1999, 12, 28, 15, 37, 29);
            Review review = new Review(reviewName, reviewComment, reviewRating, reviewDateTime);
            List<Review> reviewList = new List<Review>();
            reviewList.Add(review);
            Restaurant actualRestaurant;
            Restaurant expectedRestaurant;
            expectedRestaurant = new Restaurant(restaurantName, restaurantAddress, restaurantPhoneNumber, reviewList);

            //Act
            actualRestaurant = new Restaurant(expectedRestaurant);

            //Assert
            Assert.AreNotSame(expectedRestaurant, actualRestaurant);
            Assert.AreEqual(expectedRestaurant.name, actualRestaurant.name);
            Assert.AreNotSame(expectedRestaurant.name, actualRestaurant.name);
            Assert.AreEqual(expectedRestaurant.address, actualRestaurant.address);
            Assert.AreNotSame(expectedRestaurant.address, actualRestaurant.address);
            Assert.AreEqual(expectedRestaurant.phoneNum, actualRestaurant.phoneNum);
            Assert.AreNotSame(expectedRestaurant.phoneNum, actualRestaurant.phoneNum);
        }

        [TestMethod]
        public void TestGetAverage()
        {
            //Arrange
            Review reviewLow = new Review("a", "a", 1, DateTime.Now);
            Review reviewMedium = new Review("a", "a", 5, DateTime.Now);
            Review reviewHigh = new Review("a", "a", 10, DateTime.Now);

            List<Review> reviewList = new List<Review>();

            Restaurant restaurantA = new Restaurant("a", "a", "a", reviewList);
            decimal expAvgA = 0;

            reviewList.Add(reviewMedium);
            Restaurant restaurantB = new Restaurant("b", "b", "b", reviewList);
            decimal expAvgB = 5;

            reviewList.Add(reviewLow);
            Restaurant restaurantC = new Restaurant("c", "c", "c", reviewList);
            decimal expAvgC = 3;

            reviewList.Add(reviewMedium);
            Restaurant restaurantD = new Restaurant("d", "d", "d", reviewList);
            decimal expAvgD = (5M + 1M + 5M) / 3M;

            //Act
            decimal actAvgA = restaurantA.GetAverage();
            decimal actAvgB = restaurantB.GetAverage();
            decimal actAvgC = restaurantC.GetAverage();
            decimal actAvgD = restaurantD.GetAverage();

            //Assert
            Assert.AreEqual(expAvgA, actAvgA);
            Assert.AreEqual(expAvgB, actAvgB);
            Assert.AreEqual(expAvgC, actAvgC);
            Assert.AreEqual(expAvgD, actAvgD);
        }


        /*        [TestMethod]
                public void TestCompareTo()
                {
                    //Arrange
                    Review reviewLow = new Review("a", "a", 1, DateTime.Now);
                    Review reviewMedium = new Review("a", "a", 5, DateTime.Now);
                    Review reviewHigh = new Review("a", "a", 10, DateTime.Now);

                    List<Review> reviewList = new List<Review>();

                    Restaurant restaurantA = new Restaurant("a", "a", "a", reviewList);
                    decimal expResA = 0;


                    reviewList.Add(reviewMedium);
                    Restaurant restaurantB = new Restaurant("b", "b", "b", reviewList);
                    decimal expResB = 5;

                    reviewList.Add(reviewLow);
                    Restaurant restaurantC = new Restaurant("c", "c", "c", reviewList);
                    decimal expResC = 3;

                    reviewList.Add(reviewMedium);
                    Restaurant restaurantD = new Restaurant("d", "d", "d", reviewList);
                    decimal expResD = (5M + 1M + 5M) / 3M;

                    //Act
                    int actDiffAB = restaurantA.CompareTo(restaurantB);
                    int actDiffBA = restaurantB.CompareTo(restaurantA);
                    int actDiffBC = restaurantB.CompareTo(restaurantC);
                    int actDiffBD = restaurantB.CompareTo(restaurantD);

                    //Assert

                    int
                    Assert.AreEqual(actDiffAB, (actDiffBA * -1));
                }*/

        [TestMethod]
        public void TestContains()
        {
            //Arrange
            string name = "Ryu's House of Pound Cakes";
            string address = "245 Challenger Path";
            string phoneNumber = "7194328331";
            List<Review> reviewList = new List<Review>();
            Restaurant restaurant = new Restaurant(name, address, phoneNumber, reviewList);
            
            //Act
            bool hasHouseLower = restaurant.Contains("house");
            bool hasHouseUpper = restaurant.Contains("HOUSE");
            bool hasShackLower = restaurant.Contains("shack");
            bool hasShackUpper = restaurant.Contains("SHACK");
            bool hasChallenger = restaurant.Contains("ChAlLeNgEr");
            bool has432 = restaurant.Contains("432");
            bool has789 = restaurant.Contains("789");

            //Assert
            Assert.IsTrue(hasHouseLower);
            Assert.IsTrue(hasHouseUpper);
            Assert.IsFalse(hasShackLower);
            Assert.IsFalse(hasShackUpper);
            Assert.IsTrue(hasChallenger);
            Assert.IsTrue(has432);
            Assert.IsFalse(has789);
        }
    }
}
