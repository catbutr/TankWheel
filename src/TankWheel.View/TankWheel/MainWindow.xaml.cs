using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace TankWheel
{

    //TODO
    //Апдейт значений W3/W4 при изменении D1/W3+
    //Разблокировка кнопки субмит+

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private MainViewModel viewModel;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainViewModel();
            viewModel.WheelValues = new WheelValues();
            this.DataContext = viewModel.WheelValues;
        }        

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
            if(IsValid(this) == true)
            {
                submitButton.IsEnabled = true;
            }
        }

        private void D1_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(D1_TextBox.Text) == false)
            {
                if (Convert.ToDouble(D1_TextBox.Text) < 600 || Convert.ToDouble(D1_TextBox.Text) > 750)
                {
                    W3_TextBox.IsEnabled = false;
                }
                else
                {
                    W3_TextBox.IsEnabled = true;
                }
            }
            else
            {
                W3_TextBox.IsEnabled = false;
            }
        }

        private void W3_TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (String.IsNullOrEmpty(W3_TextBox.Text) == false)
            {
                if (Convert.ToDouble(W3_TextBox.Text) < 70 || Convert.ToDouble(W3_TextBox.Text) > 150)
                {
                    W4_TextBox.IsEnabled = false;
                }
                else
                {
                    W4_TextBox.IsEnabled = true;
                }
            }
            else
            {
                W4_TextBox.IsEnabled = false;
            }
        }

        private bool IsValid(DependencyObject obj)
        {
            // The dependency object is valid if it has no errors and all
            // of its children (that are dependency objects) are error-free.
            return !Validation.GetHasError(obj) &&
            LogicalTreeHelper.GetChildren(obj)
            .OfType<DependencyObject>()
            .All(IsValid);
        }

        private void LostFocusCheck(object sender, RoutedEventArgs e)
        {
            if (IsValid(this) == true)
            {
                submitButton.IsEnabled = true;
            }
        }

        private void LostFocusCheck(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (IsValid(this) == true)
            {
                submitButton.IsEnabled = true;
            }
        }
    }
}
