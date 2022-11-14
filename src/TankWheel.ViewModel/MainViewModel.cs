using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using TankWheel.Model;

namespace TankWheel.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private WheelValues _wheelValues;

        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
        public WheelValues WheelValues
            {
                get
                    {
                        return _wheelValues;
                    }
                set
                    {
                        _wheelValues = value;
                    }
            }

    }
}
