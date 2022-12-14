using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Domain
{
    public class Client
    {
        [Key]
        public int Identifiant { get; set; }
        public String Photo { get; set; }

        [Required(ErrorMessage ="login obligatoire")]
        public String Login { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "password obligatoire")]
        public String Password { get; set; }

        public virtual ICollection<Reservation> Reservations { get; set; }

        public virtual Conseiller Conseiller { get; set; }
       // [ForeignKey("Conseriller")]
        public int ConserillerFK { get; set; }

    }
}
