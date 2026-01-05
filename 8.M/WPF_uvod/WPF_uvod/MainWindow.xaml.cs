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

namespace WPF_uvod
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

        private void Klik(object sender, RoutedEventArgs e)
        {
            if (txtPozdrav.Text == "")
                MessageBox.Show("vstupni pole je prazdne");
            else
                btmPozdrav.Content = txtPozdrav.Text;
        }

        private void btmPozdrav_MouseEnter(object sender, MouseEventArgs e)
        {
            //r,g,b
            Random rnd = new Random();
            byte r = (byte)rnd.Next(255);
            byte g = (byte)rnd.Next(255);
            byte b = (byte)rnd.Next(255);

            //barva tlacitka
            btmPozdrav.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }
    }
}