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
    // TODO: xml
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        /// <summary>
        /// Параметры катка
        /// </summary>
        private WheelValues _wheelValues;

        private readonly WheelBuilder _builder;

        public new event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {
            _wheelValues = new WheelValues();
             _builder = new WheelBuilder(_wheelValues);
        }

        /// <summary>
        /// Получение характеристик катка
        /// </summary>
        public WheelValues WheelValues
        {
            // TODO: сделать autoproperty в свойствах, где нет особенной логики в get set (resharper сам подскажет)
            // public WheelValues WheelValues { get; set; }
            get =>
                _wheelValues;
            set =>
                _wheelValues = value;
        }

        /// <summary>
        /// Создание катка
        /// </summary>
        public void CreateWheel()
        {
            _builder.BuildWheel(_wheelValues);
        }
    }
}
