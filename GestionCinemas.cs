using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppeEntityWpf
{
    class GestionCinemas
    {
        private Context context = new Context();

        public List<cinema> ChargerCinemas()
        {
            return context.cinemas.Include(a => a.films).Include(a => a.ville).ToList();
        }

        public cinema AjouterCinema(cinema cinema)
        {
            if (cinema == null)
                return null;

            context.cinemas.Add(cinema);

            return context.SaveChanges() > 0 ? cinema : null;
        }

        public bool SupprimerCinema(cinema cinema)
        {
            if (cinema == null)
                return false;

            context.cinemas.Remove(cinema);

            return context.SaveChanges() > 0;
        }

        public bool ModifierCinema(cinema cinema)
        {
            if (cinema == null)
                return false;

            context.Entry(cinema).State = EntityState.Modified;

            return context.SaveChanges() > 0;
        }

        public bool SupprimerCinema(int id)
        {

            cinema cinema = RechercherCinema(id);

            context.cinemas.Remove(cinema);

            return (context.SaveChanges() > 0) ? true : false;
        }

        public cinema RechercherCinema(int id)
        {
            cinema cinema = context.cinemas.Find(id);

            return cinema ?? null;
        }

        public film RechercherFilm(int id)
        {
            film film = context.films.Find(id);

            return film ?? null;
        }
    }
}
