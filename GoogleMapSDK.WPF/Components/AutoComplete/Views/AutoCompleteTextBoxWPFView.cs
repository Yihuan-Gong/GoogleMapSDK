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
            _viewLogic.InitializeComponent();
        }

        public void LoadView(IAutoCompleteConfig<T> config)
        {
            _viewLogic.Config = config;
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

        public void InitializeListBoxWithMouseClickEvent()
        {
            _listBox = new ListBox();
            _listBox.MouseLeftButtonUp += ListBoxMouseLeftButtonClicked;
        }

        public void InitializePositionOfTextBoxAndListBox()
        {
            _popup = new Popup
            {
                PlacementTarget = this,
                Placement = PlacementMode.Bottom,
                StaysOpen = false,
                AllowsTransparency = true,
                Child = _listBox
            };
        }

        public void InitializeKeyDownEventAtTextBox()
        {
            // 因為KeyDown是冒泡事件，事件傳遞由內而外，在TextBox改變完Text就會被擋住
            // 所以這邊必須使用隧道事件PreviewKeyDown。事件傳遞由外而內，就不會被擋住。
            PreviewKeyDown += ThisKeyDown;
        }

        public void InitializeKeyUpEventAtTextBox()
        {
            KeyUp += ThisKeyUp;
        }

        private void ListBoxMouseLeftButtonClicked(object sender, MouseButtonEventArgs e)
        {
            _viewLogic.InputSelectedIndex(_listBox.SelectedIndex);
            _viewLogic.InputKeyDown(Keys.Enter);
        }

        private void ThisKeyDown(object sender, KeyEventArgs e)
        {
            _viewLogic.InputKeyDown(new Mapper<Key, Keys>().Map(e.Key));
        }

        private void ThisKeyUp(object sender, KeyEventArgs e)
        {
            this.DebounceHandler(async () =>
            {
                await _viewLogic.InputKeyUpAsync(Text);
            }, debounceTime: 500);
        }
    }
}
