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

namespace TankWheel
{

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string _D1_Value;
        private string _D2_Value;
        private string _W1_Value;
        private string _W2_Value;
        private string _W3_Value;
        private string _W4_Value;

        public string D1_Validation
        {
            get { return _D1_Value; }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    int input_value = Convert.ToInt32(value);
                    if (input_value < 600 || input_value > 750)
                    {
                        D1_TextBox.Background = Brushes.Pink;
                        submitButton.IsEnabled = false;
                        D1_TextBox.ToolTip = "Диаметр катка должен быть в диапозоне 600-750мм";
                        W3_TextBox.IsEnabled = false;
                    }
                    else
                    {
                        D1_TextBox.Background = Brushes.White;
                        submitButton.IsEnabled = true;
                        D1_TextBox.ToolTip = null;
                        W3_TextBox.IsEnabled = true;
                    }
                }
                _D1_Value = value;
            }
        }

        public string D2_Validation
        {
            get { return _D2_Value; }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    int input_value = Convert.ToInt32(value);
                    if (input_value < 200 || input_value > 350)
                    {
                        D2_TextBox.Background = Brushes.Pink;
                        submitButton.IsEnabled = false;
                        D2_TextBox.ToolTip = "Диаметр основания соединения должен быть в диапозоне 200-350мм";
                    }
                    else
                    {
                        D2_TextBox.Background = Brushes.White;
                        submitButton.IsEnabled = true;
                        D2_TextBox.ToolTip = null;
                    }
                }
                _D2_Value = value;
            }
        }

        public string W1_Validation
        {
            get { return _W1_Value; }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    int input_value = Convert.ToInt32(value);
                    if (input_value < 30 || input_value > 70)
                    {
                        W1_TextBox.Background = Brushes.Pink;
                        submitButton.IsEnabled = false;
                        W1_TextBox.ToolTip = "Толщина основания соединения должна быть в диапозоне 30-70мм";
                    }
                    else
                    {
                        W1_TextBox.Background = Brushes.White;
                        submitButton.IsEnabled = true;
                        W1_TextBox.ToolTip = null;
                    }
                }
                _W1_Value = value;
            }
        }

        public string W2_Validation
        {
            get { return _W2_Value; }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    int input_value = Convert.ToInt32(value);
                    if (input_value < 25 || input_value > 50)
                    {
                        W2_TextBox.Background = Brushes.Pink;
                        submitButton.IsEnabled = false;
                        W2_TextBox.ToolTip = "Толщина крышки диска должна быть в диапозоне 25-50мм";
                    }
                    else
                    {
                        W2_TextBox.Background = Brushes.White;
                        submitButton.IsEnabled = true;
                        W2_TextBox.ToolTip = null;
                    }
                }
                _W2_Value = value;
            }
        }

        public string W3_Validation
        {
            get { return _W3_Value; }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    if (Convert.ToInt32(_D1_Value) > 600 && Convert.ToInt32(_D1_Value) <700)
                    {
                        int input_value = Convert.ToInt32(value);
                        if (input_value < 70 || input_value > 100)
                        {
                            W3_TextBox.Background = Brushes.Pink;
                            submitButton.IsEnabled = false;
                            W3_TextBox.ToolTip = "Толщина крышки диска должна быть в диапозоне 70-100мм";
                            W4_TextBox.IsEnabled = false;
                        }
                        else
                        {
                            W3_TextBox.Background = Brushes.White;
                            submitButton.IsEnabled = true;
                            W3_TextBox.ToolTip = null;
                            W4_TextBox.IsEnabled = true;
                        }
                    }
                    else
                    {
                        int input_value = Convert.ToInt32(value);
                        if (input_value < 100 || input_value > 150)
                        {
                            W3_TextBox.Background = Brushes.Pink;
                            submitButton.IsEnabled = false;
                            W3_TextBox.ToolTip = "Толщина крышки диска должна быть в диапозоне 100-150мм";
                            W4_TextBox.IsEnabled = false;
                        }
                        else
                        {
                            W3_TextBox.Background = Brushes.White;
                            submitButton.IsEnabled = true;
                            W3_TextBox.ToolTip = null;
                            W4_TextBox.IsEnabled = true;
                        }
                    }
                }
                _W3_Value = value;
            }
        }

        public string W4_Validation
        {
            get { return _W4_Value; }
            set
            {
                if (String.IsNullOrEmpty(value) == false)
                {
                    int input_value = Convert.ToInt32(value);
                    if (input_value < (Convert.ToInt32(_W3_Value) - 20) || input_value > (Convert.ToInt32(_W3_Value) + 20))
                    {
                        W4_TextBox.Background = Brushes.Pink;
                        submitButton.IsEnabled = false;
                        W4_TextBox.ToolTip = "Толщина крышки диска должна быть в диапозоне 25-50мм";
                    }
                    else
                    {
                        W4_TextBox.Background = Brushes.White;
                        submitButton.IsEnabled = true;
                        W4_TextBox.ToolTip = null;
                    }
                }
                _W4_Value = value;
            }
        }

        public MainWindow()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
