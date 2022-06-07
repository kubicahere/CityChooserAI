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
    internal class MainPanel : BaseViewModel
    {
        #region Attributes
        private readonly string[] _continets = {"Worldwide", "Africa", "Asia", "Europe", "North America", "South America", "Oceania" };
        private string _selectedContinent = string.Empty;
        private ObservableCollection<string> _totalAttributes, _chosenAttributes;
        private string _singleTotalAttribute, _singleChosenAttribute;
        public MainPanel()
        {
            totalAttributes = LoadTotalAttributes();
            chosenAttributes = new ObservableCollection<string>();
            _selectedContinent = _continets[0];
            singleTotalAttribute = null;
            singleChosenAttribute = null;
        }
        #endregion
        #region Getters & setters
        public string[] continents { get { return _continets; } }
        public string selectedContinent
        {
            get
            {
                return _selectedContinent;
            }
            set
            {
                _selectedContinent = value;
                OnPropertyChanged(nameof(selectedContinent));
            }
        }
        public ObservableCollection<string> totalAttributes 
        {
            get 
            {
                return _totalAttributes;
            }
            set
            {
                _totalAttributes = value;
                OnPropertyChanged(nameof(selectedContinent));
            }
        }
        public ObservableCollection<string> chosenAttributes
        {
            get
            {
                return _chosenAttributes;
            }
            set
            {
                _chosenAttributes = value;
                OnPropertyChanged(nameof(chosenAttributes));
            }
        }
        public string singleTotalAttribute
        {
            get
            {
                return _singleTotalAttribute;
            }
            set
            {
                _singleTotalAttribute = value;
                OnPropertyChanged(nameof(singleTotalAttribute));
            }
        }
        public string singleChosenAttribute
        {
            get
            {
                return _singleChosenAttribute;
            }
            set
            {
                _singleChosenAttribute = value;
                OnPropertyChanged(nameof(singleChosenAttribute));
            }
        }
        #endregion
        #region Methods
        public void continentChanged(object sender){}
        public ObservableCollection<string> LoadTotalAttributes()
        {
            ObservableCollection<string> elements = new ObservableCollection<string>();
            foreach(string at in Attributes.attributes)
            {
                elements.Add(at);
            }
            return elements;
        }
        public void ClearListboxes()
        {
            totalAttributes = LoadTotalAttributes();
            if(chosenAttributes.Count > 0)
            {
                chosenAttributes.Clear();
            }
        }

        #endregion
    }
}
