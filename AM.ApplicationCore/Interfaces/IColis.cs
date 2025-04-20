using AM.ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Interfaces
{
    public interface IColis:IService<Colis>
    {
        IList<Colis> GetColisByLivreur(Livreur li);
        public double getpoidsColis(Livreur l);
         IEnumerable<Vehicule> GetVehicules(Livreur livreur);

    }
}
