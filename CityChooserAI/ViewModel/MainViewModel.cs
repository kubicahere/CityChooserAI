using CityChooserAI.ViewModel.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        #region ICommands


        #endregion
    }
}
