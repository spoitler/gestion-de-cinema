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
    /// Logique d'interaction pour gestionFilm.xaml
    /// </summary>
    public partial class gestionFilm : Window
    {
        GestionFilms listFilms = new GestionFilms();
        public gestionFilm()
        {
            InitializeComponent();

            /*film film = new film();
            film.titre = "Time out";
            film.description = "Bienvenue dans un monde où le temps a remplacé l'argent. Génétiquement modifiés, les hommes ne vieillissent plus après 25 ans. A partir de cet âge, il faut gagner du temps pour rester en vie. Alors que les riches, jeunes et beaux pour l'éternité, accumulent le temps par dizaines d'années, les autres mendient, volent et empruntent les quelques heures qui leur permettront d'échapper à la mort. Un homme, accusé à tort de meurtre, prend la fuite avec une otage qui deviendra son alliée.";
            DateTime date1 = new DateTime(2011, 11, 23);
            film.année = date1;
            film.id_realisateur = 1;

            listFilms.AjouterFilm(film);*/

            List<film> list = listFilms.ChargerFilms();

            foreach (film filmA in list)
            {
                ListViewFilms.Items.Add(filmA);
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

            listFilms.SupprimerFilm(id);
            ListViewFilms.Items.RemoveAt(ListViewFilms.SelectedIndex);
            ListViewFilms.Items.Refresh();
            Delete.IsEnabled = false;
            Edit.IsEnabled = false;
        }

        private void Button_Click_edit(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Tag);
            edit w = new edit(id, this);
            w.Show();
            Delete.IsEnabled = false;
            Edit.IsEnabled = false;
        }

        private void ListViewFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Delete.IsEnabled = true;
            Edit.IsEnabled = true;
            film film = ListViewFilms.SelectedItem as film;
            if (film != null)
            {
                Delete.Tag = film.id_film;
                Edit.Tag = film.id_film;
            }
        }

        private void Button_Click_Add(object sender, RoutedEventArgs e)
        {
            add a = new add(this);
            a.Show();
        }
    }
}
