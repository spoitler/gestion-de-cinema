using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppeEntityWpf
{
    class GestionReal
    {

        private Context context = new Context();

        public List<realisateur> ChargerReal()
        {
            return context.realisateurs.ToList();
        }
    }
}
