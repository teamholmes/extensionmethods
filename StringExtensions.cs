using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Resources;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OpenPlatform.General.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Mtheond that trims a string to the chosen of character places
        /// </summary>
        /// <param name="input">The string to truncate</param>
        /// <param name="numchars">The number of characters to trim to</param>
        /// <param name="addtrailing">Should trailing dots be added</param>
        /// <returns></returns>
        public static String TrimforUI(this string input, int numchars, Boolean addtrailing = true)
        {

            try
            {
                string retval = string.Empty;

                string appender = "...";

                if (String.IsNullOrEmpty(input)) return retval;

                if (input.Length < numchars) return input;

                if (input.Length >= numchars) retval = input.Substring(0, numchars);

                if (addtrailing) retval += "...";

                return retval;
            }
            catch (Exception)
            {
                return input;
            }
        }

        /// <summary>
        /// Trima string but check for null first
        /// </summary>
        /// <param name="input">String to be trimmed</param>
        /// <returns></returns>
        public static String TrimCheckForNull(this string input)
        {

            string retval = input;

            if (!String.IsNullOrEmpty(retval))
            {
                retval = retval.Trim();
            }

            return retval;
        }


        /// <summary>
        /// Gets the nth character from a string
        /// </summary>
        /// <param name="input">The source string</param>
        /// <param name="position">The character position</param>
        /// <returns></returns>
        public static String GetNthCharacter(this string input, int position)
        {
            if (string.IsNullOrEmpty(input)) return string.Empty;

            return string.Format("{0}",input[position]);
        }


        /// <summary>
        /// Format a string to postcode format with spaces
        /// </summary>
        /// <param name="input">The postcode</param>
        /// <param name="removeallspaces"></param>
        /// <returns></returns>
        public static String ToFormattedPostCode(this string input, Boolean removeallspaces = false)
        {

            if (String.IsNullOrEmpty(input)) return input;

            StringBuilder output = new StringBuilder();


            input = input.Replace(" ", "").ToUpperCheckForNull();

            if (input.Length == 6)
            {
                output.Append(input.Substring(0, 3));
                output.Append(" ").Append(input.Substring(3, 3));
            }
            else if (input.Length == 7)
            {
                output.Append(input.Substring(0, 4));
                output.Append(" ").Append(input.Substring(4, 3));
            }
            else
            {
                output.Append(input);
            }
           
            if (removeallspaces)
            {
                return output.ToString().Replace(" ", "");
            }

            return output.ToString();
        }

        /// <summary>
        /// Methdo that removes all the spaces from a string
        /// </summary>
        /// <param name="input">The source string</param>
        /// <returns></returns>
        public static String RemoveAllSpaces(this string input)
        {

            string retval = input;

            if (!String.IsNullOrEmpty(retval))
            {
                retval = retval.Trim().Replace(" ", "");
            }

            return retval;
        }

        /// <summary>
        /// Checks if the contents of a string is an integer
        /// </summary>
        /// <param name="input">The source string</param>
        /// <returns></returns>
        public static Boolean IsInteger(this string input)
        {
            bool isNumeric = false;
            if (!String.IsNullOrEmpty(input))
            {
                int n;
                isNumeric = int.TryParse(input, out n);
            }

            return isNumeric;

        }


        /// <summary>
        /// Returns a string to lowercase but checks for a null string to start with
        /// </summary>
        /// <param name="input">The string to lowercase</param>
        /// <returns></returns>
        public static String ToLowerCheckForNull(this string input)
        {

            string retval = input;

            if (!String.IsNullOrEmpty(retval))
            {
                retval = retval.ToLower();
            }

            return retval;

        }

        /// <summary>
        /// Converts a string to uppercase with null checking
        /// </summary>
        /// <param name="input">Source string</param>
        /// <returns></returns>
        public static String ToUpperCheckForNull(this string input)
        {

            string retval = input;

            if (!String.IsNullOrEmpty(retval))
            {
                retval = retval.ToUpper();
            }

            return retval;

        }

        /// <summary>
        /// Checks if a string is not null or empty
        /// </summary>
        /// <param name="input">Source string</param>
        /// <returns></returns>
        public static Boolean IsNotNullOrEmpty(this string input)
        {

            if (String.IsNullOrEmpty(input)) return false;

            return true;
        }

        /// <summary>
        /// Method to returnt he number of uppercase characters contained in the string
        /// </summary>
        /// <param name="input">The source string</param>
        /// <returns></returns>
        public static int NumberOfUpperCaseCharacters(this string input)
        {
            if (String.IsNullOrEmpty(input)) return -1;

            return input.Where(char.IsUpper).Count();
        }


        /// <summary>
        /// Method to check if a string is null or and empty string
        /// </summary>
        /// <param name="input">Source string</param>
        /// <returns></returns>
        public static Boolean IsNullOrEmpty(this string input)
        {

            if (String.IsNullOrEmpty(input)) return true;

            return false;
        }


        /// <summary>
        /// Method that returns a populated string with specific content if the string is null or empty
        /// </summary>
        /// <param name="input">The source string</param>
        /// <param name="replacementtext">Replacement text if the string is null or empty</param>
        /// <returns></returns>
        public static string ReplaceIfNullOrEmpty(this string input, string replacementtext = "--")
        {

            if (String.IsNullOrEmpty(input))
            {
                input = replacementtext;
                return replacementtext;
            }

            return input;
        }


        /// <summary>
        /// Method that returns a string array split on a pipe symbol
        /// </summary>
        /// <param name="input">Source string</param>
        /// <returns></returns>
        public static string[] SplitOnPipe(this string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                throw new Exception("Cannot Split on a empty string");
            }

            string[] obitems = input.Split('|');
            return obitems;
        }

        /// <summary>
        /// Method that returns an array of ints from an array of strings
        /// </summary>
        /// <param name="input">String array containing only string representations of integers</param>
        /// <returns></returns>
        public static int[] ConvertStringArrayToIntArray(this string[] input)
        {
            if (input == null || input.Length == 0)
            {
                throw new Exception("Cannot Split on a empty string");
            }

            List<int> listofints = new List<int>();
            foreach (string str in input)
            {
                listofints.Add(int.Parse(str));
            }

            return listofints.ToArray();
        }

        /// <summary>
        /// Method that removes all windows invalid characters from a string
        /// </summary>
        /// <param name="input">Source string</param>
        /// <returns></returns>
        public static string RemoveAllInvalidFilenameChars(this string input)
        {
            if (String.IsNullOrEmpty(input))
            {
                return input;
            }

            return Path.GetInvalidFileNameChars().Aggregate(input, (current, c) => current.Replace(c.ToString(), string.Empty));

        }

        /// <summary>
        /// Method that add an s to a string if there is more than 1 e.g. row will become rows if the number passed through is greater than 1
        /// </summary>
        /// <param name="input">The source string</param>
        /// <param name="number">Count of items</param>
        /// <returns></returns>
        public static string PleuraliseByAddingS(this string input, int number)
        {
            if (!String.IsNullOrEmpty(input))
            {
                if (number == 1) return input;

                return string.Format("{0}s", input);
            }
            else
            {
                return null;
            }

        }

        /// <summary>
        /// Method that returns a file extension - assumes the filename/string contains a period
        /// </summary>
        /// <param name="input">Source string</param>
        /// <returns></returns>
        public static string GetFileExtention(this string input)
        {
            if (!String.IsNullOrEmpty(input))
            {
                return input.Remove(0, input.LastIndexOf('.') + 1);
            }
            else
            {
                return null;
            }

        }

       
        /// <summary>
        /// Random word generator
        /// </summary>
        /// <param name="input">Source string</param>
        /// <param name="numwords">The number of words you want to create in the return string</param>
        /// <returns></returns>
        public static string RandomWords(this string input, int numwords)
        {
            string[] words = new string[] { "Lorem", "ipsum", "dolor", "sit", "amet", "consectetur", "adipisicing", "elit", "sed", "do", "eiusmod", "tempor", "incididunt", "ut", "labore", "et", "dolore", "magna", "aliqua", "Ut", "enim", "ad", "minim", "veniam", "quis", "nostrud", "exercitation", "ullamco", "laboris", "nisi", "ut", "aliquip", "ex", "ea", "commodo", "consequat", "Duis", "aute", "irure", "dolor", "in", "reprehenderit", "in", "voluptate", "velit", "esse", "cillum", "dolore", "eu", "fugiat", "nulla", "pariatur", "Excepteur", "sint", "occaecat", "cupidatat", "non", "proident", "sunt", "in", "culpa", "qui", "officia", "deserunt", "mollit", "anim", "id", "est", "laborum" };

            string retval = string.Empty;

            int wordcount = words.Count();

            for (int i = 1; i <= numwords; i++)
            {
                int maxroute = 32;

                RNGCryptoServiceProvider randomcrypto = new RNGCryptoServiceProvider("test");
                byte[] randomBytes = new byte[maxroute * sizeof(int)];
                randomcrypto.GetBytes(randomBytes);
                int randomval = 0;
                for (int j = 0; j < maxroute; ++j)
                {
                    randomval = BitConverter.ToInt32(randomBytes, j * 4);
                    randomval &= 0x7fffffff;
                }

                int randomNumber = randomval % wordcount;

                retval += words[randomNumber];

                if (i < numwords) retval += " ";
            }
            return retval;

        }

       
        /// <summary>
        /// Performs a string replacement with null checking
        /// </summary>
        /// <param name="input">Source string</param>
        /// <param name="searchfor">substring to check for </param>
        /// <param name="replacewith">substring replacement</param>
        /// <returns></returns>
        public static String ReplaceCheckForNull(this string input, string searchfor, string replacewith)
        {

            string retval = input;

            if (!String.IsNullOrEmpty(retval))
            {
                retval = input.Replace(searchfor, replacewith);
            }

            return retval;

        }




    }
}
