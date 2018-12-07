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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
      
        }

        void OnClickConnect(object sender, RoutedEventArgs e)
        {
            try
            {
                Server S = new Server(ip.Text, Convert.ToInt32(port.Text));
                Calculator calc_window = new Calculator(S);
                calc_window.Show();
                calc_window.Closed += (sender2, e2) => {
                    ///Отображаем форму после закрытия  Window1
                    //this.Visibility = System.Windows.Visibility.Visible;
                    res.Text = "";
                };
                calc_window.ShowDialog();
            }
            catch
            {
                res.Text = "Connection error";
            }
        }
    }
}
