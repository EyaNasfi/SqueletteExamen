using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Vehicule
    {
        public string Couleur { get; set; }
        public string Marque { get; set; }
        [Key]

        public string  Matricule { get; set; }
        public int VitesseLimite { get; set; }
        public virtual IList<Livreur> Livreurs { get; set; }

    }
}
