using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Infragistics.Controls.Charts;

namespace MultiDeviceTest.Behaviours
{
    public class ChartSeriesSourceBehaviour : Behavior<XamDataChart>
    {

        public IDictionary ChartSeries
        {
            get
            {
                return (IDictionary)GetValue(ChartSeriesProperty);
            }
            set
            {
                SetValue(ChartSeriesProperty, value);
            }
        }
            
        // Using a DependencyProperty as the backing store for ChartSeries.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ChartSeriesProperty =
            DependencyProperty.Register("ChartSeries", typeof(IDictionary), typeof(ChartSeriesSourceBehaviour), new PropertyMetadata(null, new PropertyChangedCallback(OnChartSeriesPropertyChanged)));

        private static void OnChartSeriesPropertyChanged (DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ChartSeriesSourceBehaviour behavior = d as ChartSeriesSourceBehaviour;
            if(behavior != null)
                behavior.OnChartSeriesPropertyChanged((IDictionary)e.OldValue, (IDictionary)e.NewValue);
        }

        // When Entire Dictionary changes. e.g New reference
        void OnChartSeriesPropertyChanged (IDictionary oldDic, IDictionary newDic)
        {         
            var seriesBase = AssociatedObject.Series;

            if(oldDic != null)
            {
                var oldSeries = oldDic as INotifyCollectionChanged;
                if(oldSeries != null)
                    oldSeries.CollectionChanged -= SeriesChanged;
            }

            if(newDic != null)
            {
                var newSeries = newDic as INotifyCollectionChanged;
                if(newSeries != null)
                    newSeries.CollectionChanged += SeriesChanged;

                // Add the dictionary items to the chart collection.
                foreach(var item in newDic)
                {
                    // TODO: key needed for adding additional information to the chart, such as legends, markers, colors, etc.

                    var list = ((KeyValuePair<string, List<TimePoint>>) item).Value;
                    LineSeries serie = new LineSeries();
                    serie.ItemsSource = list;
                    seriesBase.Add(serie);                  
                }
            }
        }

        // When items are added or removed from dictionary
        void SeriesChanged (object sender, NotifyCollectionChangedEventArgs e)
        {

        }

    }
}
