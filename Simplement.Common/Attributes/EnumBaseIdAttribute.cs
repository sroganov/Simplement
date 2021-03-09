using System;
using System.Diagnostics;

namespace SoftLegion.Common.Attributes
{
    /// <summary>
    /// Здесь у нас кастомный аттрибут для Enum для хранения в них Id из базы
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumBaseIdAttribute : Attribute
    {
        /// <summary>
        /// Храним переменную Id в аттрибуте
        /// </summary>
        public Guid EnumId { get; set; }

        /// <summary>
        /// Парсим значение аттрибута в Guid
        /// </summary>
        /// <param name="guid">Значение аттрибута из самого Enum</param>
        public EnumBaseIdAttribute(string guid)
        {
            try
            {
                if (!Guid.TryParse(guid, out var enumId))
                    throw new Exception("Incorrect GUID format in Enum - " + guid);

                EnumId = enumId;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);

                if (Debugger.IsAttached)
                    Debug.WriteLine(e);

                throw;
            }
        }

    }


}