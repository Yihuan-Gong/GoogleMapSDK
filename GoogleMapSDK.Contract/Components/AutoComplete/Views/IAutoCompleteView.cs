using GoogleMapSDK.Contract.Components.AutoComplete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Contract.Components.AutoComplete.Views
{
    public interface IAutoCompleteView<T>
    {
        void LoadView(IAutoCompleteConfig<T> config);
        void ViewLogicMathcedListFound(List<string> matched);
        void ViewLogicSelectedIndexChanged(int index);
        void ViewLogicAutoCompleteExcuted(string text, T value);
        void ViewLogicHideAutoCompleteBox();
    }
}
