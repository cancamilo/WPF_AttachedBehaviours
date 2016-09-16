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
            Messenger.Default.Register<List<string>>(this, InitializeData);
            Messenger.Default.Register<Dictionary<string, List<TimePoint>>>(this, NewData);
            Messenger.Default.Register<bool>(this, StopChart);

            this.DataContext = this;

            InitializeChart();

            //viewModel = new PlotDataViewModel();
            //this.DataContext = viewModel;
        }

        public void InitializeChart ()
        {
                                  
        }

        public void InitializeData (List<string> data)
        {
            int col = 0;
            foreach(var item in data)
            {
                LineSeries serie = new LineSeries();
                serie.XAxis = categoryXAxis;
                serie.YAxis = numericYAxis;
                serie.MarkerType = MarkerType.None;
                serie.Thickness = 1.0;
                serie.Resolution = 2.0;
                serie.ValueMemberPath = "Y";
                DataChart.Series.Add(serie);
                seriesDic.Add(item, serie);
                col++;
            }

            GenerateInitialData();
        }
        public void GenerateInitialData ()
        {
            // Several series. explicit binding with series
            Random rnd = new Random();
            

            double totalSeconds = initSamples / samplingFreq;
            xInitTime = DateTime.Now.AddSeconds(-totalSeconds);
            
            foreach(var item in seriesDic)
            {
                ObservableCollection<TimePoint> points = new ObservableCollection<TimePoint>();
                for(ulong i = 0; i < initSamples; i++)
                {
                    TimePoint point = new TimePoint();
                    point.Index = (int)i;
                    point.Date = xInitTime.AddSeconds(i * sampleInterval);
                    point.Y = rnd.NextDouble() / 10000;
                    points.Add(point);
                }
                categoryXAxis.ItemsSource = points;
                seriesDic[item.Key].ItemsSource = points;
            }

            //// Just one Series. Direct binding
            //Random rnd = new Random();            
            //double totalSeconds = initSamples / samplingFreq;
            //xInitTime = DateTime.Now.AddSeconds(-totalSeconds);

            //for(ulong i = 0; i < initSamples; i++)
            //{
            //    TimePoint point = new TimePoint();
            //    point.Index = (int)i;
            //    point.Date = xInitTime.AddSeconds(i * sampleInterval);
            //    point.Y = rnd.NextDouble() / 10000;
            //    PlotSeries.Add(point);
            //}                                                      

            totalSamples = initSamples;
        }
        public void NewData (Dictionary<string, List<TimePoint>> newPoints)
        {
            foreach(var item in newPoints)
            {
                foreach(var point in item.Value)
                {
                    (seriesDic[item.Key].ItemsSource as ObservableCollection<TimePoint>).Add(point);
                }                
            }
        }
        public void StopChart (bool stop)
        {

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
