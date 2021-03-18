using SoftLegion.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace SoftLegion.Common.Attributes
{
    /// <summary>
    /// Кастомный атрибут валидации даты не больше даты другого параметра или заданного периода
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class DateNotGreaterThanAttribute : ValidationAttribute
    {
        /// <summary>
        /// Период лет, относительно которого и текущей даты будет происходить сравнение. 
        /// </summary>
        public int Period { get; set; } = default;

        /// <summary>
        /// Название другого свойства модели, с которым будет идти сравнение.
        /// </summary>
        public string OtherProperty { get; set; } = string.Empty;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var validationResult = ValidationResult.Success;
            if (value == null)
                return validationResult;

            if (!string.IsNullOrEmpty(OtherProperty) && Period != default)
            {
                if (IsValidPlusPeriod(value) && IsValidOtherParameter(value, validationContext) == PropertyValidationStatus.Success)
                    return validationResult;

                if (ErrorMessageResourceType != null && !string.IsNullOrEmpty(ErrorMessageResourceName))
                {
                    validationResult = new ValidationResult(
                        string.Format(LocalizationExtensions.GetResourceString(ErrorMessageResourceType, ErrorMessageResourceName), Period, OtherProperty));
                }
                else
                {
                    validationResult = new ValidationResult(CommonResources.Validation_Error);
                }
            }
            else if (!string.IsNullOrEmpty(OtherProperty))
            {
                switch (IsValidOtherParameter(value, validationContext))
                {
                    case PropertyValidationStatus.FiledIsNull:
                        validationResult = new ValidationResult(string.Format(CommonResources.Validation_UnknowPropery, OtherProperty));
                        break;
                    case PropertyValidationStatus.IsInvalid:
                        if (ErrorMessageResourceType != null && !string.IsNullOrEmpty(ErrorMessageResourceName))
                        {
                            validationResult = new ValidationResult(
                                string.Format(LocalizationExtensions.GetResourceString(ErrorMessageResourceType, ErrorMessageResourceName), OtherProperty));
                        }
                        else
                        {
                            validationResult = new ValidationResult(CommonResources.Validation_Error);
                        }
                        break;
                    case PropertyValidationStatus.CommonError:
                        validationResult = new ValidationResult(CommonResources.Validation_InvalidDateTime);
                        break;
                }
            }
            else if (Period != default(int) && !IsValidPlusPeriod(value))
            {
                if (ErrorMessageResourceType != null && !string.IsNullOrEmpty(ErrorMessageResourceName))
                    validationResult = new ValidationResult(string.Format(LocalizationExtensions.GetResourceString(ErrorMessageResourceType, ErrorMessageResourceName), Period));
                else
                    validationResult = new ValidationResult(CommonResources.Validation_Error);
            }

            return validationResult;
        }

        private PropertyValidationStatus IsValidOtherParameter(object value, ValidationContext validationContext)
        {
            if (value == null || validationContext == null)
                return PropertyValidationStatus.CommonError;

            var containerType = validationContext.ObjectInstance.GetType();
            var field = containerType.GetProperty(OtherProperty);

            var extensionValue = field?.GetValue(validationContext.ObjectInstance, null);
            if (extensionValue == null)
                return PropertyValidationStatus.ExtensionValueIsNull;

            if (field.PropertyType != typeof(DateTime) && (!field.PropertyType.IsGenericType || field.PropertyType != typeof(DateTime?)))
                return PropertyValidationStatus.CommonError;

            var toValidate = (DateTime)value;
            var referenceProperty = (DateTime)field.GetValue(validationContext.ObjectInstance, null);

            return toValidate > referenceProperty
                ? PropertyValidationStatus.IsInvalid
                : PropertyValidationStatus.Success;

        }

        private bool IsValidPlusPeriod(object value)
        {
            var result = true;
            var toValidate = (DateTime)value;

            if (toValidate > DateTime.Now.AddYears(Period).AddDays(-1))
                result = false;

            return result;
        }
    }
}
