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
    /// Interaction logic for WPF_1_ZS.xaml
    /// </summary>
    public partial class WPF_1_ZS : Window
    {
        public WPF_1_ZS()
        {
            InitializeComponent();

            SzpitalDBEntities db = new SzpitalDBEntities();
            var docs = from d in db.Doktorzies
                       select new
                       {
                           DoktorImie = d.Imie,
                           Nazwisko = d.Nazwisko,
                           Specjalizacja = d.Specjalizacja
            
                       };

            foreach (var item in docs)
            {
                Console.WriteLine(item.DoktorImie);
                Console.WriteLine(item.Nazwisko);
                Console.WriteLine(item.Specjalizacja);
            }

            this.gridDoctors.ItemsSource = docs.ToList();

        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            SzpitalDBEntities db = new SzpitalDBEntities();

            Doktorzy doktorObject = new Doktorzy()
            {
                Imie = txtImie.Text,
                Nazwisko = txtNazwisko.Text,
                Specjalizacja = txtSpecjalizacja.Text
                
            };

            db.Doktorzies.Add(doktorObject);
            db.SaveChanges();

        }

        private void btnRefresh_Click(object sender, RoutedEventArgs e)
        {
            SzpitalDBEntities db = new SzpitalDBEntities();

            this.gridDoctors.ItemsSource = db.Doktorzies.ToList();
        }

        private void gridDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Console.WriteLine(this.gridDoctors.SelectedItems);
        }

        private void btnUpdateDoctor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
