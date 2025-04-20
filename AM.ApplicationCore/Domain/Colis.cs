using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Colis
    {
        public DateTime DateLivraison { get; set; }
        public double Montant { get; set; }
        public double Poids { get; set; }
        public string image { get; set; }
        public double  Volume { get; set; }
        [ForeignKey("LivreurFk")]
        public virtual Livreur Livreur { get; set; }
        [ForeignKey("ClientFk")]

        public virtual Client Client { get; set; }
        public string LivreurFk { get; set; }
        public int ClientFk { get; set; }
    }
}
