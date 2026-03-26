using System.Collections.ObjectModel;
using System.Windows;

namespace databaze_projekt
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<Mikina> Mikiny { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Mikiny = new ObservableCollection<Mikina>();

            DataContext = this;
        }

        // PŘIDAT
        private void Pridat_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(tbZnacka.Text))
            {
                MessageBox.Show("Zadej značku!");
                return;
            }

            decimal cena;
            decimal.TryParse(tbCena.Text, out cena);

            Mikina nova = new Mikina
            {
                Znacka = tbZnacka.Text,
                Velikost = tbVelikost.Text,
                Barva = tbBarva.Text,
                Cena = cena,
                Skladem = cbSkladem.IsChecked == true
            };

            Mikiny.Add(nova);

            VymazFormular();
        }

        // NAČÍST DO FORMULÁŘE
        private void Nacist_Click(object sender, RoutedEventArgs e)
        {
            if (dgMikiny.SelectedItem is Mikina vybrana)
            {
                tbZnacka.Text = vybrana.Znacka;
                tbVelikost.Text = vybrana.Velikost;
                tbBarva.Text = vybrana.Barva;
                tbCena.Text = vybrana.Cena.ToString();
                cbSkladem.IsChecked = vybrana.Skladem;
            }
        }

        // UPRAVIT
        private void Upravit_Click(object sender, RoutedEventArgs e)
        {
            if (dgMikiny.SelectedItem is Mikina vybrana)
            {
                decimal cena;
                decimal.TryParse(tbCena.Text, out cena);

                vybrana.Znacka = tbZnacka.Text;
                vybrana.Velikost = tbVelikost.Text;
                vybrana.Barva = tbBarva.Text;
                vybrana.Cena = cena;
                vybrana.Skladem = cbSkladem.IsChecked == true;

                dgMikiny.Items.Refresh();
            }
        }

        // SMAZAT
        private void Smazat_Click(object sender, RoutedEventArgs e)
        {
            if (dgMikiny.SelectedItem is Mikina vybrana)
            {
                Mikiny.Remove(vybrana);
            }
        }

        // VYČISTIT FORMULÁŘ
        private void Vymazat_Click(object sender, RoutedEventArgs e)
        {
            VymazFormular();
        }

        private void VymazFormular()
        {
            tbZnacka.Text = "";
            tbVelikost.Text = "";
            tbBarva.Text = "";
            tbCena.Text = "";
            cbSkladem.IsChecked = false;
        }
    }
}