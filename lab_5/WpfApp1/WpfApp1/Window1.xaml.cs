using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel; // CancelEventArgs
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Drawing;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Calculator : Window
    {
        private Server S;
        public Calculator(Server S)
        {
            this.Closing += Server_Close;
            this.S = S;
            InitializeComponent();
        }
        
        void CalcClick(object sender, RoutedEventArgs e)
        {
            Console.WriteLine(input.Text);
            int id = S.GetId();
            double result = this.S.GetRes(input.Text);
            if (result == double.NaN)
            {
                res.Items.Add(new Item { Id = id + 1, Result = (input.Text + " = 000000") });
            }
            else
            {
                res.Items.Add(new Item{ Id = id + 1, Result = (input.Text + " = " + result.ToString())} );
            }
            
        }
        void Server_Close(object Sender, CancelEventArgs e)
        {
            S.Exit();
        } 
    }
    public class Item
    {
        public int Id { get; set; }

        public string Result{ get; set; }
    }
}
