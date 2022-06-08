using CityChooserAI.Model;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Shapes;

namespace CityChooserAI.View
{
    /// <summary>
    /// Interaction logic for OutputDataWindow.xaml
    /// </summary>
    public partial class OutputDataWindow : MetroWindow
    {
        public OutputDataWindow(City city)
        {
            InitializeComponent();
            
            SetInfo(city);
        }
        private string _cityContinent;
        public string cityContinent
        {
            get { return _cityContinent; }
            set { _cityContinent = value; }
        }
        private string[] _tabAttributes;
        public string[] tabAttributes
        {
            get { return _tabAttributes; }
            set { _tabAttributes = value; }
        }
        public void SetInfo(City city)
        {
            tabAttributes = city.attr;
            this.Title = tabAttributes[1];
            CityName.Text = tabAttributes[1];
            CountryName.Text = tabAttributes[2];
            ContinentName.Text = tabAttributes[3];
            CultureInfo culture = new CultureInfo("en-US");

            for (int i = 0; i < Attributes.attributes.Length; i++) //Add the names of attributes to column 1 & 2
            {
                if(i < 9)
                {
                    AttributesKey1.Items.Add(Attributes.attributes[i]);
                }
                else
                {
                    AttributesKey2.Items.Add(Attributes.attributes[i]);
                }
            }
            for(int i = 4; i < tabAttributes.Length; i++) //Add the values of attributes to column 1 & 2
            {
                if(i < 13)
                {
                    decimal x = Math.Round(Convert.ToDecimal(tabAttributes[i], culture), 0);
                    AttributesValue1.Items.Add(x.ToString());
                }
                else
                {
                    decimal x = Math.Round(Convert.ToDecimal(tabAttributes[i], culture), 0);
                    AttributesValue2.Items.Add(x.ToString());
                }
            }
        }
    }
}
