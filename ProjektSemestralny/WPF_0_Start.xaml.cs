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

namespace ProjektSemestralny
{
    /// <summary>
    /// Interaction logic for WPF_0_Start.xaml
    /// </summary>
    public partial class WPF_0_Start : Window
    {
        public WPF_0_Start()
        {
            InitializeComponent();
        }

        private void Przycisk1_Click(object sender, RoutedEventArgs e)
        {
            WPF_1_ZS lekarze = new WPF_1_ZS();
            lekarze.Show();
        }

        private void Przycisk2_Click(object sender, RoutedEventArgs e)
        {
            WPF_2_WIZYTY wizyty = new WPF_2_WIZYTY();
            wizyty.Show();
        }
    }
}
