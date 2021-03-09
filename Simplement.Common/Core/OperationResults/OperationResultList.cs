using System.Collections.Generic;
using SoftLegion.Common.Core.Enums;

namespace SoftLegion.Common.Core.OperationResults
{
    public class OperationResultList : OperationResult
    {

    }

    public class OperationResultList<T> : OperationResultList
    {
        public List<T> Values { get; set; } = new List<T>();

        public OperationResultList()
        {
        }

        public OperationResultList(OperationResultList result, List<T> values)
        {
            ErrorMessageList = result.ErrorMessageList;
            Values = values;
            Result = result.Result;
            ErrorMessage = result.ErrorMessage;
        }

        public OperationResultList(OperationResultPage result, List<T> values)
        {
            ErrorMessageList = result.ErrorMessageList;
            Values = values;
            Result = result.Result;
            ErrorMessage = result.ErrorMessage;
        }

        public static OperationResultList<T> Success(List<T> values, string message = "")
        {
            return new OperationResultList<T>
            {
                Values = values,
                Result = OperationStatus.Success,
                ErrorMessage = message
            };
        }

        public new static OperationResultList<T> Fail(string message = null, List<string> messageList = null)
        {
            return new OperationResultList<T>()
            {
                ErrorMessage = !string.IsNullOrEmpty(message) ? message : string.Empty,
                ErrorMessageList = messageList != null && messageList.Count > 0 ? messageList : new List<string>(),
                Result = OperationStatus.Failed
            };
        }
    }
}