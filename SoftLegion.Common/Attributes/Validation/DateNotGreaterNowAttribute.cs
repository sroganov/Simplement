using SoftLegion.Common.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SoftLegion.Common.Attributes
{
    /// <summary>
    /// Кастомный атрибут валидации даты не больше текущей
    /// </summary>
    public class DateNotGreaterNowAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationResult = ValidationResult.Success;
            if (value == null)
                return validationResult;

            var date = DateTime.Parse(value.ToString() ?? string.Empty);
            if (date.CompareTo(DateTime.Now) <= 0)
                return validationResult;

            if (ErrorMessageResourceType != null && !string.IsNullOrEmpty(ErrorMessageResourceName))
                validationResult = new ValidationResult(LocalizationExtensions.GetResourceString(ErrorMessageResourceType, ErrorMessageResourceName), new List<string> { validationContext.DisplayName });
            else
                validationResult = new ValidationResult(CommonResources.Validation_Error);

            return validationResult;
        }
    }
}
