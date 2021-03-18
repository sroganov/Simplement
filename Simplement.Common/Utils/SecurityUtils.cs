using SoftLegion.Common.Extensions;
using System;
using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace SoftLegion.Common.Utils
{
    public static class SecurityUtils
    {
        [Obsolete("Intended for compatibility reasons ONLY. Use SHA512 hashing instead.")]
        public static string GetHashMD5(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            var result = new StringBuilder();
            try
            {
                using (var md5 = new MD5CryptoServiceProvider())
                {
                    var data = Encoding.UTF8.GetBytes(value);
                    var hash = md5.ComputeHash(data);

                    foreach (var b in hash)
                        result.Append(b.ToString("x2").ToLower());
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetFullMessage());
            }

            return result.ToString();
        }

        public static string GetHashSHA512(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentNullException(nameof(value));

            try
            {
                using (var sha = new SHA512Managed())
                {
                    var data = Encoding.UTF8.GetBytes(value);
                    var hash = sha.ComputeHash(data);

                    return Convert.ToBase64String(hash);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.GetFullMessage());
            }

            return string.Empty;
        }
    }
}