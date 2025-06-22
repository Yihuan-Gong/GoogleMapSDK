using GoogleMapSDK.Contract.Components.AutoComplete.Views;
using GoogleMapSDK.Contract.Components.AutoComplete.Models;
using MVPExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using GoogleMapSDK.Winform.Extensions;

namespace GoogleMapSDK.Winform.Components.AutoComplete.Views
{
    public class AutoCompleteTextBoxView<T> : TextBox, IAutoCompleteView<T>
    {
        protected readonly IAutoCompleteViewLogic<T> viewLogic;
        protected IAutoCompleteConfig<T> config;
        private ListBox _listBox;
        private bool _isAdded;

        public AutoCompleteTextBoxView(IServiceProvider serviceProvider)
        {
            viewLogic = serviceProvider.CreatePresenter<IAutoCompleteViewLogic<T>, IAutoCompleteView<T>>(this);
            InitializeComponent();
        }

        public void LoadView(IAutoCompleteConfig<T> config)
        {
            this.config = config;
            viewLogic.Config = config;
        }

        public void ViewLogicMathcedListFound(List<string> matched)
        {
            if (!_isAdded)
            {
                Parent.Controls.Add(_listBox);
                _isAdded = true;
            }
            _listBox.Visible = true;
            _listBox.BringToFront();
            _listBox.Items.Clear();
            _listBox.Items.AddRange(matched.ToArray());

            int itemCount = _listBox.Items.Count + 1;
            int itemHeight = _listBox.ItemHeight;
            int borderHeight = SystemInformation.BorderSize.Height * 2;

            _listBox.Height = itemCount * itemHeight + borderHeight;
            _listBox.Width = this.Width;
        }

        public void ViewLogicHideAutoCompleteBox()
        {
            _listBox.Visible = false;
        }

        public void ViewLogicSelectedIndexChanged(int index)
        {
            _listBox.SelectedIndex = index;
        }

        public void ViewLogicAutoCompleteExcuted(string text, T value)
        {
            Text = text;
            SelectionStart = text.Length;
        }

        protected override bool IsInputKey(System.Windows.Forms.Keys keyData)
        {
            switch (keyData)
            {
                case System.Windows.Forms.Keys.Tab:
                    return true;
                default:
                    return base.IsInputKey(keyData);
            }
        }

        private void InitializeComponent()
        {
            _listBox = new ListBox
            {
                Left = Left,
                Top = Top + Height
            };
            _listBox.MouseClick += ListBoxMouseClick;
            KeyDown += ThisKeyDown;
            KeyUp += ThisKeyUp;
        }

        private void ListBoxMouseClick(object sender, MouseEventArgs e)
        {
            viewLogic.ChangeSelectedIndex(_listBox.SelectedIndex);
            viewLogic.KeyDown(Contract.Components.AutoComplete.Models.Keys.Enter);
        }

        private void ThisKeyUp(object sender, KeyEventArgs e)
        {
            this.DebounceHandler(async () =>
            {
                await viewLogic.KeyUpAsync(Text);
            }, debounceTime: 500);
        }

        private void ThisKeyDown(object sender, KeyEventArgs e)
        {
            viewLogic.KeyDown(
                new Mapper<System.Windows.Forms.Keys, Contract.Components.AutoComplete.Models.Keys>()
                .Map(e.KeyCode));
        }
    }
}
