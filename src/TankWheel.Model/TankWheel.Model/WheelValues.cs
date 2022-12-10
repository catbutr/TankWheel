﻿using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TankWheel.Model
{
    public class WheelValues : IDataErrorInfo
    {
        /// <summary>
        /// Возвращает или задаёт количество отверстий на крышке
        /// </summary>
        public int CapNumberOfHoles { get; set; }

        /// <summary>
        /// Возвращает или задаёт толщину крышки диска
        /// </summary>
        public double CapThickness { get; set; }

        /// <summary>
        /// Возвращает или задаёт толщину основания соединения
        /// </summary>
        public double FoundationThickness { get; set; }

        /// <summary>
        /// Возвращает или задаёт диаметр основания соединения
        /// </summary>
        public double FoundationDiameter { get; set; }

        /// <summary>
        /// Возвращает или задаёт количество отверстий в основании соединения
        /// </summary>
        public int FoundationNumberOfHoles { get; set; }

        /// <summary>
        /// Возвращает или задаёт толщину обода
        /// </summary>
        public double RimThickness { get; set; }

        /// <summary>
        /// Возвращает или задаёт высоту стенок
        /// </summary>
        public double WallHeight { get; set; }

        /// <summary>
        /// Возвращает или задаёт диаметр катка
        /// </summary>
        public double WheelDiameter { get; set; }


        /// <summary>
        /// Валидация данных
        /// </summary>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public string this[string columnName]
        {
            get
            {
                Error = string.Empty;
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
                            Error = "Значение CapNumberOfHoles не задано корректно";
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
                            Error = "Значение FoundationNumberOfHoles не задано корректно";
                        }
                        break;
                    //D2 Диаметр основания соединения
                    case "FoundationDiameter":
                        if (CompareBetween(200, 350, FoundationDiameter) == false)
                        {
                            Error = "Значение FoundationDiameter не задано корректно";
                        }
                        break;
                    //D1 Диаметр катка вместе с ободом   
                    case "WheelDiameter":
                        if (CompareBetween(600, 750, WheelDiameter) == false)
                        {
                            Error = "Значение WheelDiameter не задано корректно";
                        }
                        break;
                    //W1 Толщина основания соединения 
                    case "FoundationThickness":
                        if (CompareBetween(30, 70, FoundationThickness) == false)
                        {
                            Error = "Значение FoundationThickness не задано корректно";
                        }
                        break;
                    //W2 Толщина крышки диска 
                    case "CapThickness":
                        if (CompareBetween(25, 50, CapThickness) == false)
                        {
                            Error = "Значение CapThickness не задано корректно";
                        }
                        break;
                    //W3 Толщина обода катка 
                    case "RimThickness":
                        if (CompareBetween(600, 700, WheelDiameter) == true)
                        {
                            if (CompareBetween(70, 100, RimThickness) == false)
                            {
                                Error = "Значение RimThickness не задано корректно";
                            }
                        }
                        else
                        {
                            if (CompareBetween(101, 150, RimThickness) == false)
                            {
                                Error = "Значение RimThickness не задано корректно";
                            }
                        }
                        break;
                    //W4 Длина внутренних стенок
                    case "WallHeight":
                        if (CompareBetween(RimThickness - 20, RimThickness + 20, WallHeight) == false)
                        {
                            Error = "Значение WallHeight не задано корректно";
                        }
                        break;
                }
                return Error;
            }
        }

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

        /// <summary>
        /// Является ли число чётным
        /// </summary>
        /// <param name="inputValue">Проверяемое число</param>
        /// <returns></returns>
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

        public string Error { get; set; }

    }
}
