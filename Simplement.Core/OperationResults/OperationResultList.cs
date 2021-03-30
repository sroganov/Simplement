using System.Collections.Generic;

namespace Simplement.Core
{
    public class OperationResultList<T> : OperationResult
    {
        public List<T> Values { get; set; } = new();

        public static OperationResultList<T> Success(List<T> values, string message = "", List<string> errors = null)
        {
            return new()
            {
                Values = values,
                Result = OperationStatus.Success,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>()
            };
        }

        public new static OperationResultList<T> Fail(string message = null, List<string> errors = null)
        {
            return new()
            {
                Result = OperationStatus.Failed,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>()
            };
        }
    }
}
