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
		private InventorConnector _apiService;

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
			_apiService = new InventorConnector(wheelValues);
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
			var foundationExtrudeValue = _wheelValues.FoundationThickness;
			var captExtrudeValue = _wheelValues.CapThickness + _wheelValues.FoundationThickness;
			///Точки
			var mainCentre = _apiService.CreatePoint(0, 0, 0);
			var foundationHoleCentre = _apiService.CreatePoint(0, (_wheelValues.FoundationDiameter / 2) - 15, 0);
			///Кол-во отверстий
			var foundationHoles = _wheelValues.FoundationNumberOfHoles;
			///Строительство
			BuildRing(mainCentre, mainRadius, mainExtrudeValue);
			BuildClosedCircle(mainCentre, innerRadius, innerExtrudeValue);
			BuildClosedCircle(mainCentre, foundationRadius, foundationExtrudeValue);
			BuildClosedCircle(mainCentre, CapRadius, captExtrudeValue);
			BuildClosedCircle(mainCentre, innerRadius, -30);
			BuildCircularPattern(foundationHoleCentre, 5, foundationHoles, 90);
		}

		/// <summary>
		/// Создание левой части катка
		/// </summary>
		private void BuildLeftWheel()
		{
			//Переменные для создания основания половины катка
			///Радиусы
			var mainRadius = _wheelValues.WheelDiameter / 2;
			var innerRadius = (_wheelValues.WheelDiameter / 2) - 40;
			var foundationRadius = _wheelValues.FoundationDiameter / 2;
			var CapRadius = (_wheelValues.FoundationDiameter - 50) / 2;
			///Выдавливания
			var mainExtrudeValue = _wheelValues.RimThickness;
			var innerExtrudeValue = _wheelValues.RimThickness - _wheelValues.WallHeight;
			var foundationExtrudeValue = _wheelValues.FoundationThickness;
			var captExtrudeValue = _wheelValues.CapThickness + _wheelValues.FoundationThickness;
			///Точки
			var mainCentre = _apiService.CreatePoint(0, 0, -30);
			var foundationHoleCentre = _apiService.CreatePoint(0, (_wheelValues.FoundationDiameter / 2) - 15, -30);
			//Строительство
		}

		/// <summary>
		/// Создание замкнутого кольца
		/// </summary>
		/// <param name="centre">Центр окружности</param>
		/// <param name="radius">Радиус оружности</param>
		/// <param name="extrudeValue">Значение выдавливания</param>
		private void BuildRing(Inventor.Point centre, double radius, double extrudeValue)
        {
			var sketchXY = _apiService.CreateNewSketch(3, 0);
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
		private void BuildClosedCircle(Inventor.Point centre, double radius, double extrudeValue)
        {
			var sketchXY = _apiService.CreateNewSketch(3, 0);
			sketchXY.CreateCircle(centre, radius);
			_apiService.Extrude(sketchXY, extrudeValue);
		}

		/// <summary>
		/// Создание кругового массива
		/// </summary>
		/// <param name="centre">Центр главной окружности</param>
		/// <param name="radius">Радиус главной окружности</param>
		/// <param name="holeCount">Кол-во отверстий</param>
		/// <param name="extrudeValue">Глубина выдавливания</param>
		private void BuildCircularPattern(Inventor.Point centre, double radius, double holeCount, double extrudeValue)
        {
			var degree = 360;
			var sketchXY = _apiService.CreateNewSketch(3, 0);
			sketchXY.CreateCircle(centre, radius);
			_apiService.CircleArray(sketchXY, degree, holeCount);
			_apiService.Extrude(sketchXY, extrudeValue);
		}


	}
}
