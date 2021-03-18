using System.Collections.Generic;
using SoftLegion.Common.Core.Enums;
using SoftLegion.Common.Core.Paging;

namespace SoftLegion.Common.Core.OperationResults
{
    public class OperationResultPage : OperationResult
    {
        public Pager Pager { get; set; } = new Pager();

    }

    public class OperationResultPage<T> : OperationResultPage
    {
        public List<T> Values { get; set; } = new List<T>();
        public T Model { get; set; }
        public new Pager Pager { get; set; } = new Pager();

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

        public static OperationResultPage<T> Success(List<T> values, Pager pager, string message = "")
        {
            return new OperationResultPage<T>
            {
                Pager = pager,
                Values = values,
                Result = OperationStatus.Success,
                ErrorMessage = message
            };
        }

        public static OperationResultPage<T> Success(T model, Pager pager, string message = "")
        {
            return new OperationResultPage<T>
            {
                Pager = pager,
                Model = model,
                Result = OperationStatus.Success,
                ErrorMessage = message
            };
        }

        //public new static OperationResultPage<T> Fail(string message = "")
        //{
        //    return new OperationResultPage<T>
        //    {
        //        Result = OperationStatus.Failed,
        //        ErrorMessage = message
        //    };
        //}

        public new static OperationResultPage<T> Fail(string message = "", List<string> errorMessages = null)
        {
            return new OperationResultPage<T>
            {
                Result = OperationStatus.Failed,
                ErrorMessage = message,
                ErrorMessageList = errorMessages
            };
        }
    }
}