using CityChooserAI.Model;
using CityChooserAI.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Diagnostics;
using System.Globalization;
using CityChooserAI.View;

namespace CityChooserAI.ViewModel
{
    internal class ResultsPanel : BaseViewModel
    {
        public MainPanel MainPanel { get; set; }
        public ResultsPanel(MainPanel obj)
        {
            MainPanel = obj;
        }
        #region Attributes
        private List<City> _cityList = new List<City>();
        private List<string> _tmpList;
        private ObservableCollection<string> _resultCityList = new ObservableCollection<string>();
        private string _selectedResultCity;
        #endregion
        #region Getters & setters
        public List<City> cityList
        {
            get { return _cityList; }
            set { _cityList = value; }
        }
        public List<string> tmpList
        {
            get { return _tmpList; }
            set { _tmpList = value; }
        }
        public ObservableCollection<string> resultCityList
        {
            get { return _resultCityList; }
            set 
            { 
                _resultCityList = value;
                OnPropertyChanged(nameof(resultCityList));
            }
        }
        public string selectedResultCity
        {
            get { return _selectedResultCity; }
            set
            {
                _selectedResultCity = value;
                OnPropertyChanged(nameof(resultCityList));
            }
        }
        #endregion
        #region Methods
        public void checkClick(object sender)
        {

            if (MainPanel.chosenAttributes.Count < 3 || MainPanel.chosenAttributes.Count > 6)
            {
                MessageBox.Show("Invalid amount of parameters!");
                return;
            }

            resultCityList.Clear();

            using (var reader = new StreamReader(@"QualityOfLifeDataFrame.csv")) // Add the .csv file to Relase folder!
            {
                List<string> P1 = new List<string>();
                List<string> P2 = new List<string>();
                List<string> P3 = new List<string>();
                List<string> P4 = new List<string>();
                List<string> P5 = new List<string>();
                List<string> P6 = new List<string>();
                List<int> AttributesIndex = new List<int>();

                List<string> CityNames = new List<string>();
                List<string> CountryNames = new List<string>();
                List<string> Continents = new List<string>();
                List<decimal> Score = new List<decimal>();


                foreach (var attr in MainPanel.chosenAttributes.ToArray())
                {
                    AttributesIndex.Add(Array.IndexOf(Attributes.attributes, attr) + 4); // Get the indexes of chosen columns, ignore first 4 with names
                }

                decimal P1_ratio = new decimal(1); //TODO: Sliders with proper values
                decimal P2_ratio = new decimal(0.8);
                decimal P3_ratio = new decimal(0.6);
                decimal P4_ratio = new decimal(0.4);
                decimal P5_ratio = new decimal(0.2);
                decimal P6_ratio = new decimal(0.2);

                reader.ReadLine(); // skip first line with column description

                if(MainPanel.selectedContinent == "Worldwide")
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        P1.Add(values[AttributesIndex[0]]);
                        P2.Add(values[AttributesIndex[1]]);
                        P3.Add(values[AttributesIndex[2]]);

                        switch (MainPanel.chosenAttributes.Count) { 
                            case 4:
                                P4.Add(values[AttributesIndex[3]]);
                                break;
                            case 5:
                                P4.Add(values[AttributesIndex[3]]);
                                P5.Add(values[AttributesIndex[4]]);
                                break;
                            case 6:
                                P4.Add(values[AttributesIndex[3]]);
                                P5.Add(values[AttributesIndex[4]]);
                                P6.Add(values[AttributesIndex[5]]);
                                break;
                            default:
                                break;
                        }
                        CityNames.Add(values[1]);
                        CountryNames.Add(values[2]);
                        Continents.Add(values[3]);
                    }
                }
                else
                {
                    while (!reader.EndOfStream)
                    {
                        var line = reader.ReadLine();
                        var values = line.Split(',');

                        if(values[3] == MainPanel.selectedContinent)
                        {
                            P1.Add(values[AttributesIndex[0]]);
                            P2.Add(values[AttributesIndex[1]]);
                            P3.Add(values[AttributesIndex[2]]);

                            switch (MainPanel.chosenAttributes.Count)
                            {
                                case 4:
                                    P4.Add(values[AttributesIndex[3]]);
                                    break;
                                case 5:
                                    P4.Add(values[AttributesIndex[3]]);
                                    P5.Add(values[AttributesIndex[4]]);
                                    break;
                                case 6:
                                    P4.Add(values[AttributesIndex[3]]);
                                    P5.Add(values[AttributesIndex[4]]);
                                    P6.Add(values[AttributesIndex[5]]);
                                    break;
                                default:
                                    break;
                            }
                            CityNames.Add(values[1]);
                            CountryNames.Add(values[2]);
                            Continents.Add(values[3]);
                        }
                    }
                }

                for(int i = 0; i < CityNames.Count; i++)
                {
                    CultureInfo culture = new CultureInfo("en-US"); // for dots in values

                    switch (MainPanel.chosenAttributes.Count)
                    {
                        case 3:
                            Score.Add((Convert.ToDecimal(P1[i], culture) * P1_ratio) + (Convert.ToDecimal(P2[i], culture) * P2_ratio)
                        + (Convert.ToDecimal(P3[i], culture) * P3_ratio));
                            break;
                        case 4:
                            Score.Add((Convert.ToDecimal(P1[i], culture) * P1_ratio) + (Convert.ToDecimal(P2[i], culture) * P2_ratio)
                        + (Convert.ToDecimal(P3[i], culture) * P3_ratio) + (Convert.ToDecimal(P4[i], culture) * P4_ratio));
                            break;
                        case 5:
                            Score.Add((Convert.ToDecimal(P1[i], culture) * P1_ratio) + (Convert.ToDecimal(P2[i], culture) * P2_ratio)
                        + (Convert.ToDecimal(P3[i], culture) * P3_ratio) + (Convert.ToDecimal(P4[i], culture) * P4_ratio)
                        + (Convert.ToDecimal(P5[i], culture) * P5_ratio));
                            break;
                        case 6:
                            Score.Add((Convert.ToDecimal(P1[i], culture) * P1_ratio) + (Convert.ToDecimal(P2[i], culture) * P2_ratio)
                        + (Convert.ToDecimal(P3[i], culture) * P3_ratio) + (Convert.ToDecimal(P4[i], culture) * P4_ratio)
                        + (Convert.ToDecimal(P5[i], culture) * P5_ratio) + (Convert.ToDecimal(P6[i], culture) * P6_ratio));
                            break;
                        default:
                            break;
                    }

                    //Debug.WriteLine(CityNames[i] + ": " + Score[i]);
                }
                var TOP5 = Score.OrderByDescending(x => x).Take(5).ToArray();

                string resultMessage = "TOP 5:";
                tmpList = new List<string>();
                Debug.WriteLine("TOP 5:");
                for(int i = 0; i < 5; i++)
                {
                    var index = Score.IndexOf(TOP5[i]);
                    //Debug.WriteLine(CityNames[index] + "," + CountryNames[index] + ", " + Continents[index] + ": " + TOP5[i]);
                    resultMessage += "\n" + CityNames[index] + "," + CountryNames[index] + ", " + Continents[index] + ": " + TOP5[i];
                    tmpList.Add(CityNames[index]);
                    resultCityList.Add(CityNames[index]);
                }

                MessageBox.Show(resultMessage);
                Debug.WriteLine("Continent: " + MainPanel.selectedContinent);
                Debug.WriteLine("Number of attributes: " + MainPanel.chosenAttributes.Count);
                foreach (var element in MainPanel.chosenAttributes.ToArray()) Debug.Write(element + ", ");
                Debug.Write("\n");

            }

        }
        public void singleCityData(object sender)
        {
            if (selectedResultCity == null) return;
            
            int selectedIndex = resultCityList.IndexOf(selectedResultCity);
            MessageBox.Show(tmpList[selectedIndex]);
            OutputDataWindow ODW = new OutputDataWindow();
            ODW.Show();
        }


        #endregion
    }
}
