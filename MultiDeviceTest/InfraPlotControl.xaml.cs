using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using GalaSoft.MvvmLight.Messaging;
using Infragistics.Controls.Charts;
using MultiDeviceTest.ViewModel;

namespace MultiDeviceTest
{
    /// <summary>
    /// Interaction logic for InfraPlotControl.xaml
    /// </summary>
    public partial class InfraPlotControl : UserControl, INotifyPropertyChanged
    {
        PlotDataViewModel viewModel;
        Dictionary<string, LineSeries> seriesDic = new Dictionary<string, LineSeries>();
        ulong initSamples = 5000000;
        double xAxisLength = 5;           // Seconds
        double sampleInterval = 0.5;        // Seconds
        double samplingFreq;
        ulong totalSamples;

        DateTime xInitTime;
        DateTime xLastTime;

        /// <summary>
        /// The <see cref="PlotSeries" /> property's name.
        /// </summary>
        public const string PlotSeriesPropertyName = "PlotSeries";

        private ObservableCollection<TimePoint> plotSeries = new ObservableCollection<TimePoint>();

        /// <summary>
        /// Sets and gets the PlotSeries property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<TimePoint> PlotSeries
        {
            get
            {
                return plotSeries;
            }
            set
            {
                if(plotSeries == value)
                {
                    return;
                }
                plotSeries = value;
                OnPropertyChanged("PlotSeries");
            }
        }
        public InfraPlotControl ()
        {
            InitializeComponent();
            samplingFreq = 1 / sampleInterval;                            
            viewModel = new PlotDataViewModel();
            this.DataContext = viewModel;
        }
      

        #region Event Handlers
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged (string propertyName)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
        protected void OnPropertyChanged (PropertyChangedEventArgs propertyChangedEventArgs)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if(handler != null)
                handler(this, propertyChangedEventArgs);
        }
        #endregion

    }
}
