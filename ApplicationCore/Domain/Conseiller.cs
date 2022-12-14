using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Conseiller
    {
        public int ConseillerId { get; set; }
        public String Nom { get; set; }

        public String Prenom { get; set; }

        public virtual ICollection<Client> Clients { get; set; }

    }
}
