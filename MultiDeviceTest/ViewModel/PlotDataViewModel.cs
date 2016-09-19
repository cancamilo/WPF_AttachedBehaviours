using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using MultiDeviceTest.General;

namespace MultiDeviceTest.ViewModel
{
    class PlotDataViewModel : ViewModelBase
    {
        ulong initSamples = 50000;
        double xAxisLength = 5;           // Seconds
        double sampleInterval = 0.5;        // Seconds
        double samplingFreq;
        ulong totalSamples;

        DateTime xInitTime;
        DateTime xLastTime;
        #region Properties

        public ObservableDictionary<string, IList<TimePoint>> series;

        public ObservableDictionary<string, IList<TimePoint>> Series
        {
            get
            {
                return series;
            }
            set
            {
                series = value;
                this.RaisePropertyChanged("Series");
            }
        }

        #endregion Properties

        public PlotDataViewModel ()
        {
            samplingFreq = 1 / sampleInterval;

            // Listen to Data Manager Events
            Messenger.Default.Register<List<string>>(this, InitializeData);
            Messenger.Default.Register<Dictionary<string, List<TimePoint>>>(this, NewData);
            Messenger.Default.Register<bool>(this, StopChart);
            Series = new ObservableDictionary<string, IList<TimePoint>>();

        }

        public void InitializeData (List<string> data)
        {
            int col = 0;
            foreach(var item in data)
            {
                //LineSeries serie = new LineSeries();
                //serie.XAxis = categoryXAxis;
                //serie.YAxis = numericYAxis;
                //serie.MarkerType = MarkerType.None;
                //serie.Thickness = 1.0;
                //serie.Resolution = 2.0;
                //serie.ValueMemberPath = "Y";
                //DataChart.Series.Add(serie);
                //seriesDic.Add(item, serie);
                //col++;

                Series.Add(item, new ObservableCollection<TimePoint>());
            }

            GenerateInitialData();
        }

        public void NewData (Dictionary<string, List<TimePoint>> newPoints)
        {
            foreach(var item in newPoints)
            {
                foreach(var point in item.Value)
                {
                    //(seriesDic[item.Key].ItemsSource as ObservableCollection<TimePoint>).Add(point);
                }
            }
        }

        public void StopChart (bool stop)
        {

        }

        public void GenerateInitialData ()
        {
            // Several series. explicit binding with series
            Random rnd = new Random();
            double totalSeconds = initSamples / samplingFreq;
            xInitTime = DateTime.Now.AddSeconds(-totalSeconds);

            foreach(var item in Series)
            {
                ObservableCollection<TimePoint> points = item.Value as ObservableCollection<TimePoint>;
                for(ulong i = 0; i < initSamples; i++)
                {
                    TimePoint point = new TimePoint();
                    point.Index = (int)i;
                    point.Date = xInitTime.AddSeconds(i * sampleInterval);
                    point.Y = rnd.NextDouble() / 10000;
                    points.Add(point);
                }
                //categoryXAxis.ItemsSource = points;
                //seriesDic[item.Key].ItemsSource = points;
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


    }
}
