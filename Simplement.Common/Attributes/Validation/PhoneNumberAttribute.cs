using SoftLegion.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SoftLegion.Common.Attributes
{
    /// <summary>
    /// Кастомный атрибут валидации телефонного номера
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PhoneNumberAttribute : ValidationAttribute
    {
        private const string PhonePattern = @"\+?\d{9,13}";

        private const int PhoneNumberMaxLength = 15;
        private const int PhoneNumberMinLength = 9;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
                return ValidationResult.Success;

            var phoneNumber = value.ToString();
            var pattern = new Regex(PhonePattern, RegexOptions.IgnoreCase | RegexOptions.CultureInvariant);

            if (phoneNumber.Length <= PhoneNumberMaxLength && phoneNumber.Length >= PhoneNumberMinLength && pattern.IsMatch(phoneNumber))
                return ValidationResult.Success;

            if (ErrorMessageResourceType != null && !string.IsNullOrEmpty(ErrorMessageResourceName))
                return new ValidationResult(LocalizationExtensions.GetResourceString(ErrorMessageResourceType, ErrorMessageResourceName));

            return new ValidationResult(CommonResources.Validation_Error);

        }
    }
}
