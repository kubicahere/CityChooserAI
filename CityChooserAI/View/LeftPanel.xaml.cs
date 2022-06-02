﻿using System;
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
        public static readonly DependencyProperty CurrentTotalAttributeProperty = DependencyProperty.Register(
            "CurrentTotalAttributeSource", typeof(string), typeof(LeftPanel), new FrameworkPropertyMetadata(null));
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
        public string CurrentTotalAtrributesSource
        {
            get { return (string)GetValue(CurrentTotalAttributeProperty); }
            set { SetValue(CurrentTotalAttributeProperty, value); }
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
        void RaiseContinentChangedEvent(object sender, SelectionChangedEventArgs e)
        {
            RoutedEventArgs args = new RoutedEventArgs(ContinentChangedEvent);
            RaiseEvent(args);
        }
        //listboxes
         



        #endregion
    }
}
