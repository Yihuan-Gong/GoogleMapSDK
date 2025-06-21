using GoogleMapSDK.Contract.AutoComplete.Views;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.Core.AutoComplete.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoogleMapSDK.Winform.Test
{
    internal partial class Form1 : Form
    {
        public Form1(IAutoCompleteView<PlaceSimpleModel> autoCompleteView, GoogleMapAutoCompleteConfig autoCompleteConfig)
        {
            InitializeComponent();

            autoCompleteView.LoadView(autoCompleteConfig);
            this.Controls.Add(autoCompleteView as TextBox);

        }
    }
}
