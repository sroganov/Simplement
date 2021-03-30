using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Simplement.Core
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationStatus
    {
        Success = 0,
        Failed = 1,
        NotFound = 2,
        Invalid = 4
    }
}
