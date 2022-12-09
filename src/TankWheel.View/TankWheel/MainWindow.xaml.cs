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

    //TODO
    //Апдейт значений W3/W4 при изменении D1/W3+
    //Разблокировка кнопки субмит+

    ///TODO
    ///Восстановление эффектов через viewmodel:
    ///Отключение кнопки принять
    ///Проверка на ошибки
    ///Смена фокуса

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // TODO: паттерн MVVM предполагает отсутствие code behind,
        // т.е. все взаимодействия с view происходят через Binding с свойствами ViewModel
        // нажатия кнопок обрабатываються через command, зачем тогда вообще ViewModel если тут View напрямую свзяанна с моделью?

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        void LoopVisualTree(DependencyObject obj)
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {

                if (obj is TextBox)
                {
                    ((TextBox)obj).Text = null;
                }
                LoopVisualTree(VisualTreeHelper.GetChild(obj, i));
            }

        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            LoopVisualTree(this);
        }
    }
}
