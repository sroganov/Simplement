using SoftLegion.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace SoftLegion.Common.Attributes
{
    /// <summary>
    /// Кастомный атрибут валидации непустого GUIDa
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class GuidNotEmptyAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var result = ValidationResult.Success;

            if (value == null)
                return result;

            var guid = Guid.Parse(value.ToString());
            if (guid != Guid.Empty)
                return result;

            if (ErrorMessageResourceType != null && !string.IsNullOrEmpty(ErrorMessageResourceName))
                result = new ValidationResult(LocalizationExtensions.GetResourceString(ErrorMessageResourceType, ErrorMessageResourceName));
            else
                result = new ValidationResult(CommonResources.Validation_InvalidGuidString);

            return result;
        }
    }
}
