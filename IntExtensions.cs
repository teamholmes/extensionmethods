using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenPlatform.General.Extensions
{
    public static class IntExtensions
    {

        /// <summary>
        /// Method that checks if an int is an odd number
        /// </summary>
        /// <param name="sourceint">Source integer</param>
        /// <returns></returns>
        public static bool IsOdd(this int sourceint)
        {
            return (sourceint % 2) != 0;
        }


        /// <summary>
        /// Method that returns if an intener is an even number
        /// </summary>
        /// <param name="sourceint">Source integer</param>
        /// <returns></returns>
        public static bool IsEven(this int sourceint)
        {
            return (sourceint % 2) == 0;
        }

        /// <summary>
        /// Ordinal number extension adder
        /// </summary>
        /// <param name="position">The current list position</param>
        /// <returns></returns>
        public static string nTh(this int position)
        {

            int j = position % 10;
            int k = position % 100;

            if (j == 1 && k != 11) return "st";
            else if (j == 2 && k != 12) return "nd";
            else if (j == 3 && k != 13) return "rd";

            return "th";


        }


    }
}
