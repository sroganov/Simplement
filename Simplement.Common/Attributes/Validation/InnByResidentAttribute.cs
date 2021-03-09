using System;
using System.ComponentModel.DataAnnotations;

namespace SoftLegion.Common.Attributes
{
    /// <summary>
    /// Валидация ИНН согласно указанию Резидент РУЗ
    /// </summary>
    public class InnByResidentAttribute : ValidationAttribute
    {
        private const int ResidentInnLength = 9;
        private const int NotResidentInnLength = 20;

        public readonly string PropertyIsResident;
        public readonly string PropertyInn;

        /// <summary>
        /// Кастомный аттрибут валидации ИНН с указанием Резидент РУз
        /// </summary>
        /// <param name="isResident">Наименование поля "Резидент РУз" (для нерезидентов длинна поля 1-20 символов, для резидентов строго - 9 ть символов)</param>
        /// <param name="inn">Наименование поля "ИНН"</param>
        public InnByResidentAttribute(string isResident, string inn)
        {
            PropertyInn = inn;
            PropertyIsResident = isResident;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyInn = validationContext.ObjectType.GetProperty(PropertyInn);
            if (propertyInn == null)
                return new ValidationResult(string.Format(CommonResources.Validation_UnknowPropery, PropertyInn));

            var propertyIsResident = validationContext.ObjectType.GetProperty(PropertyIsResident);
            if (propertyIsResident == null)
                return new ValidationResult(string.Format(CommonResources.Validation_UnknowPropery, nameof(propertyIsResident)));

            //Тип поля из модели не является булевым
            var isResidentValue = propertyIsResident.GetValue(validationContext.ObjectInstance, null);
            if (!(isResidentValue is bool) && !(isResidentValue.GetType().GetGenericTypeDefinition() == typeof(Nullable<>)))
                return new ValidationResult(string.Format(CommonResources.Validation_InvalidPropertyNotBool, isResidentValue));

            var tempInn = propertyInn.GetValue(validationContext.ObjectInstance, null) == null ? "" : propertyInn.GetValue(validationContext.ObjectInstance, null).ToString();
            var tempIsResident = isResidentValue as bool?;

            if (!tempIsResident.HasValue)
                return new ValidationResult(string.Format(CommonResources.Validation_InvalidPropertyNotBool, isResidentValue));

            if (!tempIsResident.Value && (string.IsNullOrEmpty(tempInn) || tempInn.Length > NotResidentInnLength))
                return new ValidationResult(CommonResources.Validation_NotResidentInnInvalid);

            if (tempIsResident.Value && !string.IsNullOrEmpty(tempInn) && tempInn.Length != ResidentInnLength)
                return new ValidationResult(CommonResources.Validation_ResidentInnInvalid);

            return ValidationResult.Success;
        }
    }
}