using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Globalization;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Windows.Controls;
using TankWheel.Model;
using Builder;
using Services;
using InventorAPI;

namespace TankWheel.ViewModel
{
    // TODO: xml
    public class MainViewModel : ViewModelBase
    {
        private readonly WheelBuilder _builder;

        private bool isW3TextBoxEnabled = true;
        private bool isW4TextBoxEnabled = true;

        /// <summary>
        /// Команда создания катка.
        /// </summary>
        public RelayCommand BuildCommand { get; }

        /// <summary>
        /// Команда очистки значений.
        /// </summary>
        public RelayCommand ClearCommand { get; }


        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {
            WheelValues = new WheelValues();
            _builder = new WheelBuilder(WheelValues);
            SetWheelValues();
            this.BuildCommand = new RelayCommand(CreateWheel);
            this.ClearCommand = new RelayCommand(SetWheelValues);
        }

        /// <summary>
        /// Получение характеристик катка
        /// </summary>
        public WheelValues WheelValues {
            // TODO: сделать autoproperty в свойствах, где нет особенной логики в get set (resharper сам подскажет)
            // public WheelValues WheelValues { get; set; }
            get; set; }

        public bool isW3Enabled
        {
            get =>
                isW3TextBoxEnabled;
            set
            {
                if (isW3TextBoxEnabled == value)
                {
                    return;
                }
                isW3TextBoxEnabled = value;
                RaisePropertyChanged("isW3Enabled");
            }
        }

        public bool isW4Enabled
        {
            get =>
                isW4TextBoxEnabled;
            set
            {
                if (isW4TextBoxEnabled == value)
                {
                    return;
                }
                isW4TextBoxEnabled = value;
                RaisePropertyChanged("isW4Enabled");
            }
        }

        /// <summary>
        /// Стандартные значения
        /// </summary>
        private void SetWheelValues()
        {
            WheelValues.FoundationNumberOfHoles = 16;
            WheelValues.CapNumberOfHoles = 12;
            WheelValues.WheelDiameter = 700;
            WheelValues.RimThickness = 100;
            WheelValues.WallHeight = 80;
            WheelValues.FoundationDiameter = 200;
            WheelValues.FoundationThickness = 44;
            WheelValues.CapThickness = 44;
        }
        /// <summary>
        /// Создание катка
        /// </summary>
        public void CreateWheel()
        {
            _builder.BuildWheel(WheelValues);
        }

    }
}
