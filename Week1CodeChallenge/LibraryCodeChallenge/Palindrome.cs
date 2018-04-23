using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryCodeChallenge
{
    public static class Palindrome
    {
        public static bool isValidAlphaNum(string toTest)
        {
            bool result = true;
            string tempCopy = (string) toTest.Clone();
            int strLen;

            tempCopy = tempCopy.ToUpper();

            strLen = tempCopy.Length;
            for( int i = 0; i < strLen; i++)
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
