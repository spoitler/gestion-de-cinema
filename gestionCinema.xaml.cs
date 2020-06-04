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

namespace ppeEntityWpf
{
    /// <summary>
    /// Logique d'interaction pour gestionCinema.xaml
    /// </summary>
    public partial class gestionCinema : Window
    {

        GestionCinemas listCinemas = new GestionCinemas();
        public gestionCinema()
        {
            InitializeComponent();

          /*  cinema cinema = new cinema();
            cinema.nom = "Cinema Gaumont comédie";
            cinema.id_ville = 1;

            listCinemas.AjouterCinema(cinema);*/

            List<cinema> list = listCinemas.ChargerCinemas();

            foreach (cinema cinemaA in list)
            {
                ListViewCinemas.Items.Add(cinemaA);
            }
        }

        private void Button_Click_More(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            var id = button.Tag.ToString();
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Tag);

            listCinemas.SupprimerCinema(id);
            ListViewCinemas.Items.RemoveAt(ListViewCinemas.SelectedIndex);
            ListViewCinemas.Items.Refresh();
            Delete.IsEnabled = false;
            Edit.IsEnabled = false;
        }

        private void Button_Click_edit(object sender, RoutedEventArgs e)
        {

            Button button = sender as Button;
            int id = Convert.ToInt32(button.Tag);
            editCinema w = new editCinema(id, this);
            w.Show();
            Delete.IsEnabled = false;
            Edit.IsEnabled = false;
        }

        private void ListViewCinemas_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Delete.IsEnabled = true;
            Edit.IsEnabled = true;
            cinema cinema = ListViewCinemas.SelectedItem as cinema;
            if (cinema != null)
            {
                Delete.Tag = cinema.id_cinema;
                Edit.Tag = cinema.id_cinema;
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            addCinema a = new addCinema(this);
            a.Show();
        }
    }
}
