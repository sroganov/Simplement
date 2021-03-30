using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;
using Simplement.Common.Extensions;

namespace Simplement.Common.Utils
{
    public static class SecurityUtils
    {
        /// <summary>
        /// Returns SHA512 hash for given string.
        /// </summary>
        public static string GetHashSHA512(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            try
            {
                using var sha = new SHA512Managed();

                var data = Encoding.UTF8.GetBytes(value);
                var hash = sha.ComputeHash(data);

                return Convert.ToBase64String(hash);
            }
            catch (Exception ex)
            {
                if (Debugger.IsAttached)
                    Debug.WriteLine(ex.GetFullMessage());
            }

            return string.Empty;
        }
    }
}
