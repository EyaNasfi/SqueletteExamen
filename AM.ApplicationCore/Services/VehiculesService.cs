using AM.ApplicationCore.Domain;
using AM.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Services
{
    public class VehiculesService : Service<Vehicule>, IVehicule
    {
        public VehiculesService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Vehicule> getvehicules(Livreur l)
        {
            throw new NotImplementedException();
        }
    }
}
