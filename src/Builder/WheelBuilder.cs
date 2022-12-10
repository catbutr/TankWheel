using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;
using TankWheel.Model;
using InventorAPI;

namespace Builder
{
	public class WheelBuilder:IBuildService
	{
		/// <summary>
		/// Экземпляр класса для работы с API.
		/// </summary>
		public InventorConnector _apiService { get; set; }

		/// <summary>
		/// Параметры катка.
		/// </summary>
		private WheelValues _wheelValues;

		/// <summary>
		/// Конструктор.
		/// </summary>
		public WheelBuilder(WheelValues wheelValues)
		{
			_wheelValues = wheelValues;
		}

		/// <inheritdoc/>
		public void BuildWheel(WheelValues wheelValues)
		{
			_wheelValues = wheelValues;
			_apiService = new InventorConnector();
			_apiService.CreateDocument();
			BuildRightWheel();
			BuildLeftWheel();
		}

		/// <summary>
		/// Создание правого катка
		/// </summary>
		private void BuildRightWheel()
		{
			///Радиусы
			var mainRadius = _wheelValues.WheelDiameter / 2;
			var innerRadius = (_wheelValues.WheelDiameter / 2) - 40;
			var foundationRadius = _wheelValues.FoundationDiameter/2;
			var CapRadius = (_wheelValues.FoundationDiameter - 50) / 2;
			///Выдавливания
			var mainExtrudeValue = _wheelValues.RimThickness;
			var innerExtrudeValue = _wheelValues.RimThickness - _wheelValues.WallHeight;
			var foundationExtrudeValue = _wheelValues.FoundationThickness + innerExtrudeValue;
			var captExtrudeValue = _wheelValues.CapThickness + foundationExtrudeValue;
			///Точки
			var mainCentre = _apiService.CreatePoint(0, 0);
			///Кол-во отверстий
			var foundationHoles = _wheelValues.FoundationNumberOfHoles;
			var capHoles = _wheelValues.CapNumberOfHoles;
			///Строительство
			BuildRing(0, mainCentre, mainRadius, mainExtrudeValue);
			BuildClosedCircle(0, mainCentre, innerRadius, innerExtrudeValue);
			BuildClosedCircle(0, mainCentre, foundationRadius, foundationExtrudeValue);
			BuildClosedCircle(0, mainCentre, CapRadius, captExtrudeValue);
			BuildCircularPatternByHand(0, mainCentre, 5, foundationRadius, foundationHoles, 90);
			BuildCircularPatternByHand(0, mainCentre, 5, CapRadius, capHoles, 90);
			BuildClosedCircle(0, mainCentre, CapRadius - 25, captExtrudeValue + 5);
			BuildClosedCircle(0, mainCentre, innerRadius, -30);
		}

		/// <summary>
		/// Создание левой части катка
		/// </summary>
		private void BuildLeftWheel()
		{
			///Радиусы
			var mainRadius = _wheelValues.WheelDiameter / 2;
			var innerRadius = (_wheelValues.WheelDiameter / 2) - 40;
			var foundationRadius = _wheelValues.FoundationDiameter/2;
			var CapRadius = (_wheelValues.FoundationDiameter - 50) / 2;
			///Выдавливания
			var mainExtrudeValue = _wheelValues.RimThickness;
			var innerExtrudeValue = _wheelValues.RimThickness - _wheelValues.WallHeight;
			var foundationExtrudeValue = _wheelValues.FoundationThickness + innerExtrudeValue;
			var captExtrudeValue = _wheelValues.CapThickness + foundationExtrudeValue;
			///Точки
			var mainCentre = _apiService.CreatePoint(0, 0);
			///Кол-во отверстий
			var foundationHoles = _wheelValues.FoundationNumberOfHoles;
			var capHoles = _wheelValues.CapNumberOfHoles;
			//Строительство
			BuildRing(-30, mainCentre, mainRadius, -mainExtrudeValue);
			BuildClosedCircle(-30, mainCentre, innerRadius, -innerExtrudeValue);
			BuildClosedCircle(-30, mainCentre, foundationRadius, -foundationExtrudeValue);
			BuildClosedCircle(-30, mainCentre, CapRadius, -captExtrudeValue);
			BuildCircularPatternByHand(-30, mainCentre, 5, foundationRadius, foundationHoles, -90);
			BuildCircularPatternByHand(-30, mainCentre, 5, CapRadius, capHoles, -90);
			BuildClosedCircle(-30, mainCentre, CapRadius - 25, -captExtrudeValue - 5);
		}

		/// <summary>
		/// Создание замкнутого кольца
		/// </summary>
		/// <param name="centre">Центр окружности</param>
		/// <param name="radius">Радиус оружности</param>
		/// <param name="extrudeValue">Значение выдавливания</param>
		private void BuildRing(double sketchOffset, Inventor.Point centre, double radius, double extrudeValue)
        {
			var sketchXY = _apiService.CreateNewSketch(3, sketchOffset);
			sketchXY.CreateCircle(centre, radius);
			sketchXY.CreateCircle(centre, radius - 40);
			_apiService.Extrude(sketchXY, extrudeValue);
		}

		/// <summary>
		/// Создание замкнутового круга
		/// </summary>
		/// <param name="centre">Центр окружности</param>
		/// <param name="radius">Радиус окружности</param>
		/// <param name="extrudeValue">Значение выдавливания</param>
		private void BuildClosedCircle(double sketchOffset, Inventor.Point centre, double radius, double extrudeValue)
        {
			var sketchXY = _apiService.CreateNewSketch(3, sketchOffset);
			sketchXY.CreateCircle(centre, radius);
			_apiService.Extrude(sketchXY, extrudeValue);
		}

		/// <summary>
		/// Создание кругового массива
		/// </summary>
		/// <param name="starterPoint"></param>
		/// <param name="holeRadius"></param>
		/// <param name="wholeRadius"></param>
		/// <param name="holeCount"></param>
		/// <param name="extrudeValue"></param>
		private void BuildCircularPatternByHand(double sketchOffset, Inventor.Point starterPoint, double holeRadius, double wholeRadius, double holeCount, double extrudeValue)
        {
			var sketchXY = _apiService.CreateNewSketch(3, sketchOffset);
			var degreeBetween = 360 / holeCount;
			var newPoint = _apiService.CreatePoint(0,0);
			for (int i = 0; i < holeCount; ++i)
            {
				newPoint.X = Math.Cos(2 * Math.PI * i / holeCount) * (wholeRadius - 15) + starterPoint.X;
				newPoint.Y = Math.Sin(2 * Math.PI * i / holeCount) * (wholeRadius - 15) + starterPoint.Y;
				sketchXY.CreateCircle(newPoint, holeRadius);
			}
			_apiService.ThroughExtrude(sketchXY, extrudeValue);
		}
	}
}
