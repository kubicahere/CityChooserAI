using CityChooserAI.Model;
using CityChooserAI.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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
        private List<City> _tmpList;
        private ObservableCollection<string> _resultPlayersList = new ObservableCollection<string>();
        private string _selectedResultCity;
        #endregion
        #region Getters & setters
        public List<City> cityList
        {
            get { return _cityList; }
            set { _cityList = value; }
        }
        public List<City> tmpList
        {
            get { return _tmpList; }
            set { _tmpList = value; }
        }
        public ObservableCollection<string> resultPlayersList
        {
            get { return _resultPlayersList; }
            set 
            { 
                resultPlayersList = value;
                OnPropertyChanged(nameof(resultPlayersList));
            }
        }
        public string selectedResultCity
        {
            get { return _selectedResultCity; }
            set
            {
                _selectedResultCity = value;
                OnPropertyChanged(nameof(selectedResultCity));
            }
        }
        #endregion
        #region Methods
        public void checkClick(object sender)
        {
            if(MainPanel.chosenAttributes.Count < 3 || MainPanel.chosenAttributes.Count > 6)
            {
                MessageBox.Show("Invalid amount of parameters!");
                return;
            }
            //TODO SET PATH TO .csv AND LOAD DATA TO FILE
            tmpList = new List<City>(cityList);
            resultPlayersList.Clear();
            // TODO AI FUNCTIONS HERE
        }
        public void singleCityData(object sender)
        {
            //TODO CREATE RESULT WINDOW WITH DATA OF SELECTED CITY
        }


        #endregion
    }
}
