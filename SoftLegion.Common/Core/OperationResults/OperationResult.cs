using SoftLegion.Common.Core.Enums;
using System.Collections.Generic;

namespace SoftLegion.Common.Core.OperationResults
{
    public class OperationResult
    {
        public OperationStatus Result { get; set; } = OperationStatus.Failed;
        public string ErrorMessage { get; set; } = string.Empty;
        public List<string> ErrorMessageList { get; set; } = new List<string>();
        public List<string> ConfirmationMessages { get; set; } = new List<string>();

        public static OperationResult Success(string message = "")
        {
            return new OperationResult
            {
                Result = OperationStatus.Success,
                ErrorMessage = message
            };
        }

        public static OperationResult Success(List<string> messagesList)
        {
            if (messagesList == null)
                messagesList = new List<string>();

            return new OperationResult
            {
                Result = OperationStatus.Success,
                ErrorMessageList = messagesList
            };
        }

        public static OperationResult Fail(List<string> messagesList)
        {
            return Fail(null, messagesList);
        }

        public static OperationResult Fail(string message = null, List<string> messagesList = null)
        {
            if (messagesList == null)
                messagesList = new List<string>();

            return new OperationResult
            {
                Result = OperationStatus.Failed,
                ErrorMessage = !string.IsNullOrEmpty(message) ? message : string.Empty,
                ErrorMessageList = messagesList
            };
        }
    }

    public class OperationResult<T> : OperationResult
    {
        public T Value { get; set; }

        public OperationResult()
        {
        }

        public OperationResult(OperationResult result, T value = default(T))
        {
            ErrorMessageList = result.ErrorMessageList;
            Value = value;
            Result = result.Result;
            ErrorMessage = result.ErrorMessage;
        }

        public static OperationResult<T> Success(T value, string message = "")
        {
            return new OperationResult<T>
            {
                Value = value,
                Result = OperationStatus.Success,
                ErrorMessage = message
            };
        }

        public static OperationResult<T> Success(T value, List<string> messagesList)
        {
            if (messagesList == null)
                messagesList = new List<string>();

            return new OperationResult<T>
            {
                Value = value,
                Result = OperationStatus.Success,
                ErrorMessageList = messagesList
            };
        }

        public static OperationResult<T> Fail()
        {
            return Fail(CommonResources.Error_WhileProcessingRequest);
        }

        public static OperationResult<T> Fail(string message = null)
        {
            return Fail(message, new List<string>());
        }

        public new static OperationResult<T> Fail(List<string> messagesList)
        {
            if (messagesList == null)
                messagesList = new List<string>();
            return Fail(CommonResources.Error_WhileProcessingRequest, messagesList);
        }

        public new static OperationResult<T> Fail(string message = null, List<string> messagesList = null)
        {
            if (messagesList == null)
                messagesList = new List<string>();

            return new OperationResult<T>
            {
                Result = OperationStatus.Failed,
                ErrorMessage = !string.IsNullOrEmpty(message) ? message : string.Empty,
                ErrorMessageList = messagesList
            };
        }

        public static OperationResult<T> Fail(T value)
        {
            return Fail(value, CommonResources.Error_WhileProcessingRequest, new List<string>());
        }

        public static OperationResult<T> Fail(T value, string message = null)
        {
            return Fail(value, message, new List<string>());
        }

        public static OperationResult<T> Fail(T value, List<string> messagesList)
        {
            if (messagesList == null)
                messagesList = new List<string>();

            return Fail(value, null, messagesList);
        }

        public static OperationResult<T> Fail(T value, string message = null, List<string> messagesList = null)
        {
            if (messagesList == null)
                messagesList = new List<string>();

            return new OperationResult<T>
            {
                Result = OperationStatus.Failed,
                ErrorMessage = !string.IsNullOrEmpty(message) ? message : string.Empty,
                ErrorMessageList = messagesList,
                Value = value
            };
        }

        public static OperationResult<T> InvalidModel(T item, string message = "")
        {
            return InvalidModel(item, new List<string> { message });
        }

        public static OperationResult<T> InvalidModel(T item, List<string> messageList)
        {
            return new OperationResult<T>
            {
                Result = OperationStatus.InvalidModel,
                Value = item,
                ErrorMessageList = messageList
            };
        }
    }
}
