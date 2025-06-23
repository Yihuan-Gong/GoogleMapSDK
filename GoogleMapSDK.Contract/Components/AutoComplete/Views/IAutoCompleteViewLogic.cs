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

        void InitializeComponent();

        // Send to presenter
        void InputSelectedIndex(int index);
        Task InputKeyUpAsync(string text);
        void InputKeyDown(Keys key);

        // Response from presenter
        void PresenterMatchedListFound(List<string> matched);
        void PresenterMatchedListNull();
        void PresenterSelectedIndexChanged(int index);
        void PresenterAutoCompleteExcuted(string text, T value);
    }
}
