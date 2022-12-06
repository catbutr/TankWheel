using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight;

namespace TankWheel.Model
{
    public class WheelValues : IDataErrorInfo
    {
        /// <summary>
        /// Находится ли число в интервале
        /// </summary>
        /// <param name="minValue">Нижний предел интервала</param>
        /// <param name="maxValue">Верхний предел интервала</param>
        /// <param name="inputValue">Проверяемое число</param>
        /// <returns></returns>
        public Boolean CompareBetween(double minValue, double maxValue, double inputValue)
        {
            if (minValue > maxValue)
            {
                double switchValue = minValue;
                maxValue = minValue;
                minValue = switchValue;
            }

            if (inputValue >= minValue && inputValue <= maxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Boolean CheckIfEven(double inputValue)
        {
            if (inputValue % 2 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Количество отверстий на крышке
        /// /// </summary>
        private int _capNumberOfHoles = 12;

        /// <summary>
        /// Толщина крышки диска 
        /// </summary>
        private double _capThickness = 25;

        /// <summary>
        /// Диаметр основания соединения 
        /// </summary>
        private double _foundationDiameter;

        /// <summary>
        /// Толщина основания соединения 
        /// </summary>
        private double _foundationThickness;

        /// <summary>
        /// Количество отверстий на основании соединения
        /// </summary>
        private int _foundationNumberOfHoles;

        /// <summary>
        /// Толщина обода катка 
        /// </summary>
        private double _rimThickness;

        /// <summary>
        /// Длина внутренних стенок
        /// </summary>
        private double _wallHeight;

        /// <summary>
        /// Диаметр катка вместе с ободом 
        /// </summary>
        private double _wheelDiameter;

        /// <summary>
        /// Возвращает или задаёт количество отверстий на крышке
        /// </summary>
        [Range(6,12)]
        [DefaultValue(12)]
        public int CapNumberOfHoles
        {
            get => _capNumberOfHoles;
            set => _capNumberOfHoles = value;
        }

        /// <summary>
        /// Возвращает или задаёт толщину крышки диска
        /// </summary>
        [Range(25.0,50.0)]
        [DefaultValue(25.0)]
        public double CapThickness
        {
            get => _capThickness;
            set => _capThickness = value;
        }

        /// <summary>
        /// Возвращает или задаёт толщину основания соединения
        /// </summary>
        [Range(30.0,70.0)]
        [DefaultValue(45.0)]
        public double FoundationThickness
        {
            get => _foundationThickness;
            set => _foundationThickness = value;
        }

        /// <summary>
        /// Возвращает или задаёт диаметр основания соединения
        /// </summary>
        [Range(200.0,350.0)]
        [DefaultValue(200.0)]
        public double FoundationDiameter
        {
            get => _foundationDiameter;
            set => _foundationDiameter = value;
        }

        /// <summary>
        /// Возвращает или задаёт количество отверстий в основании соединения
        /// </summary>
        [Range(6, 16)]
        [DefaultValue(16)]
        public int FoundationNumberOfHoles
        {
            get => _foundationNumberOfHoles;
            set => _foundationNumberOfHoles = value;
        }

        /// <summary>
        /// Возвращает или задаёт толщину обода
        /// </summary>
        [Range(70.0, 150.0)]
        [DefaultValue(100.0)]
        public double RimThickness
        {
            get => _rimThickness;
            set => _rimThickness = value;
        }

        /// <summary>
        /// Возвращает или задаёт высоту стенок
        /// </summary>
        [Range(50.0, 170.0)]
        [DefaultValue(120.0)]
        public double WallHeight
        {
            get => _wallHeight;
            set => _wallHeight = value;
        }

        /// <summary>
        /// Возвращает или задаёт диаметр катка
        /// </summary>
        [Range(600.0, 750.0)]
        [DefaultValue(600.0)]
        public double WheelDiameter
        {
            get => _wheelDiameter;
            set => _wheelDiameter = value;
        }


        /// <summary>
        /// Валидация данных
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                string error = string.Empty;
                switch (columnName)
                {
                    //N2
                    case "CapNumberOfHoles":
                        if (CompareBetween(6, 12, CapNumberOfHoles) == true && CheckIfEven(CapNumberOfHoles) == true )
                        {
                            break;
                        }
                        else
                        {
                            error = "Значение не задано корректно";
                        }
                        break;
                    //N1 
                    case "FoundationNumberOfHoles":
                        if (CompareBetween(6, 16, FoundationNumberOfHoles) == true && CheckIfEven(FoundationNumberOfHoles) == true)
                        {
                            break;
                        }
                        else
                        {
                            error = "Значение не задано корректно";
                        }
                        break;
                    //D2 Диаметр основания соединения
                    case "FoundationDiameter":
                        if (CompareBetween(200, 350, FoundationDiameter) == false)
                        {
                            error = "Значение не задано корректно";
                        }
                        break;
                    //D1 Диаметр катка вместе с ободом   
                    case "WheelDiameter":
                        if (CompareBetween(600, 750, WheelDiameter) == false)
                        {
                            error = "Значение не задано корректно";
                        }
                        break;
                    //W1 Толщина основания соединения 
                    case "FoundationThickness":
                        if (CompareBetween(30, 70, FoundationThickness) == false)
                        {
                            error = "ТоЗначение не задано корректно";
                        }
                        break;
                    //W2 Толщина крышки диска 
                    case "CapThickness":
                        if (CompareBetween(25, 50, CapThickness) == false)
                        {
                            error = "Значение не задано корректно";
                        }
                        break;
                    //W3 Толщина обода катка 
                    case "RimThickness":
                        if (CompareBetween(600, 700, WheelDiameter) == true)
                        {
                            if (CompareBetween(70, 100, RimThickness) == false)
                            {
                                error = "Значение не задано корректно";
                            }
                        }
                        else
                        {
                            if (CompareBetween(101, 150, RimThickness) == false)
                            {
                                error = "Значение не задано корректно";
                            }
                        }
                        break;
                    //W4 Длина внутренних стенок
                    case "WallHeight":
                        if (CompareBetween(RimThickness - 20, RimThickness + 20, WallHeight) == false)
                        {
                            error = "Значение не задано корректно";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get {
                throw new NotImplementedException();
            }
        }

    }
}
