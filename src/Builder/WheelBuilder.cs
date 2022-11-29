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
    public class WheelBuilder
    {
		/// <summary>
		/// Экземпляр класса для работы с API.
		/// </summary>
		private InventorConnector _apiService;

		/// <summary>
		/// Параметры забора.
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
		}

	}
}
