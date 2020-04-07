using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace ppeEntityWpf
{
    class GestionFilms
    {

        private ContextFilms context = new ContextFilms();

        public List<film> ChargerFilms()
        {
            return context.films.Include(a => a.realisateur).ToList();
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
    }
}
