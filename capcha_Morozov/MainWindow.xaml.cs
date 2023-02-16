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

namespace capcha_Morozov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static int attempts = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void authBTN_Click(object sender, RoutedEventArgs e)
        {
            if (loginTB.Text.Equals("admin") && passwordTB.Password.Equals("admin"))
            {
                if (attempts < 2)
                {
                    showCode window = new showCode();
                    window.Show();
                }
                else
                {
                    MessageBox.Show("Введите капчу", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                    capcha window = new capcha();
                    window.Show();
                }
            }
            else
            {
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void capchaBTN_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
