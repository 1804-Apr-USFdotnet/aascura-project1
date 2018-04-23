using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using LibraryCodeChallenge;

namespace UnitTestCodeChallenge
{
    [TestClass]
    public class UnitTestPalindrome
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Assemble Phase
            //Positive tests
            string candidate0 = "racecar";
            string candidate1 = "Racecar";
            string candidate2 = "1221";
            string candidate3 = "never Odd, or Even.";

            //Negative tests
            string candidate4 = "1231";
            string candidate5 = "aBc";

            //expected results
            bool expResult0, expResult1, expResult2, expResult3;
            expResult0 = expResult1 = expResult2 = expResult3 = true;
            bool expResult4, expResult5;
            expResult4 = expResult5 = false;

            //results-to-be
            bool result0, result1, result2, result3, result4, result5;

            //Act
            result0 = Palindrome.IsValidAlphaNum(candidate0);
            result1 = Palindrome.IsValidAlphaNum(candidate1);
            result2 = Palindrome.IsValidAlphaNum(candidate2);
            result3 = Palindrome.IsValidAlphaNum(candidate3);
            result4 = Palindrome.IsValidAlphaNum(candidate4);
            result5 = Palindrome.IsValidAlphaNum(candidate5);

            //Assert
            Assert.AreEqual(expResult0, result0);
            Assert.AreEqual(expResult1, result1);
            Assert.AreEqual(expResult2, result2);
            Assert.AreEqual(expResult3, result3);
            Assert.AreEqual(expResult4, result4);
            Assert.AreEqual(expResult5, result5);
        }
    }
}
