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
    public class MainViewModel : ViewModelBase, INotifyPropertyChanged
    {
        private readonly WheelBuilder _builder;

        /// <summary>
        /// Включен ли текстбокс для RimThickness 
        /// </summary>
        private bool isRimThicknessTextBoxEnabled = true;

        /// <summary>
        /// Включен ли текстбокс для WallHeight
        /// </summary>
        private bool isWallHeightTextBoxEnabled = true;

        private readonly IMessageBoxService _messageBoxService;

        /// <summary>
        /// Характеристики катка
        /// </summary>
        private WheelValues _wheelValues;

        /// <summary>
        /// Команда создания катка.
        /// </summary>
        public RelayCommand BuildCommand { get; }

        /// <summary>
        /// Команда очистки значений.
        /// </summary>
        public RelayCommand ClearCommand { get; }

        ///<inheritdoc/>
        public new event PropertyChangedEventHandler PropertyChanged;

        ///<inheritdoc/>
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Конструктор.
        /// </summary>
        public MainViewModel(IMessageBoxService messageBoxService)
        {
            WheelValues = new WheelValues();
            _builder = new WheelBuilder(WheelValues);
            SetWheelValues();
            this.BuildCommand = new RelayCommand(CreateWheel);
            this.ClearCommand = new RelayCommand(ClearTextbox);
            _messageBoxService = messageBoxService;
        }

        /// <summary>
        /// Получение характеристик катка
        /// </summary>
        public WheelValues WheelValues
        {
            get => _wheelValues;
            set
            {
                _wheelValues = value;
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Управление свойством включения textbox для RimThickness
        /// </summary>
        public bool isRimThicknessEnabled
        {
            get =>
                isRimThicknessTextBoxEnabled;
            set
            {
                if (isRimThicknessTextBoxEnabled == value)
                {
                    return;
                }
                isRimThicknessTextBoxEnabled = value;
                RaisePropertyChanged("isRimThicknessEnabled");
            }
        }

        /// <summary>
        /// Управление свойством включения textbox для WallHeight
        /// </summary>
        public bool isWallHeightEnabled
        {
            get =>
                isWallHeightTextBoxEnabled;
            set
            {
                if (isWallHeightTextBoxEnabled == value)
                {
                    return;
                }
                isWallHeightTextBoxEnabled = value;
                RaisePropertyChanged("isWallHeighеEnabled");
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

        /// <summary>
        /// Очистка TextBox
        /// </summary>
        private void ClearTextbox()
        {
            if (_messageBoxService.Show("Очистить значения?",
            "Очистить значения",
            MessageButtons.OkCancel, MessageIcon.Warning))
            {
                WheelValues newValues = new WheelValues();
                newValues.FoundationNumberOfHoles = 0;
                newValues.CapNumberOfHoles = 0;
                newValues.WheelDiameter = 0;
                newValues.RimThickness = 0;
                newValues.WallHeight = 0;
                newValues.FoundationDiameter = 0;
                newValues.FoundationThickness = 0;
                newValues.CapThickness = 0;
                WheelValues = newValues;
                NotifyPropertyChanged();
            }
        }

    }
}
