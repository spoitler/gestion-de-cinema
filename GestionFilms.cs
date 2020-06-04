using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace ppeEntityWpf
{
    class GestionFilms
    {

        private Context context = new Context();

        public List<film> ChargerFilms()
        {
            return context.films.Include(a => a.realisateur).Include(a => a.acteurs).ToList();
        }

        public film AjouterFilm(film film)
        {
            if (film == null)
                return null;

            context.films.Add(film);

            return context.SaveChanges() > 0 ? film : null;
        }

        public bool SupprimerFilm(film film)
        {
            if (film == null)
                return false;

            context.films.Remove(film);

            return context.SaveChanges() > 0;
        }

        public bool ModifierFilm(film film)
        {
            if (film == null)
                return false;

            context.Entry(film).State = EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool SupprimerFilm(int id)
        {

            film film = RechercherFilm(id);

            context.films.Remove(film);

            return (context.SaveChanges() > 0) ? true : false;
        }

        public film RechercherFilm(int id)
        {
            film film = context.films.Find(id);

            return film ?? null;
        }

        public acteur RechercherAct(int id)
        {
            acteur acteur = context.acteurs.Find(id);

            return acteur ?? null;
        }

        public genre RechercherGenre(int id)
        {
            genre genre = context.genres.Find(id);

            return genre ?? null;
        }
    }
}
