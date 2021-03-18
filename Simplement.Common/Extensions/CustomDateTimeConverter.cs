using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Globalization;
using static System.String;

namespace SoftLegion.Common.Extensions
{
    public class CustomDateTimeConverter : DateTimeConverterBase
    {
        public static string[] DefaultInputFormats =
        {
            "yyyyMMdd", "yyyy/MM/dd", "dd/MM/yyyy","dd/MM/yyyy HH:mm:ss","dd/MM/yyyy HH:mm:ss tt","d/M/yyyy hh:mm:ss tt","dd/MM/yyyy hh:mm:ss tt", "d/MM/yyyy hh:mm:ss tt","M/dd/yyyy hh:mm:ss tt", "dd-MM-yyyy", "yyyy-MM-dd",
            "yyyyMMddHHmmss", "yyyy/MM/dd HH:mm:ss", "dd/MM/yyyy HH:mm:ss", "dd-MM-yyyy HH:mm:ss", "dd-MM-yyyy H:mm:ss", "dd-MM-yyyy hh:mm:ss","dd-MM-yyyy h:mm:ss", "dd.MM.yyyy","d/M/yyyy hh:mm:ss tt","M/d/yyyy hh:mm:ss tt","d/M/yyyy h:m:s tt",
            "yyyy-MM-dd HH:mm:ss","MM/dd/yyyy HH:mm:ss tt", "yyyy-MM-dd'T'HH:mm:ssZ", "yyyy-MM-dd HH:mm:ss tt","yyyy-MM-ddTHH:mm:ss.fffZ","dd/MM/yyyy HH:mm:ss tt","dd.MM.yyyy",
            "dd.MM.yyyy h:mm:ss","MM.dd.yyyy h:mm:ss","dd.MM.yyyy h:m:s","MM.dd.yyyy h:m:s"
        };

        public static string DefaultOutputFormat = "yyyyMMdd";
        public static bool DefaultEvaluateEmptyStringAsNull = true;

        private readonly string[] _inputFormats = DefaultInputFormats;
        private readonly string _outputFormat = DefaultOutputFormat;
        private readonly bool _evaluateEmptyStringAsNull = DefaultEvaluateEmptyStringAsNull;

        public CustomDateTimeConverter() { }
        public CustomDateTimeConverter(string[] inputFormats, string outputFormat, bool evaluateEmptyStringAsNull = true)
        {
            if (inputFormats != null) _inputFormats = inputFormats;
            if (outputFormat != null) _outputFormat = outputFormat;
            _evaluateEmptyStringAsNull = evaluateEmptyStringAsNull;
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var dateTimeVal = reader.Value;

            if (dateTimeVal is DateTime)
                return dateTimeVal;

            string v = reader.Value?.ToString();
            try
            {
                // The following line grants Nullable DateTime support. We will return (DateTime?)null if the Json property is null.
                if (IsNullOrEmpty(v) && Nullable.GetUnderlyingType(objectType) != null)
                {
                    // If EvaluateEmptyStringAsNull is true an empty string will be treated as null, 
                    // otherwise we'll let DateTime.ParseExactwill throw an exception in a couple lines.
                    if (v == null || _evaluateEmptyStringAsNull) return null;
                }
                //Insert default value if come string emty and
                if (IsNullOrEmpty(v) && Nullable.GetUnderlyingType(objectType) == null)
                {
                    // If EvaluateEmptyStringAsNull is true an empty string will be treated as null, 
                    // otherwise we'll let DateTime.ParseExactwill throw an exception in a couple lines.
                    if (v == null || _evaluateEmptyStringAsNull) return DateTime.MinValue;
                }
                v = v.Replace("\"", "").Replace("\'", "");
                return DateTime.ParseExact(v, _inputFormats, CultureInfo.InvariantCulture, DateTimeStyles.None);
            }
            catch (Exception)
            {
                throw new NotSupportedException($"Ошибка: Введёное значение '{v}' не может быть преобразовано в дату в одном из указаных форматов: {Join(",", _inputFormats)}");
            }
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((DateTime)value).ToString(_outputFormat));
        }
    }
}