using CityChooserAI.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CityChooserAI.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        public MainPanel mainPanel { get; set; }
        public ResultsPanel resultsPanel { get; set; }
        public CityDataWindow cityDataWindow { get; set; }
        public MainViewModel()
        {
            mainPanel = new MainPanel();
            resultsPanel = new ResultsPanel(mainPanel);
            cityDataWindow = new CityDataWindow();
        }
        #region Methods
        public void AddChosenFeature(object sender)
        {
            if(mainPanel.singleTotalAttribute == null)
            {
                return;
            }
            if(mainPanel.singleTotalAttribute != null && mainPanel.singleChosenAttribute != null)
            {
                mainPanel.singleTotalAttribute = null;
                mainPanel.singleChosenAttribute = null;
                return;
            }
            mainPanel.chosenAttributes.Add(mainPanel.singleTotalAttribute);
            mainPanel.totalAttributes.Remove(mainPanel.singleTotalAttribute);
        }
        public void RemoveChosenFeature(object sender)
        {
            if(mainPanel.singleChosenAttribute == null)
            {
                return;
            }
            if (mainPanel.singleTotalAttribute != null && mainPanel.singleChosenAttribute != null)
            {
                mainPanel.singleTotalAttribute = null;
                mainPanel.singleChosenAttribute = null;
                return;
            }
            mainPanel.totalAttributes.Add(mainPanel.singleChosenAttribute);
            mainPanel.chosenAttributes.Remove(mainPanel.singleChosenAttribute);
        }

        #endregion

        #region ICommands
        private ICommand _addFeatureClick = null;
        public ICommand addFeatureClick
        {
            get
            {
                if (_addFeatureClick == null)
                {
                    _addFeatureClick = new RelayCommand(AddChosenFeature, arg => true);
                }
                return _addFeatureClick;
            }
        }
        private ICommand _removeFeatureClick = null;
        public ICommand removeFeatureClick
        {
            get
            {
                if(_removeFeatureClick == null)
                {
                    _removeFeatureClick = new RelayCommand(RemoveChosenFeature, arg => true);
                }
                return _removeFeatureClick;
            }
        }
        private ICommand _checkClick = null;
        public ICommand checkClick
        {
            get
            {
                if (_checkClick == null)
                {
                    _checkClick = new RelayCommand(resultsPanel.checkClick, arg => true);
                }
                return _checkClick;
            }
        }
        #endregion
    }
}
