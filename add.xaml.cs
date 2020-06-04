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
    /// Logique d'interaction pour add.xaml
    /// </summary>
    public partial class add : Window
    {
        GestionFilms listFilms = new GestionFilms();
        GestionReal listReals = new GestionReal();
        GestionActeurs listActeurs = new GestionActeurs();
        GestionGenres listGenres = new GestionGenres();
        List<acteur> listActeursA = new List<acteur>();
        List<genre> listGenresA = new List<genre>();
        public add(gestionFilm w)
        {
            InitializeComponent();

            film = new film();
            this.w = w;
            start();
        }

        public gestionFilm w { get; set; }
        private film film { get; set; }

        public void start()
        {
            List<realisateur> list = listReals.ChargerReal();
            List<acteur> listA = listActeurs.ChargerActeur();
            List<genre> listG = listGenres.ChargerGenres();

            foreach (realisateur real in list)
            {
                list_realisateur.Items.Add(real.fullName);
            }
            foreach (acteur act in listA)
            {
                combo_list.Items.Add(act.fullName);
            }
            foreach (genre genre in listG)
            {
                combo_list_Genres.Items.Add(genre.name);
            }
            delete_act.IsEnabled = false;
            add_acteur.IsEnabled = false;
            delete_genre.IsEnabled = false;
            add_genre.IsEnabled = false;
        }

        private void Update_Date(object sender, SelectionChangedEventArgs e)
        {
            DatePicker d = sender as DatePicker;
            DateTime? dt = d.SelectedDate;

            if (film.année != dt)
            {
                film.année = dt.Value;
            }
        }

        private void TextBox_TextChanged_Description(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            film.description = t.Text;
        }

        private void TextBox_TextChanged_Title(object sender, TextChangedEventArgs e)
        {
            TextBox t = sender as TextBox;
            film.titre = t.Text;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            listFilms.AjouterFilm(film);

            w.ListViewFilms.Items.Clear();
            List<film> list = listFilms.ChargerFilms();

            foreach (film filmA in list)
            {
                w.ListViewFilms.Items.Add(filmA);
            }
            this.Close();
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void list_realisateur_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox c = sender as ComboBox;
            List<realisateur> list = listReals.ChargerReal();

            foreach (realisateur real in list)
            {
                if (real.fullName == c.SelectedItem.ToString())
                {
                    film.id_realisateur = real.id_realisateur;
                }
            }
        }

        private void acteur_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (acteur_list.SelectedItem != null)
            {
                delete_act.IsEnabled = true;

                string fullname = acteur_list.SelectedItem.ToString();

                foreach (acteur acteur in film.acteurs)
                {
                    if (acteur.fullName == fullname)
                    {
                        delete_act.Tag = acteur.id_acteur;
                        break;
                    }
                }
            }
        }

        private void delAct(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.Tag);

            foreach (acteur acteur in film.acteurs)
            {
                if (acteur.id_acteur == id)
                {
                    film.acteurs.Remove(acteur);
                    break;
                }
            }
            listActeursA.RemoveAt(acteur_list.SelectedIndex);
            acteur_list.Items.RemoveAt(acteur_list.SelectedIndex);
            acteur_list.Items.Refresh();
            delete_act.IsEnabled = false;
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            add_acteur.IsEnabled = true;
            List<acteur> listA = listActeurs.ChargerActeur();

            if (combo_list.SelectedItem != null)
            {
                string fullname = combo_list.SelectedItem.ToString();
                foreach (acteur acteur in listActeursA)
                {
                    if (acteur.fullName == fullname)
                    {
                        add_acteur.IsEnabled = false;
                        break;
                    }
                    else
                    {
                        add_acteur.IsEnabled = true;
                    }
                }

                foreach (acteur acteur in listA)
                {
                    if (acteur.fullName == fullname)
                    {
                        add_acteur.Tag = acteur.id_acteur;
                    }
                }
            }
        }

        private void combo_Genres_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            add_genre.IsEnabled = true;
            List<genre> listG = listGenres.ChargerGenres();

            if (combo_list_Genres.SelectedItem != null)
            {
                string genreN = combo_list_Genres.SelectedItem.ToString();
                foreach (genre genre in listGenresA)
                {
                    if (genre.name == genreN)
                    {
                        add_genre.IsEnabled = false;
                        break;
                    }
                    else
                    {
                        add_genre.IsEnabled = true;
                    }
                }

                foreach (genre genre in listG)
                {
                    if (genre.name == genreN)
                    {
                        add_genre.Tag = genre.id_genre;
                    }
                }
            }
        }

        private void add_acteur_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.Tag);
            acteur acteurA = listFilms.RechercherAct(id);

            film.acteurs.Add(acteurA);
            listActeursA.Add(acteurA);
            acteur_list.Items.Add(combo_list.SelectedItem);
            acteur_list.Items.Refresh();
            add_acteur.IsEnabled = false;
        }

        private void add_genre_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.Tag);
            genre genreA = listFilms.RechercherGenre(id);

            film.genres.Add(genreA);
            listGenresA.Add(genreA);
            genre_list.Items.Add(combo_list_Genres.SelectedItem);
            genre_list.Items.Refresh();
            add_genre.IsEnabled = false;
        }

        private void delGenre(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            int id = Convert.ToInt32(b.Tag);

            foreach (genre genre in film.genres)
            {
                if (genre.id_genre == id)
                {
                    film.genres.Remove(genre);
                    break;
                }
            }
            listGenresA.RemoveAt(genre_list.SelectedIndex);
            genre_list.Items.RemoveAt(genre_list.SelectedIndex);
            genre_list.Items.Refresh();
            delete_genre.IsEnabled = false;
        }

        private void genre_list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (genre_list.SelectedItem != null)
            {
                delete_genre.IsEnabled = true;

                string genreN = genre_list.SelectedItem.ToString();

                foreach (genre genre in film.genres)
                {
                    if (genre.name == genreN)
                    {
                        delete_genre.Tag = genre.id_genre;
                        break;
                    }
                }
            }
        }
    }
}
