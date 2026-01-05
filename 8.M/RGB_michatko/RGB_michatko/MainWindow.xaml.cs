using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RGB_michatko
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ModryText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(ModryText.Text != string.Empty)
            {
                try
                {
                    ModrePosouvatko.Value = Convert.ToDouble(ModryText.Text);
                    ZmenaBarvy();
                }
                catch
                {
                    MessageBox.Show("Kriple");
                }
            }
        }

        private void ModrePosouvatko_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ModryText.Text = Convert.ToString(ModrePosouvatko.Value);
        }

        public void ZmenaBarvy()
        {
            byte r = Convert.ToByte(CervenePosouvatko.Value);
            byte g = Convert.ToByte(ZelenePosouvatko.Value);
            byte b = Convert.ToByte(ModrePosouvatko.Value);

            Obdelnik.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}