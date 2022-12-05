using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TankWheel.Model;

namespace Services
{
    public interface IBuildService
    {
        /// <summary>
        /// Построение катка
        /// </summary>
        /// <param name="wheelParameters">Параметры катка</param>
        void BuildWheel(WheelValues wheelParameters);
    }
}
