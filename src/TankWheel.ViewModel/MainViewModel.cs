using System;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using Services;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using TankWheel.Model;
using Builder;
using Services;
using InventorAPI;

namespace TankWheel.ViewModel
{
    // TODO: xml
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Параметры катка
        /// </summary>
        private WheelValues _wheelValues;

        private readonly WheelBuilder _builder;

        /// <summary>
        /// Сервис окна сообщения.
        /// </summary>
        private readonly IMessageBoxService _messageBoxService;

        /// <summary>
        /// Команда создания забора.
        /// </summary>
        public RelayCommand BuildCommand { get; }
        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel()
        {
            _wheelValues = new WheelValues();
             _builder = new WheelBuilder(_wheelValues);
            SetWheelValues();
            this.BuildCommand = new RelayCommand(CreateWheel);
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
        /// Стандартные значения
        /// </summary>
        private void SetWheelValues()
        {
            _wheelValues.FoundationNumberOfHoles = 16;
            _wheelValues.CapNumberOfHoles = 12;
            _wheelValues.WheelDiameter = 700;
            _wheelValues.RimThickness = 100;
            _wheelValues.WallHeight = 80;
            _wheelValues.FoundationDiameter = 200;
            _wheelValues.FoundationThickness = 44;
            _wheelValues.CapThickness = 44;
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
