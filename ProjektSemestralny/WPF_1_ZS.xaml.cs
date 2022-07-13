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

        private int odswiezanieID = 0;

        private void gridDoctors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.gridDoctors.SelectedIndex >= 0)
            {
                if (this.gridDoctors.SelectedItems.Count >= 0)
                {
                    if (this.gridDoctors.SelectedItems[0].GetType() == typeof(Doktorzy))
                    {
                        Doktorzy d = (Doktorzy)this.gridDoctors.SelectedItems[0];
                        this.txtImie2.Text = d.Imie;
                        this.txtNazwisko2.Text = d.Nazwisko;
                        this.txtSpecjalizacja2.Text = d.Specjalizacja;
                        this.odswiezanieID = d.Id;
                    }
                }
            }
        }

        private void btnUpdateDoctor_Click(object sender, RoutedEventArgs e)
        {
            SzpitalDBEntities db = new SzpitalDBEntities();

            var r = from d in db.Doktorzies
                    where d.Id == this.odswiezanieID
                    select d;

            Doktorzy obj = r.SingleOrDefault();

            if (obj != null)
            {
                obj.Imie = this.txtImie2.Text;
                obj.Nazwisko = this.txtNazwisko2.Text;
                obj.Specjalizacja = this.txtSpecjalizacja2.Text;
            }

            db.SaveChanges();

        }

        private void btnDeleteDoctor_Click(object sender, RoutedEventArgs e)
        {
                MessageBoxResult msgBoxResult = MessageBox.Show("Czy jesteś pewien usunięcia wybranego rekordu?",
                "Usuń rekord",
                MessageBoxButton.YesNo,
                MessageBoxImage.Warning,
                MessageBoxResult.No);

            if (msgBoxResult == MessageBoxResult.Yes)
            {

                SzpitalDBEntities db = new SzpitalDBEntities();

                var r = from d in db.Doktorzies
                        where d.Id == this.odswiezanieID
                        select d;

                Doktorzy obj = r.SingleOrDefault();

                if (obj != null)
                {
                    db.Doktorzies.Remove(obj);
                    db.SaveChanges();
                }
            }

            
        }
    }
}
