using System.Collections.Generic;
using System.Linq;

namespace SoftLegion.Common.Utils
{
    public static class PhoneNumberUtils
    {
        private static List<string> _mobileCodes = new List<string> { "90", "91", "93", "94", "95", "97", "98", "99" };

        /// <summary>
        /// Форматирование номера телефона - убирание пробелов, скобок, тире.
        /// </summary>
        /// <param name="value">Номер телефона</param>
        /// <param name="appendCountryCode">Флаг добавления кода страны в результат</param>
        /// <returns>Результат</returns>
        public static string FormatNumberUzbkeSpecial(string value, bool appendCountryCode = false)
        {
            var phone = value.Replace("+998", "").Replace("-", "").Replace("(", "").Replace(")", "").Trim();
            return appendCountryCode ? $"+998{phone}" : phone;
        }

        /// <summary>
        /// Проверка номера телефона на соответствие маски префикса мобильных операторов РУз.
        /// </summary>
        /// <param name="value">Номер телефона</param>
        /// <returns>Результат</returns>
        public static bool IsUzbekMobilePhone(string value)
        {
            var phone = FormatNumberUzbkeSpecial(value);
            return phone.Length == 9 && _mobileCodes.Any(p => phone.StartsWith(p));
        }
    }
}
