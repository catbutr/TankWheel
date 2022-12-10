using Microsoft.VisualStudio.TestTools.UnitTesting;
using TankWheel.Model;
using System;


namespace UnitTests
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

        /// <summary>
        /// Проверка корректного присвоения и получения 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow("Loren Ipsum")]
        public void CheckError(string value)
        {
            var localValues = _wheelValues;
            localValues.Error = value;
            var actual = localValues.Error;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для WheelDiameter 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(750, null)]
        public void CheckErrorWheelDiameter(double value, string exprected)
        {
            var localValues = _wheelValues;
            localValues.WheelDiameter = value;
            var actual = localValues.Error;
            Assert.AreEqual(exprected, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для WallHeight 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(100, null)]
        public void CheckErrorWallHeight(double value, string exprected)
        {
            var localValues = _wheelValues;
            localValues.WallHeight = value;
            var actual = localValues.Error;
            Assert.AreEqual(exprected, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для RimThickness 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(80, null)]
        public void CheckErrorRimThickness(double value, string exprected)
        {
            var localValues = _wheelValues;
            localValues.RimThickness = value;
            var actual = localValues.Error;
            Assert.AreEqual(exprected, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для FoundationThickness 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(45, null)]
        public void CheckErrorFoundationThickness(double value, string exprected)
        {
            var localValues = _wheelValues;
            localValues.FoundationThickness = value;
            var actual = localValues.Error;
            Assert.AreEqual(exprected, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для FoundationNumberOfHoles 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(16, null)]
        public void CheckErrorFoundationNumberOfHoles(int value, string exprected)
        {
            var localValues = _wheelValues;
            localValues.FoundationNumberOfHoles = value;
            var actual = localValues.Error;
            Assert.AreEqual(exprected, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для FoundationDiameter 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(200, null)]
        public void CheckErrorFoundationDiameter(double value, string exprected)
        {
            var localValues = _wheelValues;
            localValues.FoundationDiameter = value;
            var actual = localValues.Error;
            Assert.AreEqual(exprected, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для CapThickness 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(35, null)]
        public void CheckErrorCapThickness(double value, string exprected)
        {
            var localValues = _wheelValues;
            localValues.CapThickness = value;
            var actual = localValues.Error;
            Assert.AreEqual(exprected, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для CapNumberOfHoles 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(12, null)]
        public void CheckErrorCapNumberOfHoles(int value, string exprected)
        {
            var localValues = _wheelValues;
            localValues.CapNumberOfHoles = value;
            var actual = localValues.Error;
            Assert.AreEqual(exprected, actual, $"value is not set up properly");
        }
    }
}
