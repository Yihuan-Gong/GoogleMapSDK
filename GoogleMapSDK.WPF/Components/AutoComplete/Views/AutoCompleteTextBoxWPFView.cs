using GoogleMapSDK.Contract.Components.AutoComplete.Models;
using GoogleMapSDK.Contract.Components.AutoComplete.Views;
using MVPExtension;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows;
using DTO;
using GoogleMapSDK.WPF.Extensions;
using System.Windows.Controls.Primitives;

namespace GoogleMapSDK.WPF.Components.AutoComplete.Views
{
    public class AutoCompleteTextBoxWPFView<T> : TextBox, IAutoCompleteView<T>
    {
        protected readonly IAutoCompleteViewLogic<T> _viewLogic;
        private Popup _popup;
        private ListBox _listBox;

        public AutoCompleteTextBoxWPFView(IServiceProvider serviceProvider)
        {
            _viewLogic = serviceProvider.CreatePresenter<IAutoCompleteViewLogic<T>, IAutoCompleteView<T>>(this);
        }

        public void LoadView(IAutoCompleteConfig<T> config)
        {
            _viewLogic.Config = config;
        }

        public void InitializeComponent(
            Action<int> selectSuggestionByMouse, 
            Action<Keys> selectSuggestionByKey, 
            Action<string> searchSuggestion)
        {
            _listBox = new ListBox();
            _popup = new Popup
            {
                PlacementTarget = this,
                Placement = PlacementMode.Bottom,
                StaysOpen = false,
                AllowsTransparency = true,
                Child = _listBox
            };

            InitializeSelectSuggestionByMouseEvent(selectSuggestionByMouse);
            InitializeSelectSuggestionByKeyEvent(selectSuggestionByKey);
            InitializeSearchSuggestionEvent(searchSuggestion);
        }

        public void ChangeTextAtTextBox(string text, T value)
        {
            Text = text;
            SelectionStart = text.Length;
        }

        public void HideListBox()
        {
            _popup.IsOpen = false;
        }

        public void ShowNewMatchAtListBox(List<string> matched)
        {
            _listBox.ItemsSource = matched;
            _listBox.Width = Width;

            double itemHeight = 20;
            _listBox.Height = (matched.Count + 1) * itemHeight;

            _popup.IsOpen = true;
        }

        public void ChangeSelectedIndexAtListBox(int index)
        {
            if (_listBox != null)
                _listBox.SelectedIndex = index;
        }

        private void InitializeSelectSuggestionByMouseEvent(Action<int> selectSuggestion)
        {
            _listBox.MouseLeftButtonUp += (sender, e) =>
            {
                selectSuggestion.Invoke(_listBox.SelectedIndex);
            };
        }

        private void InitializeSelectSuggestionByKeyEvent(Action<Keys> selectSuggestion)
        {
            PreviewKeyDown += (sender, e) =>
            {
                selectSuggestion.Invoke(new Mapper<Key, Keys>().Map(e.Key));
            };
        }

        private void InitializeSearchSuggestionEvent(Action<string> searchSuggestion)
        {
            KeyUp += (sender, e) =>
            {
                this.DebounceHandler(() => searchSuggestion.Invoke(Text), debounceTime: 500);
            };
        }
    }
}
