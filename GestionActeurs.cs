using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Metadata.Edm;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ppeEntityWpf
{
    class GestionActeurs
    {
        private Context context = new Context();

        public List<acteur> ChargerActeur()
        {
            return context.acteurs.ToList();
        }

        public acteur RechercherAct(int id)
        {
            acteur acteur = context.acteurs.Find(id);

            return acteur ?? null;
        }
    }
}
