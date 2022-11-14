using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankWheel.Model
{
    public static class Validator
    {
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
    }
}
