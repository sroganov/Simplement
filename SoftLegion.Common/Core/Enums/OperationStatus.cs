using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace SoftLegion.Common.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum OperationStatus
    {
        Success = 0,
        Failed = 1,
        NotFound = 2,
        InvalidModel = 4,
        ConfirmationRequired = 5
    }
}