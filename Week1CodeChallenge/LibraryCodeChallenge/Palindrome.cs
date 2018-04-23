using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCodeChallenge
{
    public static class Palindrome
    {
        static bool IsAlphaNum(char toCheck)
        {
            bool result = true;
            if (false)
            {
                result = false;
            }
            return result;
        }
        public static bool isValidAlphaNum(string toTest)
        {
            bool result = true;
            string tempCopy = (string) toTest.Clone();
            int strLen;
            bool isAlphaNumeric = false;
            int alphaNumIndex = 0;
            tempCopy = tempCopy.ToUpper(); //case handling
            //punctuation handling

            for (int i = 0; i < tempCopy.Length; i++)
            {
                if (!IsAlphaNum(tempCopy[alphaNumIndex]))
                {
                    tempCopy = tempCopy.Remove(toTest[i], 1);
                    i = 0;
                }
            }
            strLen = tempCopy.Length;
            for( int i = 0; i < strLen; i++) //actual comparison (consider cutting in half)
            {
                if (tempCopy[i] != tempCopy[strLen - (i + 1)])
                {
                    result = false;
                }
            }

            return result;
        }
    }
}
