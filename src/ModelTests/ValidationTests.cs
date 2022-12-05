using Microsoft.VisualStudio.TestTools.UnitTesting;
using TankWheel.Model;
using System;

namespace ModelTests
{
    [TestClass]
    public class ValidationTests
    {
        /// <summary>
        /// Тестирование метода проверки нахождения числа на интервале
        /// </summary>
        /// <param name="min">Минимальное значение интервала</param>
        /// <param name="max">Максимальное значение интервала</param>
        /// <param name="input">Проверяемое число</param>
        /// <param name="expected">Предполагаемый исход</param>
        [DataTestMethod]
        [DataRow(400, 500, 450, true)]
        [DataRow(200, 100, 120, false)]
        [DataRow(300, 350, 360, false)]
        public void CompareBetweenTest(double min, double max, double input, bool expected)
        {
            WheelValues _wheelValues = new WheelValues();
            bool result = _wheelValues.CompareBetween(min, max, input);
            Assert.AreEqual(result,expected);
        }

        /// <summary>
        /// Тестирование метода проверки на четность 
        /// </summary>
        /// <param name="a"></param>
        /// <param name="expected"></param>
        [DataTestMethod]
        [DataRow(2, true)]
        [DataRow(137, false)]
        [DataRow(300, true)]
        public void CheckIfEvenTest(double a, bool expected)
        {
            WheelValues _wheelValues = new WheelValues();
            bool result = _wheelValues.CheckIfEven(a);
            Assert.AreEqual(result, expected);
        }
    }
}
