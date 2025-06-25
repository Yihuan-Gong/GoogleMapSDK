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

            // 如果是需要很多次元件，這邊也是將所有從容器拿到的ISubComponentView放到InitializeComponent(()
            // 交給個平台去自由安排這些次元件如何放上UI
            this.viewUI.InitializeComponent(SelectSuggestionByMouse, SelectSuggestionByKey, SearchSuggestionAsync);

            // 後面還可以將ISubViewA的輸出事件去綁定ISubViewB的LoadData()，來管理次元件間的互相合作
        }

        public IAutoCompleteConfig<T> Config { set => presenter.Config = value; }

        private void SelectSuggestionByMouse(int index)
        {
            presenter.SelectSuggestion(index);
        }

        private void SelectSuggestionByKey(Keys key)
        {
            presenter.SelectSuggestion(key);
        }

        // 這邊可以了解一下為何async void會work
        private async void SearchSuggestionAsync(string text)
        {
            await presenter.SearchSuggestionAsync(text);
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
