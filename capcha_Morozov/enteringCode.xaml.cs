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
using System.Windows.Threading;

namespace capcha_Morozov
{
    /// <summary>
    /// Логика взаимодействия для enteringCode.xaml
    /// </summary>
    public partial class enteringCode : Window
    {
        string code = "";
        private int sec = 10;
        private DispatcherTimer dispatcherTimer;

        public enteringCode(string code)
        {
            InitializeComponent();
            this.code = code;
            dispatcherTimer = new DispatcherTimer();
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Tick += Timer_Tick;
            dispatcherTimer.Start();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            if (sec != 0)
            {
                sec--;
                timer.Text = $"Осталось {sec} секунд";
            }
            else
            {
                dispatcherTimer.Stop();
                MainWindow.attempts++;
                MessageBox.Show("не успешно");
                this.Close();
            }
        }

        private void codeTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (codeTB.Text.Equals(code))
            {
                dispatcherTimer.Stop();
                MessageBox.Show("успешно");
                this.Close();
                Environment.Exit(0);
            }
            if (!codeTB.Text.Equals(code) && codeTB.Text.Length == 5)
            {
                dispatcherTimer.Stop();
                MainWindow.attempts++;
                MessageBox.Show("не успешно");
                this.Close();
            }
        }
    }
}
