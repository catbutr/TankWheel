using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Globalization;
using System.ComponentModel;
using TankWheel.ViewModel;
using TankWheel.Model;
using InventorAPI;
using Services;
using Builder;

namespace TankWheel
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: паттерн MVVM предполагает отсутствие code behind,
        // т.е. все взаимодействия с view происходят через Binding с свойствами ViewModel
        // нажатия кнопок обрабатываються через command, зачем тогда вообще ViewModel если тут View напрямую связана с моделью?

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(new MessageBoxService());
        }
    }
}
