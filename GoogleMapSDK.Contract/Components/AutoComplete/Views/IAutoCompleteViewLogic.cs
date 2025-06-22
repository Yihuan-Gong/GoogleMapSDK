using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoogleMapSDK.Contract.Components.AutoComplete.Models;

namespace GoogleMapSDK.Contract.Components.AutoComplete.Views
{
    public interface IAutoCompleteViewLogic<T>
    {
        IAutoCompleteConfig<T> Config { set; }
        void ChangeSelectedIndex(int index);
        Task KeyUpAsync(string text);
        void KeyDown(Keys key);
        void PresenterMatchedListFound(List<string> matched);
        void PresenterSelectedIndexChanged(int index);
        void PresenterHideAutoCompleteBox();
        void PresenterAutoCompleteExcuted(string text, T value);
    }
}
