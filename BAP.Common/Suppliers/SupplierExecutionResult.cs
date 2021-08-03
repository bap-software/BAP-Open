using System.Collections.Generic;
using System.Linq;

namespace BAP.Common.Suppliers
{
    public class SupplierExecutionResult
    {
        private readonly List<BapDynamicVariable> _resultData = new List<BapDynamicVariable>();
        public bool IsSuccess => !ErrorsList.Any(); 

        public List<SupplierExecutionLog> Log { get; private set; } = new List<SupplierExecutionLog>();

        public IEnumerable<string> ErrorsList => Log.Where(x => x.IsError).Select(x => x.Message);
        public IEnumerable<string> InformationList => Log.Where(x => !x.IsError).Select(x => x.Message);
        public IEnumerable<BapDynamicVariable> ResultData => _resultData;

        /// <summary>
        /// Provides all log information as string
        /// </summary>
        public string FullMessage => string.Join("\n", Log.Select(x => x.Message));
        
        /// <summary>
        /// Provides all information messages as string
        /// </summary>
        public string InformationMessage => string.Join("\n", InformationList);
        
        /// <summary>
        /// Provides all error messages as string
        /// </summary>
        public string ErrorMessage => string.Join("\n", ErrorsList);

        public void AddInfo(string message)
        {
            AddLog(message, isError: false);
        }
        
        public void AddError(string message)
        {
            AddLog(message, isError: true);
        }

        private void AddLog(string message, bool isError)
        {
            Log.Add(new SupplierExecutionLog
            {
                Message = message,
                IsError = isError
            });
        }

        public void AddResultData<TData>(TData data)
        {
            _resultData.Add(new BapDynamicVariable(typeof(TData).FullName, data));
        }
        public void AddResultData(params BapDynamicVariable[] data)
        {
            _resultData.AddRange(data);
        }

        public TData FindResultData<TData>()
        {
            return _resultData.FirstOrDefault(x => x.Key == typeof(TData).FullName)?.Value;
        }

        public void MergeWith(SupplierExecutionResult result)
        {
            foreach (var logItem in result.Log)
            {
                AddLog(logItem.Message, logItem.IsError);
            }

            if (result.ResultData.Any())
            {
                AddResultData(result.ResultData);
            }
        }
    }

    public class SupplierExecutionLog
    {
        public string Message { get; set; }
        public bool IsError { get; set; }
    }
}