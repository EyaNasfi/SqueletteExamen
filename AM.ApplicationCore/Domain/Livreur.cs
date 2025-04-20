using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Livreur
    {
        [Key]
        public string CIN { get; set; }
        public string CodePostal { get; set; }
        public string RaisonSocial { get; set; }
        public string Ville { get; set; }
        public virtual IList<Vehicule> Vehicules { get; set; }
        public virtual IList<Colis> Colis { get; set; }

    }
}
