using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppeEntityWpf
{
    class GestionGenres
    {

        private Context context = new Context();

        public List<genre> ChargerGenres()
        {
            return context.genres.ToList();
        }

        public genre RechercherGenre(int id)
        {
            genre genre = context.genres.Find(id);

            return genre ?? null;
        }
    }
}
