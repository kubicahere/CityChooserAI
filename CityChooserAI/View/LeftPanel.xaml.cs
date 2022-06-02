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
    /// Interaction logic for LeftPanel.xaml
    /// </summary>
    public partial class LeftPanel : UserControl
    {
        public LeftPanel()
        {
            InitializeComponent();
        }
        #region Dependencies
        //continents combobox
        public static readonly DependencyProperty ContinentProperty = DependencyProperty.Register(
            "Continents", typeof(string[]), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty CurrentContinentProperty = DependencyProperty.Register(
            "CurrentContinent", typeof(string), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
        //listbox with every element
        public static readonly DependencyProperty TotalAttributesSourceProperty = DependencyProperty.Register(
            "TotalAttributesSource", typeof(ObservableCollection<string>), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty CurrentTotalAttributesProperty = DependencyProperty.Register(
            "CurrentTotalAttributesSource", typeof(string), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty ChosenAttributesSourceProperty = DependencyProperty.Register(
            "ChosenAttributesSource", typeof(ObservableCollection<string>), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty CurrentChosenAttributeSourceProperty = DependencyProperty.Register(
            "CurrentChosenAttributeSource", typeof(string), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
        //buttons
        public static readonly DependencyProperty AddFeatureProperty = DependencyProperty.Register(
            "AddFeature", typeof(ICommand), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
        public static readonly DependencyProperty RemoveFeatureProperty = DependencyProperty.Register(
            "RemoveFeature", typeof(ICommand), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
        #endregion
        #region Getters & setters
        public string[] Continents
        {
            get { return (string[])GetValue(ContinentProperty); }
            set { SetValue(ContinentProperty, value); }
        }
        public string CurrentContinent
        {
            get { return (string)GetValue(CurrentContinentProperty); }
            set { SetValue(CurrentContinentProperty, value); }
        }
        public ObservableCollection<string> TotalAttributesSource
        {
            get { return (ObservableCollection<string>)GetValue(TotalAttributesSourceProperty); }
            set { SetValue(TotalAttributesSourceProperty, value); }
        }
        public string CurrentTotalAttributesSource
        {
            get { return (string)GetValue(CurrentTotalAttributesProperty); }
            set { SetValue(CurrentTotalAttributesProperty, value); }
        }
        public ObservableCollection<string> ChosenAttributesSource
        {
            get { return (ObservableCollection<string>)GetValue(ChosenAttributesSourceProperty); }
            set { SetValue(ChosenAttributesSourceProperty, value); }
        }
        public string CurrentChosenAttributeSource
        {
            get { return (string)GetValue(CurrentChosenAttributeSourceProperty); }
            set { SetValue(CurrentChosenAttributeSourceProperty, value); }
        }
        public ICommand AddFeature
        {
            get { return (ICommand)GetValue(AddFeatureProperty); }
            set { SetValue(AddFeatureProperty, value); }
        }
        public ICommand RemoveFeature
        {
            get { return (ICommand)GetValue(RemoveFeatureProperty); }
            set { SetValue(RemoveFeatureProperty, value); }
        }
        #endregion
        #region Events
        //continents combobox
        public static RoutedEvent ContinentChangedEvent =
            EventManager.RegisterRoutedEvent("OtherContinentSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftPanel));
        public event RoutedEventHandler ContinentChanged
        {
            add { AddHandler(ContinentChangedEvent, value); }
            remove { RemoveHandler(ContinentChangedEvent, value); }
        }
        void RaiseContinentChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ContinentChangedEvent);
            RaiseEvent(args);
        }
        //listboxes
        public static readonly RoutedEvent CurrentTotalItemChangedEvent =
            EventManager.RegisterRoutedEvent("OtherTotalItemSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftPanel));
        public event RoutedEventHandler CurrentTotalItemChanged
        {
            add { AddHandler(CurrentTotalItemChangedEvent, value); }
            remove { RemoveHandler(CurrentTotalItemChangedEvent, value); }
        }
        void RaiseTotalItemChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(CurrentTotalItemChangedEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent CurrentChosenItemChangedEvent =
            EventManager.RegisterRoutedEvent("OtherChosenItemSelected", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftPanel));
        public event RoutedEventHandler CurrentChosenItemChanged
        {
            add { AddHandler(CurrentChosenItemChangedEvent, value); }
            remove { RemoveHandler(CurrentChosenItemChangedEvent, value); }
        }
        void RaiseChosenItemChanged(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(CurrentChosenItemChangedEvent);
            RaiseEvent(args);
        }
        //buttons
        public static readonly RoutedEvent AddClickButtonEvent =
            EventManager.RegisterRoutedEvent("OtherAddClickButton", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftPanel));
        public event RoutedEventHandler AddClickButton
        {
            add { AddHandler(AddClickButtonEvent, value); }
            remove { RemoveHandler(AddClickButtonEvent, value); }
        }
        void RaiseAddClickButton(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(AddClickButtonEvent);
            RaiseEvent(args);
        }
        public static readonly RoutedEvent RemoveClickButtonEvent =
            EventManager.RegisterRoutedEvent("OtherRemoveClickButton", RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(LeftPanel));
        public event RoutedEventHandler RemoveClickButton
        {
            add { AddHandler(RemoveClickButtonEvent, value); }
            remove { RemoveHandler(RemoveClickButtonEvent, value); }
        }
        void RaiseRemoveClickButton(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(RemoveClickButtonEvent);
            RaiseEvent(args);
        }

        #endregion
    }
}
