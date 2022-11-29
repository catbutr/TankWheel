using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Services;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using TankWheel.Model;
using Builder;
using InventorAPI;

namespace TankWheel.ViewModel
{
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Параметры катка
        /// </summary>
        private WheelValues _wheelValues;

        private WheelBuilder _builder;

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {
            _wheelValues = new WheelValues();
             _builder = new WheelBuilder(_wheelValues);
        }

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public WheelValues WheelValues
        {
            get
            {
                return _wheelValues;
            }
            set
            {
                _wheelValues = value;
            }
        }

        public void CreateWheel()
        {
            _builder.BuildWheel(_wheelValues);
        }
    }
}
