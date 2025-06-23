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
        void ChangeSelectedIndex(int index);
        Task KeyUpAsync(string text);
        void KeyDown(Keys key);

        // Response from presenter
        void PresenterMatchedListFound(List<string> matched);
        void PresenterMatchedListNull();
        void PresenterSelectedIndexChanged(int index);
        void PresenterAutoCompleteExcuted(string text, T value);
    }
}
