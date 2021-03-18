using System;
using System.Diagnostics;

namespace SoftLegion.Common.Attributes
{
    /// <summary>
    /// Кастомный аттрибут для Enum для хранения в них ParentId из базы
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumParentIdAttribute : Attribute
    {
        /// <summary>
        /// Храним переменную ParentId в аттрибуте
        /// </summary>
        public Guid EnumId { get; set; }

        /// <summary>
        /// Парсим значение аттрибута в Guid
        /// </summary>
        /// <param name="guid">Значение аттрибута из самого Enum</param>
        public EnumParentIdAttribute(string guid)
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
