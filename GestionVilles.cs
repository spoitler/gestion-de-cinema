using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppeEntityWpf
{
    class GestionVilles
    {

        private Context context = new Context();

        public List<ville> ChargerVilles()
        {
            return context.villes.ToList();
        }
    }
}
