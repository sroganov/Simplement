using System;

namespace Simplement.Utils
{
    public static class ReflectionUtils
    {
        /// <summary>
        /// Returns value by given property path (ex.: SomeObject.SomeProperty.OtherProperty) if any, otherwise returns null.
        /// </summary>
        public static object GetValue(object obj, string propertyPath)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (string.IsNullOrEmpty(propertyPath))
                throw new ArgumentNullException(nameof(propertyPath));

            var properties = propertyPath.Split('.');
            var child = obj;

            foreach (var property in properties)
            {
                child = child.GetType().GetProperty(property)?.GetValue(child, null);
                if (child == null)
                    return null;
            }

            return child;
        }
    }
}
