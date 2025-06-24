using GoogleMapSDK.Contract.Components.AutoComplete.Models;
using GoogleMapSDK.Contract.Components.AutoComplete.Views;
using GoogleMapSDK.Core.Components.AutoComplete.Presenters;
using MVPExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.Components.AutoComplete.ViewLogic
{
    public class AutoCompleteViewLogic<T> : IAutoCompleteViewLogic<T>
    {
        protected readonly IAutoCompletePresenter<T> presenter;
        protected readonly IAutoCompleteView<T> viewUI;

        public AutoCompleteViewLogic(IServiceProvider serviceProvider, IAutoCompleteView<T> viewUI)
        {
            presenter = serviceProvider.CreatePresenter<IAutoCompletePresenter<T>, IAutoCompleteViewLogic<T>>(this);
            this.viewUI = viewUI;
        }

        public IAutoCompleteConfig<T> Config { set => presenter.Config = value; }

        public void InitializeComponent()
        {
            viewUI.InitializeListBoxWithMouseClickEvent();
            viewUI.InitializePositionOfTextBoxAndListBox();
            viewUI.InitializeKeyDownEventAtTextBox();
            viewUI.InitializeKeyUpEventAtTextBox();
        }

        public void InputSelectedIndex(int index)
        {
            presenter.ChangeSelectedIndex(index);
        }

        public async Task InputKeyUpAsync(string text)
        {
            await presenter.KeyUpAsync(text);
        }

        public void InputKeyDown(Keys key)
        {
            presenter.KeyDown(key);
        }

        public void PresenterMatchedListFound(List<string> matched)
        {
            viewUI.ShowNewMatchAtListBox(matched);
        }

        public void PresenterMatchedListNull()
        {
            viewUI.HideListBox();
        }

        public void PresenterSelectedIndexChanged(int index)
        {
            viewUI.ChangeSelectedIndexAtListBox(index);
        }

        

        public void PresenterAutoCompleteExcuted(string text, T value)
        {
            viewUI.HideListBox();
            viewUI.ChangeTextAtTextBox(text, value);
        }
    }
}
