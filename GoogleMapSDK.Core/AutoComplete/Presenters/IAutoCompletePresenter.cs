using GoogleMapSDK.Contract.AutoComplete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.AutoComplete.Presenters
{
    public interface IAutoCompletePresenter<T>
    {
        Dictionary<Keys, AutoCompleteAction> KeyAction { get; }
        Task<Dictionary<string, T>> Values { set; }
        void ChangeSelectedIndex(int index);
        Task KeyUpAsync(string text);
        void KeyDown(Keys key);
    }
}
