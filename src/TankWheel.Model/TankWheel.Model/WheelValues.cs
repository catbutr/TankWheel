using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CommunityToolkit;

namespace TankWheel.Model
{
    public class WheelValues : IDataErrorInfo
    {
        /// <summary>
        /// Количество отверстий на крышке
        /// /// </summary>
        private int _capNumberOfHoles;

        /// <summary>
        /// Толщина крышки диска 
        /// </summary>
        private double _capThickness;

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


        public static Boolean CompareBetween(double minValue, double maxValue, double inputValue)
        {
            if (inputValue >= minValue && inputValue <= maxValue)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Boolean CheckIfEven(double inputValue)
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
        /// Возвращает или задаёт количество отверстий на крышке
        /// </summary>
        public int CapNumberOfHoles
        {
            get
            {
                return _capNumberOfHoles;
            }
            set
            {
                _capNumberOfHoles = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт толщину крышки диска
        /// </summary>
        public double CapThickness
        {
            get
            {
                return _capThickness;
            }
            set
            {
                _capThickness = value;
            }
        }

        public double FoundationThickness
        {
            get
            {
                return _foundationThickness;
            }
            set
            {
                _foundationThickness = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт диаметр основания соединения
        /// </summary>
        public double FoundationDiameter
        {
            get
            {
                return _foundationDiameter;
            }
            set
            {
                _foundationDiameter = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт количество отверстий в основании соединения
        /// </summary>
        public int FoundationNumberOfHoles
        {
            get
            {
                return _foundationNumberOfHoles;
            }
            set
            {
                _foundationNumberOfHoles = value;
            }
        }

        /// <summary>
        /// Возвращает или задаёт толщину обода
        /// </summary>
        public double RimThickness
        {
            get
            {
                return _rimThickness;
            }
            set
            {
                _rimThickness = value;
            }
        }

        public double WallHeight
        {
            get
            {
                return _wallHeight;
            }
            set
            {
                _wallHeight = value;
            }
        }

        public double WheelDiameter
        {
            get
            {
                return _wheelDiameter;
            }
            set
            {
                _wheelDiameter = value;
            }
        }

        public string this[string columnName]
        {
            get
            {
                string error = String.Empty;
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
                            error = "Кол-во отверстий должно быть в диапозоне 6-12";
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
                            error = "Кол-во отверстий должно быть в диапозоне 6-16";
                        }
                        break;
                    //D2 Диаметр основания соединения
                    case "FoundationDiameter":
                        if (CompareBetween(200, 350, FoundationDiameter) == false)
                        {
                            error = "Диаметер основания соединения должно быть в диапозоне 200-350мм";
                        }
                        break;
                    //D1 Диаметр катка вместе с ободом   
                    case "WheelDiameter":
                        if (CompareBetween(600, 750, WheelDiameter) == false)
                        {
                            error = "Диаметер катка должен быть в диапозоне 600-750мм";
                        }
                        break;
                    //W1 Толщина основания соединения 
                    case "FoundationThickness":
                        if (CompareBetween(30, 70, FoundationThickness) == false)
                        {
                            error = "Толщина основания соединения  должен быть в диапозоне 600-750мм";
                        }
                        break;
                    //W2 Толщина крышки диска 
                    case "CapThickness":
                        if (CompareBetween(25, 50, CapThickness) == false)
                        {
                            error = "Толщина крышки  должен быть в диапозоне 600-750мм";
                        }
                        break;
                    //W3 Толщина обода катка 
                    case "RimThickness":
                        if (CompareBetween(600, 700, WheelDiameter) == true)
                        {
                            if (CompareBetween(70, 100, RimThickness) == false)
                            {
                                error = "Толщина крышки  должен быть в диапозоне 600-750мм";
                            }
                        }
                        else
                        {
                            if (CompareBetween(101, 150, RimThickness) == false)
                            {
                                error = "Толщина крышки  должен быть в диапозоне 600-750мм";
                            }
                        }
                        break;
                    //W4 Длина внутренних стенок
                    case "WallHeight":
                        if (CompareBetween(RimThickness - 20, RimThickness + 20, WallHeight) == false)
                        {
                            error = "Толщина крышки  должен быть в диапозоне 600-750мм";
                        }
                        break;
                }
                return error;
            }
        }
        public string Error
        {
            get { throw new NotImplementedException(); }
        }

    }
}
