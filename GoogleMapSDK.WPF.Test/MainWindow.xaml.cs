using GoogleMapSDK.Contract.Components.AutoComplete.Views;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.Core.Components.AutoComplete.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GoogleMapSDK.WPF.Test
{
    /// <summary>
    /// MainWindow.xaml 的互動邏輯
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(IAutoCompleteView<PlaceSimpleModel> autoCompleteView, GoogleMapAutoCompleteConfig autoCompleteConfig)
        {
            InitializeComponent();

            autoCompleteView.LoadView(autoCompleteConfig);
            var autoCompleteTextBox = autoCompleteView as TextBox;
            autoCompleteTextBox.Width = 500;
            autoCompleteTextBox.Height = 20;

            MainGrid.Children.Add(autoCompleteTextBox);
        }
    }
}
