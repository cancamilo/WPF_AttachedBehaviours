using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Ivi.Visa;
using NationalInstruments.Visa;

namespace MultiDeviceTest.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase, IDisposable
    {
        #region Fields

        DataManager dataManager = null;

        #endregion Fields

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel ()
        {
            LoadDevicesCommand = new RelayCommand(LoadAllDevices);
            StartDevicesCommand = new RelayCommand(StartAllDevices);
            StopDevicesCommand = new RelayCommand(StopAllDevices);
            //Messenger.Default.Register<Dictionary<string, TimePoint>>(this, HandleUpdate);
        }
        private void HandleUpdate (Dictionary<string, TimePoint> res)
        {
            this.UpdateResult();
        }
        public void UpdateResult ()
        {
            double value1 = DeviceList[FirstSelection].PowerValue;
            double value2 = DeviceList[SecondSelection].PowerValue;

            switch(selectedOperation)
            {
                case 0:
                    OperationResult = value1 + value2;
                    break;
                case 1:
                    OperationResult = value1 - value2;
                    break;
                case 2:
                    OperationResult = value1 * value2;
                    break;
                default:
                    break;
            }            
        }

        #region Commands

        public ICommand StopDevicesCommand
        {
            get; set;
        }

        public ICommand LoadDevicesCommand
        {
            get; set;
        }
        public ICommand StartDevicesCommand
        {
            get; set;
        }

        private void LoadAllDevices ()
        {
            if(DeviceList != null)
                DeviceList.Clear();

            DeviceList = new ObservableCollection<PowerMeter>();
            //for(int i = 0; i < 10; i++)
            //{
            //    DeviceList.Add(new PowerMeter() { DeviceID = i.ToString(), PowerValue = 12.324523});
            //}
            string filter = "USB?*";
            using(var rm = new ResourceManager())
            {
                try
                {
                    IEnumerable<string> resources = rm.Find(filter);
                    List<string> ids = new List<string>();
                    foreach(string s in resources)
                    {
                        ParseResult parseResult = rm.Parse(s);

                        char[] spliters = new char[1];
                        spliters[0] = ':';
                        var list = s.Split(spliters,StringSplitOptions.RemoveEmptyEntries);

                        string type = "";
                        if(list.Count<string>() > 5)
                            type = list[5];

                        // Ignore instruments with "Raw" Type.
                        if(type == "RAW")
                            continue;

                        PowerMeter pm = new PowerMeter()
                        {
                            DeviceID = s,
                            PowerValue = 0.0,
                            SerialNumber = list[3]
                        };

                        ids.Add(s);
                        DeviceList.Add(pm);
                    }

                    Messenger.Default.Send<List<string>>(ids);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void StartAllDevices ()
        {
            dataManager = new DataManager(deviceList);
            dataManager.StartMeasuring();
            IsRunning = true;
        }

        private void StopAllDevices ()
        {
            if(dataManager != null)
            {
                dataManager.Stop();
            }
            IsRunning = false;
        }

        #endregion Commands

        #region Properties

        /// <summary>
        /// The <see cref="IsRunning" /> property's name.
        /// </summary>
        public const string IsRunningPropertyName = "IsRunning";

        private bool isRunning = false;

        /// <summary>
        /// Sets and gets the IsRunning property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public bool IsRunning
        {
            get
            {
                return isRunning;
            }

            set
            {
                if(isRunning == value)
                {
                    return;
                }

                isRunning = value;
                RaisePropertyChanged(IsRunningPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="SelectedOperation" /> property's name.
        /// </summary>
        public const string SelectedOperationPropertyName = "SelectedOperation";

        private int selectedOperation = 0;

        /// <summary>
        /// Sets and gets the SelectedOperation property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SelectedOperation
        {
            get
            {
                return selectedOperation;
            }
            set
            {
                if(selectedOperation == value)
                {
                    return;
                }

                selectedOperation = value;
                RaisePropertyChanged(SelectedOperationPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="FirstSelection" /> property's name.
        /// </summary>
        public const string FirstSelectionPropertyName = "FirstSelection";

        private int firstSelection = 0;

        /// <summary>
        /// Sets and gets the FirstSelection property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int FirstSelection
        {
            get
            {
                return firstSelection;
            }

            set
            {
                if(firstSelection == value)
                {
                    return;
                }

                firstSelection = value;
                RaisePropertyChanged(FirstSelectionPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="SecondSelection" /> property's name.
        /// </summary>
        public const string SecondSelectionPropertyName = "SecondSelection";

        private int secondSelection = 0;

        /// <summary>
        /// Sets and gets the SecondSelection property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public int SecondSelection
        {
            get
            {
                return secondSelection;
            }

            set
            {
                if(secondSelection == value)
                {
                    return;
                }

                secondSelection = value;
                RaisePropertyChanged(SecondSelectionPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="OperationResult" /> property's name.
        /// </summary>
        public const string OperationResultPropertyName = "OperationResult";

        private double operationResult = 0.0;

        /// <summary>
        /// Sets and gets the OperationResult property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double OperationResult
        {
            get
            {
                return operationResult;
            }

            set
            {
                if(operationResult == value)
                {
                    return;
                }

                operationResult = value;
                RaisePropertyChanged(OperationResultPropertyName);
            }
        }

        /// <summary>
        /// The <see cref="DeviceList" /> property's name.
        /// </summary>
        public const string DeviceListPropertyName = "DeviceList";

        private ObservableCollection<PowerMeter> deviceList = null;

        /// <summary>
        /// Sets and gets the DeviceList property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public ObservableCollection<PowerMeter> DeviceList
        {
            get
            {
                return deviceList;
            }
            set
            {
                if(deviceList == value)
                {
                    return;
                }
                deviceList = value;
                RaisePropertyChanged(DeviceListPropertyName);
            }
        }

        #endregion Properties        

        public void Dispose ()
        {
            dataManager.Stop();
        }
    }
  
}