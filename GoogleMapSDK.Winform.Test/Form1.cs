using GoogleMapSDK.Contract.Components.AutoComplete.Views;
using GoogleMapSDK.Contract.Components.GoogleMap;
using GoogleMapSDK.Contract.Components.GoogleMap.Models;
using GoogleMapSDK.Contract.Models;
using GoogleMapSDK.Core.Components.AutoComplete.Models;
using GoogleMapSDK.Winform.Components.AutoComplete.Views;
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
        private readonly IGoogleMapView _googleMapView;
        
        public Form1(
            IAutoCompleteView<PlaceSimpleModel> autoCompleteView, 
            GoogleMapAutoCompleteConfig autoCompleteConfig,
            IGoogleMapView googleMapView)
        {
            InitializeComponent();

            autoCompleteView.LoadView(autoCompleteConfig);
            searchBoxFlowLayoutPanel.Controls.Add(autoCompleteView as TextBox);

            _googleMapView = googleMapView;
            mapFlowLayoutPanel.Controls.Add(googleMapView as Control);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _googleMapView.AddMarker(new LocationModel
            {
                Latitude = 25,
                Longitude = 120
            }, MarkerType.arrow);
            _googleMapView.ShowAll();
        }
    }
}
