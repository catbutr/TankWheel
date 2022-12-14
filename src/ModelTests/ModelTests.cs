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
        /// Проверка корректного присвоения и получения CapThickness
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckCapThickness(double value)
        {
            var localValues = _wheelValues;
            localValues.CapThickness = value;
            var actual = localValues.CapThickness;
            Assert.AreEqual(value,actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения CapNumberOfHoles
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckCapNumberOfHoles(int value)
        {
            var localValues = _wheelValues;
            localValues.CapNumberOfHoles = value;
            var actual = localValues.CapNumberOfHoles;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения FoundationDiameter
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckFoundationDiameter(double value)
        {
            var localValues = _wheelValues;
            localValues.FoundationDiameter = value;
            var actual = localValues.FoundationDiameter;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения FoundationNumberOfHoles
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckFoundationNumberOfHoles(int value)
        {
            var localValues = _wheelValues;
            localValues.FoundationNumberOfHoles = value;
            var actual = localValues.FoundationNumberOfHoles;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения FoundationThickness
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        public void CheckFoundationThickness(double value)
        {
            var localValues = _wheelValues;
            localValues.FoundationThickness = value;
            var actual = localValues.FoundationThickness;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения RimThickness
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckRimThickness(double value)
        {
            var localValues = _wheelValues;
            localValues.RimThickness = value;
            var actual = localValues.RimThickness;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения WallHeight
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckWallHeight(double value)
        {
            var localValues = _wheelValues;
            localValues.WallHeight = value;
            var actual = localValues.WallHeight;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения WheelDiameter
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckWheelDiameter(double value)
        {
            var localValues = _wheelValues;
            localValues.WheelDiameter = value;
            var actual = localValues.WheelDiameter;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения DiskDistance
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckDiskDistance(double value)
        {
            var localValues = _wheelValues;
            localValues.DiskDistance = value;
            var actual = localValues.DiskDistance;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка корректного присвоения и получения DiskQuantity
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(-10)]
        [DataRow(10)]
        public void CheckDiskQuantity(int value)
        {
            var localValues = _wheelValues;
            localValues.DiskQuantity = value;
            var actual = localValues.DiskQuantity;
            Assert.AreEqual(value, actual, $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для WheelDiameter 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(750, "")]
        [DataRow(250, "Значение WheelDiameter не задано корректно")]
        public void CheckErrorWheelDiameter(double value, string exprected)
        {
            _wheelValues.WheelDiameter = value;
            Assert.AreEqual(exprected, _wheelValues["WheelDiameter"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для WallHeight 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(100, 100, "")]
        [DataRow(100, 250, "Значение WallHeight не задано корректно")]
        public void CheckErrorWallHeight(double prerequestValues, double value, string exprected)
        {
            _wheelValues.RimThickness = prerequestValues;
            _wheelValues.WallHeight = value;
            Assert.AreEqual(exprected, _wheelValues["WallHeight"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для RimThickness 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(700, 100, "")]
        [DataRow(700, 250, "Значение RimThickness не задано корректно")]
        public void CheckErrorRimThickness(double prerequestValues, double value, string exprected)
        {
            _wheelValues.WheelDiameter = prerequestValues;
            _wheelValues.RimThickness = value;
            Assert.AreEqual(exprected, _wheelValues["RimThickness"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для FoundationThickness 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(45, "")]
        [DataRow(250, "Значение FoundationThickness не задано корректно")]
        public void CheckErrorFoundationThickness(double value, string exprected)
        {
            _wheelValues.FoundationThickness = value;
            Assert.AreEqual(exprected, _wheelValues["FoundationThickness"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для FoundationNumberOfHoles 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(16, "")]
        [DataRow(100, "Значение FoundationNumberOfHoles не задано корректно")]
        public void CheckErrorFoundationNumberOfHoles(int value, string exprected)
        {
            _wheelValues.FoundationNumberOfHoles = value;
            Assert.AreEqual(exprected, _wheelValues["FoundationNumberOfHoles"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для FoundationDiameter 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(200, "")]
        [DataRow(100, "Значение FoundationDiameter не задано корректно")]
        public void CheckErrorFoundationDiameter(double value, string exprected)
        {
            _wheelValues.FoundationDiameter = value;
            Assert.AreEqual(exprected, _wheelValues["FoundationDiameter"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для CapThickness 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(35, "")]
        [DataRow(245, "Значение CapThickness не задано корректно")]
        public void CheckErrorCapThickness(double value, string exprected)
        {
            _wheelValues.CapThickness = value;
            Assert.AreEqual(exprected, _wheelValues["CapThickness"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для CapNumberOfHoles 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(12, "")]
        [DataRow(245, "Значение CapNumberOfHoles не задано корректно")]
        public void CheckErrorCapNumberOfHoles(int value, string exprected)
        {
            _wheelValues.CapNumberOfHoles = value;
            Assert.AreEqual(exprected, _wheelValues["CapNumberOfHoles"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для DiskDistance 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(30, "")]
        [DataRow(120, "Значение DiskDistance не задано корректно")]
        public void CheckErrorDiskDistance(int value, string exprected)
        {
            _wheelValues.DiskDistance = value;
            Assert.AreEqual(exprected, _wheelValues["DiskDistance"], $"value is not set up properly");
        }

        /// <summary>
        /// Проверка error для DiskDistance 
        /// </summary>
        /// <param name="value"></param>
        [DataTestMethod]
        [DataRow(2, "")]
        [DataRow(12, "Значение DiskQuantity не задано корректно")]
        public void CheckErrorDiskQuantity(int value, string exprected)
        {
            _wheelValues.DiskQuantity = value;
            Assert.AreEqual(exprected, _wheelValues["DiskQuantity"], $"value is not set up properly");
        }
    }
}
