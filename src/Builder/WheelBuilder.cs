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
		public IApiService ApiService { get; set; }

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
			ApiService = new InventorConnector();
			ApiService.CreateDocument();
			var extrudeValue = _wheelValues.DiskDistance;
			var rimThickness = _wheelValues.RimThickness;
			var offset = 0.0;
			if (_wheelValues.DiskQuantity == 1)
			{
				BuildOneDiskWheel();
			}
			else if (_wheelValues.DiskQuantity == 2)
            {
				offset = _wheelValues.DiskDistance;
				BuildRightWheel(0, extrudeValue);
				BuildLeftWheel(offset);
			}
			else
			{
				BuildRightWheel(offset, _wheelValues.DiskDistance);
				offset = _wheelValues.DiskDistance;
				for (int i = 0; i < _wheelValues.DiskQuantity-2; i++)
				{
					BuildMiddleWheel(offset, extrudeValue+ rimThickness);
					offset = offset + extrudeValue + rimThickness;
				}
				BuildLeftWheel(offset);
			}
		}

		/// <summary>
		/// Создание правого катка
		/// </summary>
		private void BuildRightWheel(double offset, double extrudeValue)
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
			var mainCentre = ApiService.CreatePoint(0, 0);
			///Кол-во отверстий
			var foundationHoles = _wheelValues.FoundationNumberOfHoles;
			var capHoles = _wheelValues.CapNumberOfHoles;
			///Строительство
			BuildRing(offset, mainCentre, mainRadius, mainExtrudeValue);
			BuildClosedCircle(offset, mainCentre, innerRadius, innerExtrudeValue);
			BuildClosedCircle(offset, mainCentre, foundationRadius, foundationExtrudeValue);
			BuildClosedCircle(offset, mainCentre, CapRadius, captExtrudeValue);
			BuildCircularPatternByHand(offset, mainCentre, 5, foundationRadius, foundationHoles, 90);
			BuildCircularPatternByHand(offset, mainCentre, 5, CapRadius, capHoles, 90);
			BuildClosedCircle(offset, mainCentre, CapRadius - 25, captExtrudeValue + 5);
			BuildClosedCircle(offset, mainCentre, innerRadius, -extrudeValue);
		}

		/// <summary>
		/// Создание левой части катка
		/// </summary>
		private void BuildLeftWheel(double offset)
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
			var mainCentre = ApiService.CreatePoint(0, 0);
			///Кол-во отверстий
			var foundationHoles = _wheelValues.FoundationNumberOfHoles;
			var capHoles = _wheelValues.CapNumberOfHoles;
			//Строительство
			BuildRing(-offset, mainCentre, mainRadius, -mainExtrudeValue);
			BuildClosedCircle(-offset, mainCentre, innerRadius, -innerExtrudeValue);
			BuildClosedCircle(-offset, mainCentre, foundationRadius, -foundationExtrudeValue);
			BuildClosedCircle(-offset, mainCentre, CapRadius, -captExtrudeValue);
			BuildCircularPatternByHand(-offset, mainCentre, 5, foundationRadius, foundationHoles, -90);
			BuildCircularPatternByHand(-offset, mainCentre, 5, CapRadius, capHoles, -90);
			BuildClosedCircle(-offset, mainCentre, CapRadius - 25, -captExtrudeValue - 5);
		}

		private void BuildMiddleWheel(double offset, double extrudeValue)
        {
			///Радиусы
			var mainRadius = _wheelValues.WheelDiameter / 2;
			var innerRadius = (_wheelValues.WheelDiameter / 2) - 40;
			///Выдавливания
			var mainExtrudeValue = _wheelValues.RimThickness;
			var innerExtrudeValue = _wheelValues.RimThickness - _wheelValues.WallHeight;
            ///Точки
			var mainCentre = ApiService.CreatePoint(0, 0);
			///Строительство
			BuildClosedCircle(-offset, mainCentre, mainRadius, -mainExtrudeValue);
			BuildClosedCircle(-offset, mainCentre, innerRadius, -extrudeValue);
		}

		private void BuildOneDiskWheel()
        {
			///Движение по эскизу
			var offset = _wheelValues.DiskDistance;
			///Радиусы
			var mainRadius = _wheelValues.WheelDiameter / 2;
			var innerRadius = (_wheelValues.WheelDiameter / 2) - 40;
			var foundationRadius = _wheelValues.FoundationDiameter / 2;
			var CapRadius = (_wheelValues.FoundationDiameter - 50) / 2;
			///Выдавливания
			var mainExtrudeValue = _wheelValues.RimThickness;
			var innerExtrudeValue = _wheelValues.RimThickness - _wheelValues.WallHeight;
			var foundationExtrudeValue = _wheelValues.FoundationThickness + innerExtrudeValue;
			var captExtrudeValue = _wheelValues.CapThickness + foundationExtrudeValue;
			///Точки
			var mainCentre = ApiService.CreatePoint(0, 0);
			///Кол-во отверстий
			var foundationHoles = _wheelValues.FoundationNumberOfHoles;
			var capHoles = _wheelValues.CapNumberOfHoles;
			//Строительство
			BuildRightWheel(0, offset);
			BuildRing(0, mainCentre, mainRadius, -mainExtrudeValue);
			BuildClosedCircle(0, mainCentre, innerRadius, -innerExtrudeValue);
			BuildClosedCircle(0, mainCentre, foundationRadius, -foundationExtrudeValue);
			BuildClosedCircle(0, mainCentre, CapRadius, -captExtrudeValue);
			BuildCircularPatternByHand(0, mainCentre, 5, foundationRadius, foundationHoles, -90);
			BuildCircularPatternByHand(0, mainCentre, 5, CapRadius, capHoles, -90);
			BuildClosedCircle(0, mainCentre, CapRadius - 25, -captExtrudeValue - 5);

		}

		/// <summary>
		/// Создание замкнутого кольца
		/// </summary>
		/// <param name="centre">Центр окружности</param>
		/// <param name="radius">Радиус оружности</param>
		/// <param name="extrudeValue">Значение выдавливания</param>
		private void BuildRing(double sketchOffset, Inventor.Point centre, double radius, double extrudeValue)
        {
			var sketchXY = ApiService.CreateNewSketch(3, sketchOffset);
			sketchXY.CreateCircle(centre, radius);
			sketchXY.CreateCircle(centre, radius - 40);
			ApiService.Extrude(sketchXY, extrudeValue);
		}

		/// <summary>
		/// Создание замкнутового круга
		/// </summary>
		/// <param name="centre">Центр окружности</param>
		/// <param name="radius">Радиус окружности</param>
		/// <param name="extrudeValue">Значение выдавливания</param>
		private void BuildClosedCircle(double sketchOffset, Inventor.Point centre, double radius, double extrudeValue)
        {
			var sketchXY = ApiService.CreateNewSketch(3, sketchOffset);
			sketchXY.CreateCircle(centre, radius);
			ApiService.Extrude(sketchXY, extrudeValue);
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
			var sketchXY = ApiService.CreateNewSketch(3, sketchOffset);
			var newPoint = ApiService.CreatePoint(0,0);
			for (int i = 0; i < holeCount; ++i)
            {
				newPoint.X = Math.Cos(2 * Math.PI * i / holeCount) * (wholeRadius - 15) + starterPoint.X;
				newPoint.Y = Math.Sin(2 * Math.PI * i / holeCount) * (wholeRadius - 15) + starterPoint.Y;
				sketchXY.CreateCircle(newPoint, holeRadius);
			}
			ApiService.ThroughExtrude(sketchXY, extrudeValue);
		}
	}
}
