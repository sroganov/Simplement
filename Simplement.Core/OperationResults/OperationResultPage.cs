using System.Collections.Generic;

namespace Simplement.Core
{
    public class OperationResultPage<T> : OperationResult
    {
        public Pager Pager { get; set; } = new();
        public List<T> Values { get; set; } = new();

        public static OperationResultPage<T> Success(List<T> values, Pager pager, string message = "", List<string> errors = null)
        {
            return new OperationResultPage<T>
            {
                Values = values,
                Result = OperationStatus.Success,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>(),
                Pager = pager
            };
        }

        public new static OperationResultPage<T> Fail(string message = null, List<string> errors = null)
        {
            return new OperationResultPage<T>
            {
                Result = OperationStatus.Failed,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>()
            };
        }

        public new static OperationResultPage<T> Fail(OperationStatus status, string message = null, List<string> errors = null)
        {
            return new OperationResultPage<T>
            {
                Result = status,
                Message = !string.IsNullOrEmpty(message) ? message : string.Empty,
                Errors = errors ?? new List<string>()
            };
        }
    }
}
