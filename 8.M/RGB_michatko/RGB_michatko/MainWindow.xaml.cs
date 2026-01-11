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
                    MessageBox.Show("Co děláš ????");
                }
            }
        }

        private void ModrePosouvatko_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ModryText.Text = Convert.ToString(ModrePosouvatko.Value);
        }

        private void ZelenePosouvatko_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            ZelenyText.Text = Convert.ToString(ZelenePosouvatko.Value);
        }

        private void ZelenyText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ZelenyText.Text != string.Empty)
            {
                try
                {
                    ZelenePosouvatko.Value = Convert.ToDouble(ZelenyText.Text);
                    ZmenaBarvy();
                }
                catch
                {
                    MessageBox.Show("Co děláš ????");
                }
            }
        }

        private void CervenePosouvatko_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            CervenyText.Text = Convert.ToString(CervenePosouvatko.Value);
        }

        private void CervenyText_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (CervenyText.Text != string.Empty)
            {
                try
                {
                    CervenePosouvatko.Value = Convert.ToDouble(CervenyText.Text);
                    ZmenaBarvy();
                }
                catch
                {
                    MessageBox.Show("Co děláš ????");
                }
            }
        }


        public void ZmenaBarvy()
        {
            if (HexZapis == null)
                return;

            byte r = Convert.ToByte(CervenePosouvatko.Value);
            byte g = Convert.ToByte(ZelenePosouvatko.Value);
            byte b = Convert.ToByte(ModrePosouvatko.Value);

            Obdelnik.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));

            HexZapis.Content = $"#{r:X2}{g:X2}{b:X2}";
        }

    }
}