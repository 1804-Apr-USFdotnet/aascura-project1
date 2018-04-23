using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LibraryCodeChallenge
{
    public static class Palindrome
    {
        static bool IsAlphaNum(char toCheck)
        {
            bool result = false;
            Regex regex = new Regex("[a-zA-Z0-9]");
            if (regex.IsMatch(toCheck.ToString()))
            {
                result = true;
            }
            return result;
        }

        static void ToAlphaNum() { }

        public static bool IsValidAlphaNum(string toTest)
        {
            bool result = true;
            string tempCopy = (string) toTest.Clone();
            int strLen;
            tempCopy = tempCopy.ToUpper(); //case handling
            //punctuation handling

            for (int i = 0; i < tempCopy.Length; i++)
            {
                if (!IsAlphaNum(tempCopy[i]))
                {
                    tempCopy = tempCopy.Remove(tempCopy.IndexOf(tempCopy[i]), 1);
                    i--;
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
