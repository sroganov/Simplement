using System.Collections.Generic;

namespace Simplement.Common.Core
{
    public class OperationResultPage : OperationResult
    {
        public Pager Pager { get; set; } = new();
    }

    public class OperationResultPage<T> : OperationResultPage
    {
        public OperationResultPage()
        {
        }

        public OperationResultPage(OperationResultPage result, List<T> values)
        {
            ErrorMessageList = result.ErrorMessageList;
            Values = values;
            Result = result.Result;
            ErrorMessage = result.ErrorMessage;
            Pager = result.Pager;
        }

        public OperationResultPage(OperationResultList result, Pager pager, List<T> values)
        {
            ErrorMessageList = result.ErrorMessageList;
            Values = values;
            Result = result.Result;
            ErrorMessage = result.ErrorMessage;
            Pager = pager;
        }

        public List<T> Values { get; set; } = new();
        public T Model { get; set; }
        public new Pager Pager { get; set; } = new();

        public static OperationResultPage<T> Success(List<T> values, Pager pager, string message = "")
        {
            return new()
            {
                Pager = pager,
                Values = values,
                Result = OperationStatus.Success,
                ErrorMessage = message
            };
        }

        public static OperationResultPage<T> Success(T model, Pager pager, string message = "")
        {
            return new()
            {
                Pager = pager,
                Model = model,
                Result = OperationStatus.Success,
                ErrorMessage = message
            };
        }

        public new static OperationResultPage<T> Fail(string message = "", List<string> errorMessages = null)
        {
            return new()
            {
                Result = OperationStatus.Failed,
                ErrorMessage = message,
                ErrorMessageList = errorMessages
            };
        }
    }
}
