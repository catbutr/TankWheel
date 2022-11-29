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
        void BuildWheel(WheelValues wheelParameters, IApiService apiService);
    }
}
