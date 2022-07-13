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
    /// Interaction logic for WPF_2_WIZYTY.xaml
    /// </summary>
    public partial class WPF_2_WIZYTY : Window
    {
        public WPF_2_WIZYTY()
        {
            InitializeComponent();

            SzpitalDBEntities db = new SzpitalDBEntities();

            var result = from a in db.Wizyties
                         select new
                         {
                             a.DoktorID,
                             DoktorImie = a.Doktorzy.Imie,
                             DoktorNazwisko = a.Doktorzy.Nazwisko,
                             a.Doktorzy.Specjalizacja,
                             a.PacjentID,
                             PacjentImie = a.Pacjenci.Imie,
                             PacjentNazwisko = a.Pacjenci.Nazwisko,
                             a.Pacjenci.Telefon,
                             a.DataWizyty
                         };

            var resultWizytyDoktorow = from d in db.Doktorzies
                                       from a in d.Wizyties.DefaultIfEmpty()
                                       select new
                                       {
                                           ImieDoktora = d.Imie,
                                           NazwiskoDoktora = d.Nazwisko,
                                           IDWizyty = a.Id.ToString(),
                                           a.DataWizyty,
                                           ImiePacjenta = a.Pacjenci.Imie,
                                           NazwiskoPacjenta = a.Pacjenci.Nazwisko
                                       };

            this.gridWizyty.ItemsSource = resultWizytyDoktorow.ToList();
        }
    }
}
