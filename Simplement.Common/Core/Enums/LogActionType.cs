using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace SoftLegion.Common.Core.Enums
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum LogActionType
    {
        [Display(ResourceType = typeof(CommonResources), Name = "Log_Action_Create")]
        Create,

        [Display(ResourceType = typeof(CommonResources), Name = "Log_Action_Update")]
        Update,

        [Display(ResourceType = typeof(CommonResources), Name = "Log_Action_Delete")]
        Delete
    }
}