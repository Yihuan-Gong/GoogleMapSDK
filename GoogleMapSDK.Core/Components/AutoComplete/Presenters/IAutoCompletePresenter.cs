using GoogleMapSDK.Contract.Components.AutoComplete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.AutoComplete.Presenters
{
    public interface IAutoCompletePresenter<T>
    {
        Dictionary<Keys, AutoCompleteAction> KeyAction { get; }
        IAutoCompleteConfig<T> Config { set; }
        void ChangeSelectedIndex(int index);
        Task KeyUpAsync(string text);
        void KeyDown(Keys key);
    }
}
