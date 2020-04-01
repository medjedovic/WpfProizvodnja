using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfProizvodnja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<clsSirovine> lstSirovina = new ObservableCollection<clsSirovine>();

        public MainWindow()
        {
            InitializeComponent();

            //proglašavanje datacontexta sam prozor i naći će pretragu property u datacontextu
            DataContext = this;

            lstSirovina.Add(new clsSirovine("001","mlevena plazma", 190, 300));
            lstSirovina.Add(new clsSirovine("002","šaćer sitni", 85, 1));
            lstSirovina.Add(new clsSirovine("003","slatka pavlaka", 120, 5));
            lstSirovina.Add(new clsSirovine("004","orah mrezga", 800, 1));
            dgSirovine.ItemsSource = lstSirovina;
        }

        private void izlaz(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void dgSirovine_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dgSirovine.SelectedItems.Count != 1)
            {
                btnIzmeni.IsEnabled = false;
                btnP.IsEnabled = false;
                btnM.IsEnabled = false;
            }
            else
            {
                btnIzmeni.IsEnabled = true;
                btnP.IsEnabled = true;
                btnM.IsEnabled = true;
            }
            
        }

        private void Dodaj_sirovinu(object sender, RoutedEventArgs e)
        {
            WinAESirovina waes = new WinAESirovina(lstSirovina.ToList());
            waes.Owner = this;
            if (waes.ShowDialog() == true)
            {
                lstSirovina.Add(waes.DataContext as clsSirovine);
            }

        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            if (dgSirovine.SelectedItem != null)
            {
                WinAESirovina waes = new WinAESirovina(lstSirovina.ToList());
                waes.Owner = this;
                waes.DataContext = dgSirovine.SelectedItem;
                waes.ShowDialog();
            }
        }

     

        private void BrisanjeSirovine(object sender, RoutedEventArgs e)
        {
            if (dgSirovine.SelectedItem != null)
            {
                List<clsSirovine> zaBrisanje = new List<clsSirovine>();
                //foreach je protektivan i ne dozvoljava brisanje sa ObservableCollection na kojoj radi
                foreach (clsSirovine selektovano in dgSirovine.SelectedItems)
                {
                    //dodaje na listu sve selektovanje jer ne može da ih briše
                    zaBrisanje.Add(selektovano);
                }

                foreach (clsSirovine o in zaBrisanje)
                {
                    //briše sve sa listeO listu koja je obeležena zaBrisanje
                    lstSirovina.Remove(o);
                    //brisanje liste .clear()
                }
            }

            if (dgSirovine.SelectedItem != null)
            {
                lstSirovina.Remove(dgSirovine.SelectedItem as clsSirovina);
            }
        }
    }
}
