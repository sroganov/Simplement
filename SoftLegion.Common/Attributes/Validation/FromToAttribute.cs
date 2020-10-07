using SoftLegion.Common.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace SoftLegion.Common.Attributes
{
    /// <summary>
    /// Кастомный аттрибут валидации ОТ- ДО
    /// </summary>
    public class FromToAttribute : ValidationAttribute
    {
        public readonly string PropertyFrom;
        public readonly string PropertyTo;

        public readonly bool IsSinglePossible;

        /// <inheritdoc />
        /// <summary>
        /// Кастомный аттрибут валидации ОТ-ДО
        /// </summary>
        /// <param name="from">Наименование поля "От"</param>
        /// <param name="to">Наименование поля "До"</param>
        /// <param name="isSinglePossible"></param>
        public FromToAttribute(string from, string to, bool isSinglePossible = false)
        {
            PropertyFrom = from;
            PropertyTo = to;
            IsSinglePossible = isSinglePossible;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyFrom = validationContext.ObjectType.GetProperty(PropertyFrom);
            if (propertyFrom == null)
                return new ValidationResult(string.Format(CommonResources.Validation_UnknowPropery, PropertyFrom));

            // Тип поля из модели не поддерживает сравнения 
            var fromValue = propertyFrom.GetValue(validationContext.ObjectInstance, null);
            if (!(fromValue is IComparable))
                return new ValidationResult(string.Format(CommonResources.Validation_NotIComparable, PropertyFrom));

            var propertyTo = validationContext.ObjectType.GetProperty(PropertyTo);
            if (propertyTo == null)
                return new ValidationResult(string.Format(CommonResources.Validation_UnknowPropery, PropertyTo));

            // Тип поля из модели не поддерживает сравнения 
            var toValue = propertyTo.GetValue(validationContext.ObjectInstance, null);
            if (!(toValue is IComparable))
                return new ValidationResult(string.Format(CommonResources.Validation_NotIComparable, PropertyTo));

            // Приводим к типам поддерживающим сравнения int, datetime, float и прочее
            var tempFrom = fromValue as IComparable;
            var tempTo = toValue as IComparable;

            // Сама проверка
            if (IsSinglePossible ? tempFrom.CompareTo(tempTo) > 0 : tempFrom.CompareTo(tempTo) >= 0)
                return new ValidationResult(string.Format(CommonResources.Validation_FromToInvalid,
                    LocalizationExtensions.GetPropertyDisplayLabel(propertyFrom),
                    LocalizationExtensions.GetPropertyDisplayLabel(propertyTo)));

            return ValidationResult.Success;
        }
    }
}