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
            viewLogic.InitializeComponent();
        }

        public void LoadView(IAutoCompleteConfig<T> config)
        {
            viewLogic.Config = config;
        }

        public void ShowNewMatchAtListBox(List<string> matched)
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

        public void HideListBox()
        {
            _listBox.Visible = false;
        }

        public void ChangeSelectedIndexAtListBox(int index)
        {
            _listBox.SelectedIndex = index;
        }

        public void ChangeTextAtTextBox(string text, T value)
        {
            Text = text;
            SelectionStart = text.Length;
        }

        public void InitializeListBoxWithMouseClickEvent()
        {
            _listBox = new ListBox
            {
                Left = Left,
                Top = Top + Height
            };
            _listBox.MouseClick += ListBoxMouseClick;
        }

        public void InitializePositionOfTextBoxAndListBox()
        {
            //Parent.Controls.Add(_listBox);
            //HideListBox();
        }

        public void InitializeKeyDownEventAtTextBox()
        {
            KeyDown += ThisKeyDown;
        }

        public void InitializeKeyUpEventAtTextBox()
        {
            KeyUp += ThisKeyUp;
        }

        private void ListBoxMouseClick(object sender, MouseEventArgs e)
        {
            viewLogic.InputSelectedIndex(_listBox.SelectedIndex);
            viewLogic.InputKeyDown(Contract.Components.AutoComplete.Models.Keys.Enter);
        }

        private void ThisKeyUp(object sender, KeyEventArgs e)
        {
            this.DebounceHandler(async () =>
            {
                await viewLogic.InputKeyUpAsync(Text);
            }, debounceTime: 500);
        }

        private void ThisKeyDown(object sender, KeyEventArgs e)
        {
            viewLogic.InputKeyDown(
                new Mapper<System.Windows.Forms.Keys, Contract.Components.AutoComplete.Models.Keys>()
                .Map(e.KeyCode));
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
    }
}
