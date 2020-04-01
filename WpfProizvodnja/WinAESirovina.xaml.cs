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

namespace WpfProizvodnja
{
    /// <summary>
    /// Interaction logic for WinAESirovina.xaml
    /// </summary>
    public partial class WinAESirovina : Window
    {
        public List<clsSirovine> sirovine;
        public WinAESirovina(List<clsSirovine> s)
        {
            InitializeComponent();

            //instanca klase osoba u datacontext zbog bindinga
            DataContext = new clsSirovine();

            //sve bindinge odjednom commituje
            BindingGroup = new BindingGroup();
            sirovine = s;
        }

        private void izlaz(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Dodaj_sirovinu(object sender, RoutedEventArgs e)
        {
            //binding commitedit vraća true i false
            if (BindingGroup.CommitEdit())
            {
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("NeŠto sa unosom nije uredu!!!");
            }
        }
    }
}
