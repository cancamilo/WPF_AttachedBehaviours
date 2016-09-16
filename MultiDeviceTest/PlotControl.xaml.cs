using System;
using System.Collections.Generic;
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
using Arction.Wpf.Charting;
using Arction.Wpf.Charting.Axes;
using Arction.Wpf.Charting.SeriesXY;
using Arction.Wpf.Charting.Views.ViewXY;
using GalaSoft.MvvmLight.Messaging;
using MultiDeviceTest.ViewModel;

namespace MultiDeviceTest
{  
    /// <summary>
    /// Interaction logic for PlotControl.xaml
    /// </summary>
    public partial class PlotControl : UserControl, IDisposable
    {
        private LightningChartUltimate m_chart;
        double sampleInterval = 1.0;        // Seconds
        ulong initSamples;
        double xAxisLength;           // Seconds        
        double samplingFreq;
        ulong totalSamples;

        Color[] colors;
        Dictionary<string, PointLineSeries> seriesDic = new Dictionary<string, PointLineSeries>();
        List<string> idsList = new List<string>();
        HorizontalScrollBar sb;
        AxisX xAxis;
        AxisY yAxis;
        DateTime xInitTime;
        DateTime xLastTime;
        public PlotControl ()
        {
            m_chart = null;
            samplingFreq = 1 / sampleInterval;
            colors = new Color[4] { Colors.Yellow, Colors.Blue, Colors.Red, Colors.White };                   
            Messenger.Default.Register<List<string>>(this, InitializeData);
            Messenger.Default.Register <Dictionary<string, List<TimePoint>>>(this, NewData);
            Messenger.Default.Register<bool>(this, StopChart);
            InitializeComponent();
            CreateChart();
        }

        public void Dispose ()
        {
            throw new NotImplementedException();
        }

        public void CreateChart ()
        {
            gridChart.Children.Clear();

            if(m_chart != null)
            {
                m_chart.Dispose();
                m_chart = null;
            }            

            m_chart = new LightningChartUltimate();
            m_chart.ChartName = "Power Measurement";
            m_chart.BeginUpdate();

            ViewXY chartView = m_chart.ViewXY;
            ZoomPanOptions options = new ZoomPanOptions();
            options.AutoYFit.Enabled = true;
            chartView.ZoomPanOptions = options;        

            // Set to true to reduce memory usage.
            chartView.DropOldSeriesData = false;

            // X axis settings            
            // Make the axis length equal to total series length
            // -------------------------------------------------
            double lengthFactor = 0.2;
            initSamples = 100;
            xAxisLength = sampleInterval * initSamples * lengthFactor;
            samplingFreq = 1 / sampleInterval;  // Hz.
            //--------------------------------------------------
                        
            xAxis = chartView.XAxes[0];
            xAxis.ValueType = AxisValueType.Time;
            //xAxis.Maximum = ((double)initSamples / samplingFreq);
            //xAxis.Minimum = xAxis.Maximum - xAxisLength;          
            xLastTime = DateTime.Now;            
            xAxis.Maximum = xAxis.DateTimeToAxisValue(xLastTime);
            xAxis.Minimum = xAxis.Maximum - xAxisLength;
            xAxis.AutoFormatLabels = false;
            xAxis.LabelsTimeFormat = "HH::mm.ss";          

            totalSamples = 0; 

            // Y axis settings
            yAxis = chartView.YAxes[0];            

            chartView.LegendBox.Visible = false;
            chartView.AxisLayout.AutoAdjustMargins = false;

            sb = new HorizontalScrollBar(m_chart);
            sb.Minimum = 0;
            sb.Maximum = (UInt64)(initSamples);
            sb.SmallChange = (UInt64)(initSamples * lengthFactor) / 10;
            sb.LargeChange = (UInt64)(initSamples*lengthFactor);
            sb.Scroll += Sb_Scroll;
            sb.Value = sb.Maximum;
            sb.Offset = new PointIntXY(sb, 0, 35);
            m_chart.HorizontalScrollBars.Add(sb);    

            //m_chart.ViewXY.PointLineSeries.Add(series);           
            
            m_chart.EndUpdate();
            gridChart.Children.Add(m_chart);         
        }
        public void GenerateInitialData ()
        {                       
            Random rnd = new Random();                        
            SeriesPoint[] samples = new SeriesPoint[initSamples];
            double totalSeconds = initSamples / samplingFreq;
            xInitTime = DateTime.Now.AddSeconds(-totalSeconds);
            
            foreach(var item in seriesDic)                     
            {               
                
                for(ulong i = 0; i < initSamples; i++)
                {
                    samples[i].X = xAxis.DateTimeToAxisValue(xInitTime.AddSeconds(i*sampleInterval));
                    samples[i].Y = rnd.NextDouble() / 10000;
                }
                
                seriesDic[item.Key].AddPoints(samples, false);
            }
            xAxis.Minimum = xAxis.DateTimeToAxisValue(DateTime.Now.AddSeconds(-xAxisLength));
            xAxis.Maximum = xAxis.DateTimeToAxisValue(DateTime.Now);
            xLastTime = DateTime.Now;     
            totalSamples = initSamples;
            sb.Maximum = totalSamples;              
        }
        private void Sb_Scroll (object sender, ScrollEventArgs e)
        {
            var newT = e.NewValue;                        

            double xOrigin = xAxis.DateTimeToAxisValue(xInitTime);
            double xEnd = xAxis.DateTimeToAxisValue(xLastTime);           

            var m = (xEnd - xOrigin) / (totalSamples);
            double xNewMin = xOrigin + m * e.NewValue;
            double xNewMax = xNewMin + xAxisLength;           
            xAxis.SetRange(xNewMin, xNewMax);
        }
        public void InitializeData (List<string> data)
        {            
            m_chart.BeginUpdate();
            seriesDic.Clear();
            int col = 0;
            foreach(var item in data)
            {                
                PointLineSeries series = new PointLineSeries(m_chart.ViewXY, xAxis, yAxis);

                // Only Needed for sample data series
                //series.SampleFormat = SampleFormat.DoubleFloat;
                //series.SamplingFrequency = samplingFreq;
                //series.FirstSampleTimeStamp = 1 / samplingFreq;

                series.LineStyle.AntiAliasing = LineAntialias.None;
                series.LineStyle.Color = colors[col % 4];
                series.LineStyle.Width = 1;
                series.ScrollingStabilizing = true;

                //m_chart.ViewXY.PointLineSeries.Add(series);
                m_chart.ViewXY.PointLineSeries.Add(series);
                seriesDic.Add(item, series);
                col++;
            }
            GenerateInitialData();
            m_chart.EndUpdate();
        }        

        public void NewData (Dictionary<string, List<TimePoint>> lastResults)
        {
            m_chart.BeginUpdate();
            int maxCount = 0;
            foreach(var result in lastResults)
            {
                SeriesPoint[] sample = new SeriesPoint[result.Value.Count];
                for(int i = 0; i < result.Value.Count; i++)
                {
                    sample[i].X = m_chart.ViewXY.XAxes[0].DateTimeToAxisValue(result.Value[i].Date);
                    sample[i].Y = result.Value[i].Y;
                }                
                seriesDic[result.Key].AddPoints(sample, false);

                if(result.Value.Count > maxCount)
                    maxCount = result.Value.Count;
            }

            totalSamples = totalSamples + (ulong)maxCount;
            
            sb.Maximum = (UInt64)totalSamples - 1;
            sb.Value = (UInt64)totalSamples - sb.LargeChange;
            
            xAxis.ScrollPosition = xAxis.DateTimeToAxisValue(DateTime.Now); //totalSamples / samplingFreq;
            xLastTime = DateTime.Now;
            m_chart.EndUpdate();
        }

        public void StopChart (bool stop)
        {
            //xAxis.ScrollMode = XAxisScrollMode.None;
            ViewXY chartView = m_chart.ViewXY;
            ZoomPanOptions options = new ZoomPanOptions();
            options.AutoYFit.Enabled = false;
            chartView.ZoomPanOptions = options;
        }
    }
}
