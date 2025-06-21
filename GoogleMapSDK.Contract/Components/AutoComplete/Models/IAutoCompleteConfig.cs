using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.AutoComplete.Models
{
    public interface IAutoCompleteConfig<T>
    {
        /// <summary>
        /// 當auto complete選項被選中後，要做的事情。
        /// </summary>
        EventHandler<T> AutoCompleteSelected { get; }

        /// <summary>
        /// Auto complete選項的資料來源。
        /// </summary>
        Task<Dictionary<string, T>> GetValuesAsync(string inputText);
    }
}
