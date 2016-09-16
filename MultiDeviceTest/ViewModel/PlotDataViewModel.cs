using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;

namespace MultiDeviceTest.ViewModel
{
    class PlotDataViewModel : ViewModelBase
    {
        #region Properties

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
                RaisePropertyChanged(PlotSeriesPropertyName);
            }
        }

        #endregion Properties

        public PlotDataViewModel ()
        {
        }

    }
}
