using Microsoft.VisualStudio.TestTools.UnitTesting;
using TankWheel.Model;
using System;


namespace ModelTests
{
    [TestClass]
    public class ModelTests
    {
        private readonly WheelValues _wheelValues = new WheelValues();

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckCapThickness(double value)
        {
            var localValues = _wheelValues;
            var expected = value;
            localValues.CapThickness = value;
            var actual = localValues.CapThickness;
            Assert.AreEqual(value,actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckCapNumberOfHoles(int value)
        {
            var localValues = _wheelValues;
            var expected = value;
            localValues.CapNumberOfHoles = value;
            var actual = localValues.CapNumberOfHoles;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckFoundationDiameter(double value)
        {
            var localValues = _wheelValues;
            var expected = value;
            localValues.FoundationDiameter = value;
            var actual = localValues.FoundationDiameter;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckFoundationNumberOfHoles(int value)
        {
            var localValues = _wheelValues;
            var expected = value;
            localValues.FoundationNumberOfHoles = value;
            var actual = localValues.FoundationNumberOfHoles;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        public void CheckFoundationThickness(double value)
        {
            var localValues = _wheelValues;
            var expected = value;
            localValues.FoundationThickness = value;
            var actual = localValues.FoundationThickness;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckRimThickness(double value)
        {
            var localValues = _wheelValues;
            var expected = value;
            localValues.RimThickness = value;
            var actual = localValues.RimThickness;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckWallHeight(double value)
        {
            var localValues = _wheelValues;
            var expected = value;
            localValues.WallHeight = value;
            var actual = localValues.WallHeight;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckWheelDiameter(double value)
        {
            var localValues = _wheelValues;
            var expected = value;
            localValues.WheelDiameter = value;
            var actual = localValues.WheelDiameter;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }
    }
}
