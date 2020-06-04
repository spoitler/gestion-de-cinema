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
    /// Logique d'interaction pour editCinema.xaml
    /// </summary>
    public partial class editCinema : Window
    {
        GestionCinemas listCinemas = new GestionCinemas();
        GestionFilms listFilms = new GestionFilms();
        GestionVilles listVilles = new GestionVilles();
        List<film> listFilmsA = new List<film>();
        public editCinema(int id, gestionCinema w)
        {
            InitializeComponent();

            this.id = id;
            this.w = w;
            showCinema();
        }

        public int id { get; set; }

        public gestionCinema w { get; set; }
        private cinema cinema{ get; set; }

        public void showCinema()
        {
            cinema = getCinema();
            List<ville> list = listVilles.ChargerVilles();
            List<film> listF = listFilms.ChargerFilms();


            nom_textbox.Text = this.cinema.nom;
            list_ville.SelectedItem = this.cinema.ville.nom;
            foreach (ville ville in list)
            {
                list_ville.Items.Add(ville.nom);
            }
            foreach (film f in this.cinema.films)
            {
                film_list.Items.Add(f.titre);
                listFilmsA.Add(f);
            }
            foreach (film film in listF)
            {
                combo_list.Items.Add(film.titre);
            }
            delete_film.IsEnabled = false;
            add_film.IsEnabled = false;
        }

        private cinema getCinema()
        {
            List<cinema> list = listCinemas.ChargerCinemas();
            foreach (cinema cinema in list)
            {
                if (cinema.id_cinema == this.id)
                {
                    return cinema;
                }
            }
            return null;
        }

        private void TextBox_TextChanged_Nom(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            cinema.nom= t.Text;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            listCinemas.ModifierCinema(cinema);

            w.ListViewCinemas.Items.Clear();
            List<cinema> list = listCinemas.ChargerCinemas();

            foreach (cinema cinemaA in list)
            {
                w.ListViewCinemas.Items.Add(cinemaA);
            }
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void list_ville_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = sender as ComboBox;
            List<ville> list = listVilles.ChargerVilles();

            foreach (ville ville in list)
            {
                if (ville.nom == c.SelectedItem.ToString())
                {
                    cinema.id_ville = ville.id_ville;
                }
            }
        }

        private void film_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (film_list.SelectedItem != null)
            {
                delete_film.IsEnabled = true;

                string name = film_list.SelectedItem.ToString();

                foreach (film film in cinema.films)
                {
                    if (film.titre == name)
                    {
                        delete_film.Tag = film.id_film;
                        break;
                    }
                }
            }
        }

        private void delFilm(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.Tag);

            foreach (film film in cinema.films)
            {
                if (film.id_film == id)
                {
                    cinema.films.Remove(film);
                    break;
                }
            }
            listFilmsA.RemoveAt(film_list.SelectedIndex);
            film_list.Items.RemoveAt(film_list.SelectedIndex);
            film_list.Items.Refresh();
            delete_film.IsEnabled = false;
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            add_film.IsEnabled = true;
            List<film> listA = listFilms.ChargerFilms();

            if (combo_list.SelectedItem != null)
            {
                string name = combo_list.SelectedItem.ToString();
                foreach (film film in listFilmsA)
                {
                    if (film.titre == name)
                    {
                        add_film.IsEnabled = false;
                        break;
                    }
                    else
                    {
                        add_film.IsEnabled = true;
                    }
                }

                foreach (film film in listA)
                {
                    if (film.titre == name)
                    {
                        add_film.Tag = film.id_film;
                    }
                }
            }
        }

        private void add_film_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.Tag);
            film filmA = listCinemas.RechercherFilm(id);

            cinema.films.Add(filmA);
            listFilmsA.Add(filmA);
            film_list.Items.Add(combo_list.SelectedItem);
            film_list.Items.Refresh();
            add_film.IsEnabled = false;
        }
    }
}
