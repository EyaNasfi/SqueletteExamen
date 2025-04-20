using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class ColisService : Service<Colis>, IColis
    {
        public ColisService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        /*
        public IList<Colis> GetColisByLivreur(Livreur li)
        {
            return  GetAll()
                .Where(p=>p.Livreur.Equals(li))
                .GroupBy(c=>c.Client)
                .SelectMany(p => p)
                .ToList();
        }*/
        public IEnumerable<IGrouping<Client, Colis>> GetColis(Livreur livreur)
        {
            //return unitOfWork.Repository<Colis>()
            //    .GetMany(e => e.MyLivreur.CIN == livreur.CIN)
            //    .GroupBy(e => e.ClientFK);

            return GetMany(e => e.Livreur.CIN == livreur.CIN)
                .GroupBy(e => e.Client);

        }
        public IEnumerable<Vehicule> GetVehicules(Livreur livreur)
        {
            var vehicules = new List<Vehicule>();

            double totalPoids = getpoidsColis(livreur);

            if (totalPoids < 50)
            {
                vehicules.AddRange(livreur.Vehicules.OfType<Voiture>());

            }
            else
            {
                vehicules.AddRange(livreur.Vehicules.OfType<Camion>().Take(5));
            }
            return vehicules;
        }
            public double getpoidsColis(Livreur l)
        {
            return GetAll().Where(p => p.Livreur.Equals(l) && (p.DateLivraison>DateTime.Now&& p.DateLivraison<=DateTime.Now.AddDays(7))).Sum(p => p.Poids);
        }

        IList<Colis> IColis.GetColisByLivreur(Livreur li)
        {
            throw new NotImplementedException();
        }
    }
}
