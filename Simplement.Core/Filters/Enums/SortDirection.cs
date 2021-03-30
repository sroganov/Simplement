using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Simplement.Core
{
    /// <summary>
    /// Specifies how items in a list are sorted.
    /// </summary>
    [JsonConverter(typeof(StringEnumConverter))]
    public enum SortDirection
    {
        /// <summary>
        /// Ascending - sort from smallest to largest.
        /// </summary>
        Asc = 1,

        /// <summary>
        /// Descending - sort from largest to smallest.
        /// </summary>
        Desc = 2
    }
}
