using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using Thorlabs.PM100D_32;
using Thorlabs.PM100D_32.Interop;

namespace MultiDeviceTest
{
    public class PowerMeter : ObservableObject
    {
        PM100D pm;

        public PowerMeter ()
        {            
        }

        public string InitPowerMeter ()
        {
            string ex = "";
            try
            {
                pm = new PM100D(this.deviceID, false, false);                
                return ex;
            }
            catch(BadImageFormatException bie)
            {
                Console.WriteLine(bie.Message);
                return bie.Message;
            }
            catch(NullReferenceException nre)
            {
                Console.WriteLine(nre.Message);
                return nre.Message;
            }
            catch(ExternalException ee)
            {
                Console.WriteLine(ee.Message);
                return ee.Message;
            }
        }

        public int GetPowerMeasurement (out double power)
        {
            if(pm != null)
            {
                int code = pm.measPower(out power);
                power = Math.Round(power, 8);
                PowerValue = power;
                //LastTime = DateTime.Now;
                return code;
            }             
            else
            {                
                power = 0;
                PowerValue = 0;
                return -1;
            }            
        }

        public void SetWavelenght (double wavelength)
        {
            if(pm!=null)
                pm.setWavelength(wavelength);
        }

        #region Properties

        /// <summary>
            /// The <see cref="SerialNumber" /> property's name.
            /// </summary>
        public const string SerialNumberPropertyName = "SerialNumber";

        private string serialNumber = "";

        /// <summary>
        /// Sets and gets the SerialNumber property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string SerialNumber
        {
            get
            {
                return serialNumber;
            }
            set
            {
                Set(SerialNumberPropertyName, ref serialNumber, value);
            }
        }

        /// <summary>
        /// The <see cref="DeviceID" /> property's name.
        /// </summary>
        public const string DeviceIDPropertyName = "DeviceID";

        private string deviceID = null;

        /// <summary>
        /// Sets and gets the DeviceID property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string DeviceID
        {
            get
            {
                return deviceID;
            }
            set
            {
                Set(DeviceIDPropertyName, ref deviceID, value);
            }
        }


        /// <summary>
        /// The <see cref="PowerValue" /> property's name.
        /// </summary>
        public const string PowerValuePropertyName = "PowerValue";

        private double powerValue = 0.0;

        /// <summary>
        /// Sets and gets the PowerValue property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public double PowerValue
        {
            get
            {
                return powerValue;
            }
            set
            {
                Set(PowerValuePropertyName, ref powerValue, value);
            }
        }

        /// <summary>
        /// The <see cref="LastTime" /> property's name.
        /// </summary>
        public const string LastTimePropertyName = "LastTime";

        private DateTime lastTime = DateTime.Now;

        /// <summary>
        /// Sets and gets the LastTime property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public DateTime LastTime
        {
            get
            {
                return lastTime;
            }
            set
            {
                Set(LastTimePropertyName, ref lastTime, value);
            }
        }

        #endregion Properties
    }
 
}
