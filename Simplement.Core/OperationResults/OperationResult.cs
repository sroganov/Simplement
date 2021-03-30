using System.Collections.Generic;

namespace Simplement.Core
{
    public class OperationResult
    {
        public OperationStatus Result { get; set; } = OperationStatus.Failed;
        public string Message { get; set; } = string.Empty;
        public List<string> Errors { get; set; } = new();

        public static OperationResult Success(string message = null, List<string> errors = null)
        {
            return new()
            {
                Result = OperationStatus.Success,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>()
            };
        }

        public static OperationResult Fail(string message = null, List<string> errors = null)
        {
            return new()
            {
                Result = OperationStatus.Failed,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>()
            };
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Value { get; set; }

        public static OperationResult<T> Success(T value, string message = null, List<string> errors = null)
        {
            return new()
            {
                Value = value,
                Result = OperationStatus.Success,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>()
            };
        }

        public new static OperationResult<T> Fail(string message = null, List<string> errors = null)
        {
            return new()
            {
                Value = default,
                Result = OperationStatus.Failed,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>()
            };
        }
    }
}
