using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Messaging;

namespace MultiDeviceTest
{
    public class DataManager
    {
        Thread measurementThread = null;
        Thread[] threads;
        ObservableCollection<PowerMeter> devices = null;
        Dictionary<string, List<TimePoint>> newPoints = new Dictionary<string, List<TimePoint>>();
        Dictionary<string, List<TimePoint>> fullData = new Dictionary<string, List<TimePoint>>();
        Dictionary<string, HistogramData> histograms = new Dictionary<string, HistogramData>();
        DispatcherTimer timer1;

        public DataManager (ObservableCollection<PowerMeter> devs)
        {
            devices = devs;

            timer1 = new DispatcherTimer();
            timer1.Interval = new TimeSpan(0, 0, 0, 0, 1000);
            timer1.Tick += new EventHandler(UpdateVMData);

            //measurementThread = new Thread(new ThreadStart(this.readDataSync));
            int count = devs.Count;
            threads = new Thread[count];
        }
        private void UpdateVMData (object sender, EventArgs e)
        {
            //Dictionary<string, TimePoint> results = new Dictionary<string, TimePoint>();
            //// signal data update            
            //foreach(var device in devices)
            //{
            //    TimePoint point = new TimePoint();
            //    point.Date = device.LastTime;
            //    point.Y = device.PowerValue;
            //    results.Add(device.DeviceID, point);
            //}
            //Messenger.Default.Send(results);
            //results.Clear();

            Messenger.Default.Send(newPoints);
            foreach(var item in newPoints)            
                item.Value.Clear();                        

            //Calculate Histograms and Send data to view                        
            //foreach(var item in fullData)            
            //  histograms[item.Key].UpdateHistogram(item.Value);            
        }
        public void StartMeasuring ()
        {
            // Start and read all devices in a single thread
            // measurementThread.Start();           
            timer1.Start();
            Random rnd;
            rnd = new Random();

            // Start one thread for each device.
            int threadId = 0;
            foreach(var pm in devices)
            {
                fullData.Add(pm.DeviceID, new List<TimePoint>());
                newPoints.Add(pm.DeviceID, new List<TimePoint>());
                histograms.Add(pm.DeviceID, new HistogramData(10));

                int interval = rnd.Next(100, 200);
                threads[threadId] = new Thread(() => this.readDataAsync(pm, 300));
                threads[threadId].Start();
                threadId++;
            }
        }
        public void Stop ()
        {
            for(int i = 0; i < devices.Count; i++)
            {
                if(threads[i].IsAlive)
                    threads[i].Abort();
            }
            timer1.Stop();
            Messenger.Default.Send(true);
        }
        private void readDataSync ()
        {
            List<PowerMeter> connectedDevices = new List<PowerMeter>();
            // Search devices.
            // Initialize all devices.
            foreach(var pmeter in devices)
            {
                if("" == pmeter.InitPowerMeter())
                {
                    connectedDevices.Add(pmeter);
                }
            }

            while(true)
            {
                foreach(var dev in connectedDevices)
                {
                    double pw = 0;
                    dev.GetPowerMeasurement(out pw);
                    Thread.Sleep(300);
                    //Console.WriteLine(pw);
                }
            }
        }
        private void readDataAsync (PowerMeter pwMeter, int interval)
        {
            if("" != pwMeter.InitPowerMeter())
                return;

            while(true)
            {
                double pw = 0;
                pwMeter.GetPowerMeasurement(out pw);
                //fullData[pwMeter.DeviceID].Add(new TimePoint(DateTime.Now, pw));
                newPoints[pwMeter.DeviceID].Add(new TimePoint(DateTime.Now, pw));
                Thread.Sleep(interval);
            }
        }
    }
    public class HistogramData
    {
        List<int> data;
        double min;
        double max;
        int rangeLength = 10;

        public HistogramData (int length)
        {
            rangeLength = length;
            data = new List<int>(rangeLength + 1);
            for(int i = 0; i < rangeLength + 1; i++)
                data.Add(0);
        }

        // TODO: can be otimized by just iterating the new points and not the entire set.
        public void UpdateHistogram (List<TimePoint> points)
        {
            // Calculate histogram data from points
            // Find max and min
            min = points.Min(point => point.Y);
            max = points.Max(point => point.Y);
            double step = (max - min) / rangeLength;

            // classify points
            for(int i = 0; i < points.Count; i++)
            {
                // Calculate current point value as relative to the maximum;                       
                double check = (( points[i].Y - min) / (max - min)) * 10;
                var index = Math.Floor(check);
                int dx = (int)index;
                data[dx] +=1;
            }
        }
    }
    public class TimePoint : IComparable<TimePoint>
    {
        public TimePoint ()
        {
            Index = 0;
            Date = DateTime.Now;
            Y = 0;
        }
        public TimePoint (DateTime time, double y)
        {
            Index = 0;
            Date = time;
            Y = y;
        }

        public int Index
        {
            get; set;
        }
        public DateTime Date
        {
            get; set;
        }
        public double Y
        {
            get; set;
        }

        public int CompareTo (TimePoint other)
        {
            if(other.Y > this.Y)
                return -1;
            else if(other.Y == this.Y)
                return 0;
            else
                return 1;
        }
    }
}
