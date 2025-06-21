using GoogleMapSDK.Contract.AutoComplete.Models;
using GoogleMapSDK.Contract.AutoComplete.Views;
using GoogleMapSDK.Core.AutoComplete.Presenters;
using MVPExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Core.AutoComplete.ViewLogic
{
    public class AutoCompleteViewLogic<T> : IAutoCompleteViewLogic<T>
    {
        protected readonly IAutoCompletePresenter<T> presenter;
        protected readonly IAutoCompleteView<T> viewUI;

        public AutoCompleteViewLogic(IServiceProvider serviceProvider, IAutoCompleteView<T> viewUI)
        {
            presenter = serviceProvider.CreatePresenter<IAutoCompletePresenter<T>, AutoCompleteViewLogic<T>>(this);
            this.viewUI = viewUI;
        }

        public Task<Dictionary<string, T>> Values {  set => presenter.Values = value; }

        public void ChangeSelectedIndex(int index)
        {
            presenter.ChangeSelectedIndex(index);
        }

        public async Task KeyUpAsync(string text)
        {
            await presenter.KeyUpAsync(text);
        }

        public void KeyDown(Keys key)
        {
            presenter.KeyDown(key);
        }

        public void PresenterMatchedListFound(List<string> matched)
        {
            viewUI.ViewLogicMathcedListFound(matched);
        }

        public void PresenterSelectedIndexChanged(int index)
        {
            viewUI.ViewLogicSelectedIndexChanged(index);
        }

        public void PresenterHideAutoCompleteBox()
        {
            viewUI.ViewLogicHideAutoCompleteBox();
        }

        public void PresenterAutoCompleteExcuted(string text, T value)
        {
            viewUI.ViewLogicAutoCompleteExcuted(text, value);
        }
    }
}
