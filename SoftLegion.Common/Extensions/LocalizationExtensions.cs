using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace SoftLegion.Common.Extensions
{
    public static class LocalizationExtensions
    {
        /// <summary>
        /// Заберём наименование поля из ресурсников
        /// </summary>
        /// <param name="property">Параметр модели (с всей служебной информацией)</param>
        /// <returns>Наименование поля, если есть аттрибут Display или наименование параметра модели если аттрибута нет</returns>
        public static string GetPropertyDisplayLabel(PropertyInfo property)
        {
            if (property == null)
                return null;

            var returnValue = property.Name;
            var displayAttribute = property.GetCustomAttributes<DisplayAttribute>().FirstOrDefault();
            if (displayAttribute == null)
                return returnValue;

            var resourceType = displayAttribute.ResourceType;
            var resourceLabelName = displayAttribute.Name;

            var label = GetResourceString(resourceType, resourceLabelName);
            if (!string.IsNullOrWhiteSpace(label))
                returnValue = label;

            return returnValue;
        }

        /// <summary>
        /// Вернём значение из файла ресурсов
        /// </summary>
        /// <param name="resourceType">Тип файла ресурсов</param>
        /// <param name="resourceKey">Ключ ресурса</param>
        /// <returns>Если значение есть, и значение строка - вернём, если его нет - null</returns>
        public static string GetResourceString(Type resourceType, string resourceKey)
        {
            if (resourceType == null || string.IsNullOrEmpty(resourceKey))
                return string.Empty;

            var resourceManager = resourceType.GetProperties()
                .FirstOrDefault(p => p.PropertyType == typeof(ResourceManager));

            return ((ResourceManager)resourceManager?.GetValue(null, null))?.GetString(resourceKey);
        }

        /// <summary>
        /// Получим поле Description для значения Enum
        /// </summary>
        /// <typeparam name="T">Тип Enum</typeparam>
        /// <param name="enumValue">Ключъ Enum</param>
        /// <returns></returns>
        public static string GetEnumDescriptionResourceString<T>(T enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());
            var attribute = fieldInfo.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            var value = GetResourceString(attribute?.ResourceType, attribute?.Description);

            return value;
        }

        /// <summary>
        /// Получим поле Name для значения Enum
        /// </summary>
        /// <typeparam name="T">Тип Enum</typeparam>
        /// <param name="enumValue">Ключъ Enum</param>
        /// <returns></returns>
        public static string GetEnumNameResourceString<T>(T enumValue)
        {
            var field = enumValue.GetType().GetField(enumValue.ToString());
            var attribute = field?.GetCustomAttributes(typeof(DisplayAttribute), false).FirstOrDefault() as DisplayAttribute;
            var value = GetResourceString(attribute?.ResourceType, attribute?.Name);

            return value;
        }
    }
}