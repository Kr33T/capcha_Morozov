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
using System.Windows.Shapes;

namespace capcha_Morozov
{
    /// <summary>
    /// Логика взаимодействия для showCode.xaml
    /// </summary>
    public partial class showCode : Window
    {
        string code;

        public showCode()
        {
            InitializeComponent();

            Random rnd = new Random();
            code = rnd.Next(10000, 100000).ToString();

            codeTB.Text = code;
        }

        private void enterBTN_Click(object sender, RoutedEventArgs e)
        {
            enteringCode window = new enteringCode(code);
            window.Show();
            this.Close();
        }
    }
}
