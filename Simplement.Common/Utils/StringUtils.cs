using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Simplement.Common.Resources;

namespace Simplement.Common.Utils
{
    public static class StringUtils
    {
        public const string Space = " ";
        public const string Dot = ".";
        public const string Zero = "0";

        public static CultureInfo DefaultCulture { get; } = new("ru-RU");

        /// <summary>
        ///  Creates numerating style looks like: A, B, C... AA, AB.. etc.
        ///  Supports numbering from A to ZZ. Count must be from 1 to 702.
        /// </summary>
        public static List<string> GetAlphabeticNumbering(int count)
        {
            if (count < 1 || count > 702)
                throw new ArgumentOutOfRangeException(nameof(count));

            var result = new List<string>();

            var letters = Global.Misc_EnglishLettersCapital.ToArray();
            var firstIndex = 0;
            var nextIndex = 0;

            for (var i = 0; i < count; i++)
            {
                if (i < letters.Length)
                {
                    result.Add(letters[i].ToString());
                    continue;
                }

                if (nextIndex >= letters.Length)
                {
                    firstIndex++;
                    nextIndex = 0;
                }

                result.Add(letters[firstIndex].ToString() + letters[nextIndex]);
                nextIndex++;
            }

            return result;
        }
    }
}
