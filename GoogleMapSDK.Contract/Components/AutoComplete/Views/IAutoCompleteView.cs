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
        
        // Response from view logic
        void ShowNewMatchAtListBox(List<string> matched);
        void ChangeSelectedIndexAtListBox(int index);
        void ChangeTextAtTextBox(string text, T value);
        void HideListBox();

        // Initializations
        void InitializeListBoxWithMouseClickEvent();
        void InitializePositionOfTextBoxAndListBox();
        void InitializeKeyDownEventAtTextBox();
        void InitializeKeyUpEventAtTextBox();
    }
}
