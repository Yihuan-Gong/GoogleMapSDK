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
        protected IAutoCompleteConfig<T> _config;
        private Popup _popup;
        private ListBox _listBox;
        private bool _isAdded;

        public AutoCompleteTextBoxWPFView(IServiceProvider serviceProvider)
        {
            _viewLogic = serviceProvider.CreatePresenter<IAutoCompleteViewLogic<T>, IAutoCompleteView<T>>(this);
            // _viewLogic.InitializeComponent();

            InitializeComponent();
        }

        public void LoadView(IAutoCompleteConfig<T> config)
        {
            _config = config;
            _viewLogic.Config = _config;
        }

        public void ViewLogicAutoCompleteExcuted(string text, T value)
        {
            Text = text;
            SelectionStart = text.Length;
        }

        public void ViewLogicHideAutoCompleteBox()
        {
            _popup.IsOpen = false;
        }

        public void ViewLogicMathcedListFound(List<string> matched)
        {
            _listBox.ItemsSource = matched;
            _listBox.Width = Width;

            double itemHeight = 20;
            _listBox.Height = (matched.Count + 1) * itemHeight;

            _popup.IsOpen = true;
        }

        public void ViewLogicSelectedIndexChanged(int index)
        {
            if (_listBox != null)
                _listBox.SelectedIndex = index;
        }

        private void InitializeComponent()
        {
            _listBox = new ListBox();
            _listBox.MouseLeftButtonUp += ListBoxMouseLeftButtonClicked;

            _popup = new Popup
            {
                PlacementTarget = this,
                Placement = PlacementMode.Bottom,
                StaysOpen = false,
                AllowsTransparency = true,
                Child = _listBox
            };

            // 這邊要找時間搞懂KeyUp和PreviewKeyUp
            PreviewKeyDown += ThisKeyDown;
            KeyUp += ThisKeyUp;
        }

        private void ListBoxMouseLeftButtonClicked(object sender, MouseButtonEventArgs e)
        {
            _viewLogic.ChangeSelectedIndex(_listBox.SelectedIndex);
            _viewLogic.KeyDown(Keys.Enter);
        }

        private void ThisKeyDown(object sender, KeyEventArgs e)
        {
            _viewLogic.KeyDown(new Mapper<Key, Keys>().Map(e.Key));
        }

        private void ThisKeyUp(object sender, KeyEventArgs e)
        {
            this.DebounceHandler(async () =>
            {
                await _viewLogic.KeyUpAsync(Text);
            }, debounceTime: 500);
        }
    }
}
