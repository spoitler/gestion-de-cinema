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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.ComponentModel;
using System.Windows.Threading;

namespace ppeEntityWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GestionFilms listFilms = new GestionFilms();
        public MainWindow()
        {
            InitializeComponent();

            film film = new film();
            film.titre = "Time out";
            film.description = "Bienvenue dans un monde où le temps a remplacé l'argent. Génétiquement modifiés, les hommes ne vieillissent plus après 25 ans. A partir de cet âge, il faut gagner du temps pour rester en vie. Alors que les riches, jeunes et beaux pour l'éternité, accumulent le temps par dizaines d'années, les autres mendient, volent et empruntent les quelques heures qui leur permettront d'échapper à la mort. Un homme, accusé à tort de meurtre, prend la fuite avec une otage qui deviendra son alliée.";
            DateTime date1 = new DateTime(2011, 11, 23);
            film.année = date1;
            film.id_realisateur = 1;

            listFilms.AjouterFilm(film);



            List<film> list = listFilms.ChargerFilms();

            foreach (film filmA in list)
            {
                ListViewFilms.Items.Add(filmA);
            }
        }

        private void Button_Click_Modify(object sender, RoutedEventArgs e)
        {

            var button = sender as Button;
            var id = button.Tag.ToString();

            MessageBox.Show("click : " + id );
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            int id = Convert.ToInt32(button.Tag);
            MessageBox.Show(ListViewFilms.SelectedItem.ToString());
            listFilms.SupprimerFilm(id);
            ListViewFilms.Items.RemoveAt(ListViewFilms.SelectedIndex);

            
            ListViewFilms.Items.Refresh();
            

            /*MessageBox.Show();*/

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

           



            /*film film = new film();
            film.titre = "Time out";
            film.description = "Bienvenue dans un monde où le temps a remplacé l'argent. Génétiquement modifiés, les hommes ne vieillissent plus après 25 ans. A partir de cet âge, il faut gagner du temps pour rester en vie. Alors que les riches, jeunes et beaux pour l'éternité, accumulent le temps par dizaines d'années, les autres mendient, volent et empruntent les quelques heures qui leur permettront d'échapper à la mort. Un homme, accusé à tort de meurtre, prend la fuite avec une otage qui deviendra son alliée.";
            DateTime date1 = new DateTime(2011, 11, 23);
            film.année = date1;
            film.id_realisateur = 1;

            listFilms.AjouterFilm(film);

            ListViewFilms.Items.Add(film);*/

            /*listFilms.AjouterFilm(film);

            List<film> list = listFilms.ChargerFilms();

            foreach( film filmA in list)
            {
                ListView item = new ListView();
                item.Items.Add(filmA.id_film);
                MessageBox.Show(filmA.id_film + " Titre : " + filmA.titre + " Description : " + filmA.description + " Annee : " + filmA.année + " Realisateur : " + filmA.realisateur.prenom +" "+ filmA.realisateur.nom);
            }

            listFilms.SupprimerFilm(film);
            list = listFilms.ChargerFilms();

            foreach (film filmA in list)
            {
                MessageBox.Show(filmA.id_film + " Titre : " + filmA.titre + " Description : " + filmA.description + " Annee : " + filmA.année + " Realisateur : " + filmA.realisateur.prenom + " " + filmA.realisateur.nom);
            }*/

        }

        private void ListViewFilms_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Delete.IsEnabled = true;
            Object objet = ListViewFilms.SelectedItem;

            film film = (film)Convert.ChangeType(objet, typeof(film));

            Delete.Tag = film.id_film;

            // MessageBox.Show(test);

        }
    }
}
