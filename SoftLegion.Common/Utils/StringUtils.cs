using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SoftLegion.Common.Utils
{
    public static class StringUtils
    {
        public const string Space = " ";
        public const string Dot = ".";
        public const string Zero = "0";

        public static readonly CultureInfo DefaultCulture = new CultureInfo("ru-RU");

        /// <summary>
        /// Creates numerating style looks like: A, B, C... AA, AB.. etc.
        /// Supports numbering from A to ZZ. Count must be from 1 to 702.
        /// </summary>
        public static List<string> GetAlphabeticNumbering(int count)
        {
            if (count < 1 || count > 702)
                throw new ArgumentOutOfRangeException(nameof(count));

            var result = new List<string>();

            var letters = CommonResources.Misc_EnglishLettersCapital.ToArray();
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

        /// <summary>
        /// Returns formated with group separators string of given number.
        /// </summary>
        [Obsolete("Use .ToString('N') instead.")]
        public static string SpacesIfNumber(string value, CultureInfo formatter = null)
        {
            return decimal.TryParse(value, out decimal decimalValue)
                ? SpacesIfNumber(decimalValue, formatter)
                : value;
        }

        /// <summary>
        /// Returns formated with group separators string of given number.
        /// </summary>
        [Obsolete("Use .ToString('N') instead.")]
        public static string SpacesIfNumber(decimal? value, CultureInfo formatter = null)
        {
            return value.HasValue
                ? SpacesIfNumber(value.Value, formatter)
                : string.Empty;
        }

        /// <summary>
        /// Returns formated with group separators string of given number.
        /// </summary>
        [Obsolete("Use .ToString('N') instead.")]
        public static string SpacesIfNumber(decimal value, CultureInfo formatter = null)
        {
            if (value == decimal.Zero)
                return Zero;

            return value.ToString("N", formatter ?? DefaultCulture).Replace(Dot, Space);
        }

        public static List<string> GetEnglishLettersArray(int countOfArray)
        {
            var result = new List<string>();
            var letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToArray();
            int firstIndex = 0;
            int nextIndex = 0;
            for (int i = 0; i < countOfArray; i++)
            {
                if (i >= letters.Count())
                {
                    if (nextIndex >= letters.Count())
                    {
                        firstIndex++;
                        nextIndex = 0;
                    }
                    result.Add(letters[firstIndex].ToString() + letters[nextIndex]);
                    nextIndex++;
                }
                else
                {
                    result.Add(letters[i].ToString());
                }
            }

            return result;
        }

        public static string DateToString_dd_MM_yyyy(DateTime date)
        {
            return date.ToString("dd.MM.yyyy");
        }
    }
}
