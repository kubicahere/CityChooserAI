using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace CityChooserAI.View
{
    /// <summary>
    /// Interaction logic for RightPanel.xaml
    /// </summary>
    public partial class RightPanel : UserControl
    {
        public RightPanel()
        {
            InitializeComponent();
        }
        #region Dependencies
        public static readonly DependencyProperty CheckClickProperty = DependencyProperty.Register(
            "CheckCl", typeof(ICommand), typeof(RightPanel), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty CalcCitiesProperty = DependencyProperty.Register(
            "CalcCities", typeof(ObservableCollection<string>), typeof(RightPanel), new FrameworkPropertyMetadata(null)
            );
        public static readonly DependencyProperty CalcCitiesSelectedProperty = DependencyProperty.Register(
            "CalcCitiesSelected", typeof(string), typeof(RightPanel), new FrameworkPropertyMetadata(null)
            );
        #endregion
        #region Getters & setters
        public ICommand CheckCl
        {
            get { return (ICommand)GetValue(CheckClickProperty); }
            set { SetValue(CheckClickProperty, value); }
        }
        public ObservableCollection<string> CalcCities
        {
            get { return (ObservableCollection<string>)GetValue(CalcCitiesProperty); }
            set { SetValue(CalcCitiesProperty, value); }
        }
        public string CalcCitiesSelected
        {
            get { return (string)GetValue(CalcCitiesSelectedProperty); }
            set { SetValue(CalcCitiesSelectedProperty, value); }
        }
        #endregion
        #region Events
        public static readonly RoutedEvent CheckClickEvent =
            EventManager.RegisterRoutedEvent("OtherCheckClick", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RightPanel));
        public event RoutedEventHandler CheckClick
        {
            add { AddHandler(CheckClickEvent, value); }
            remove { RemoveHandler(CheckClickEvent, value); }
        }
        void RaiseCheckClick(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(CheckClickEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent CalcCitiesChangedEvent =
            EventManager.RegisterRoutedEvent("OtherCalcCitiesSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RightPanel));
        public event RoutedEventHandler CalcCitiesChanged
        {
            add { AddHandler(CalcCitiesChangedEvent, value); }
            remove { RemoveHandler(CalcCitiesChangedEvent, value); }
        }
        void RaiseCalcCitiesChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(CalcCitiesChangedEvent);
            RaiseEvent(args);
        }

        #endregion
    }
}
