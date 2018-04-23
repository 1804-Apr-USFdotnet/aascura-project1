using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using ClassLibraryProject0;

namespace UnitTestProject0
{
    [TestClass]
    public class TestRestaurant
    {
        [TestMethod]
        public void TestConstructorParam()
        {
            //Arrange
            string name = "Ryu's House of Pound Cakes";
            string address = "245 Challenger Path";
            string phoneNumber = "719-432-8331";

            string reviewName = "Daigo \"THE BEAST\" Umehara";
            string reviewComment = "They're good.";
            decimal reviewRating = 7M;
            DateTime reviewDateTime = new DateTime(1999, 12, 28, 15, 37, 29);
            //Act
            //Assert
        }

        [TestMethod]
        public void TestConstructorCopy()
        {
            //Arrange
            //Act
            //Assert
        }

        [TestMethod]
        public void TestGetAverage()
        {
            //Arrange
            //Act
            //Assert
        }
    }
}
