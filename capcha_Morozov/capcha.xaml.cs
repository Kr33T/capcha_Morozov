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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace capcha_Morozov
{
    /// <summary>
    /// Логика взаимодействия для capcha.xaml
    /// </summary>
    public partial class capcha : Window
    {
        string str = "";

        public capcha()
        {
            InitializeComponent();

            updateCapcha();
        }

        void updateCapcha()
        {
            canvas.Children.Clear();
            str = "";
            Random rnd = new Random();
            int linesCount = rnd.Next(40, 70);
            int textLength = rnd.Next(7, 10);

            for (int i = 0; i < linesCount; i++)
            {
                Brush color = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rnd.Next(1, 255)), Convert.ToByte(rnd.Next(1, 255)), Convert.ToByte(rnd.Next(1, 233))));
                Line line = new Line()
                {
                    X1 = rnd.Next(Convert.ToInt32(canvas.Width)),
                    Y1 = rnd.Next(Convert.ToInt32(canvas.Height)),
                    X2 = rnd.Next(Convert.ToInt32(canvas.Width)),
                    Y2 = rnd.Next(Convert.ToInt32(canvas.Height)),
                    Stroke = color,
                    Fill = color
                };
                canvas.Children.Add(line);
            }

            for (int i = 0; i < textLength; i++)
            {
                int symbol = rnd.Next(2);
                switch (symbol)
                {
                    case 0:
                        int size = rnd.Next(2);
                        switch (size)
                        {
                            case 0:
                                str += Convert.ToChar(rnd.Next('a', 'z' + 1));
                                break;
                            case 1:
                                str += Convert.ToChar(rnd.Next('A', 'Z' + 1));
                                break;
                        }
                        break;
                    case 1:
                        str += rnd.Next(0, 10).ToString();
                        break;
                }
            }

            int startSegment = 0, endSegment = 0;
            int step = Convert.ToInt32(canvas.Width / str.Length);
            for (int i = 0; i < str.Length; i++)
            {
                if (i == 0)
                {
                    endSegment += step;
                }
                else
                {
                    startSegment = endSegment;
                    endSegment += step;
                }
                int widthSegment = rnd.Next(startSegment, endSegment), heightSegment = rnd.Next(0, Convert.ToInt32(canvas.Height));
                if (widthSegment >= canvas.Width - 30) widthSegment -= 30;
                if (heightSegment >= canvas.Height - 30) heightSegment -= 30;
                int font = rnd.Next(3);
                TextBlock tb = null;
                switch (font)
                {
                    case 0:
                        tb = new TextBlock()
                        {
                            Text = str[i].ToString(),
                            FontSize = 16,
                            FontWeight = FontWeights.Bold,
                            Padding = new Thickness(widthSegment, heightSegment, 0, 0),
                        };
                        break;
                    case 1:
                        tb = new TextBlock()
                        {
                            Text = str[i].ToString(),
                            FontSize = 16,
                            FontStyle = FontStyles.Italic,
                            Padding = new Thickness(widthSegment, heightSegment, 0, 0),
                        };
                        break;
                    case 2:
                        tb = new TextBlock()
                        {
                            Text = str[i].ToString(),
                            FontSize = 16,
                            FontStyle = FontStyles.Italic,
                            FontWeight = FontWeights.Bold,
                            Padding = new Thickness(widthSegment, heightSegment, 0, 0),
                        };
                        break;
                }
                canvas.Children.Add(tb);
            }
            confirmBTN.Content = str;
        }

        private void cancelBTN_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmBTN_Click(object sender, RoutedEventArgs e)
        {
            if (capchaTB.Text.Equals(str))
            {
                MessageBox.Show("успешно");
                Environment.Exit(0);
                
            }
            else
            {
                MessageBox.Show("не успешно");
                updateCapcha();
            }
        }
    }
}
