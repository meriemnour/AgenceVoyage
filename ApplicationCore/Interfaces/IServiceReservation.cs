using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IServiceReservation:IService<Reservation>
    {
        double MontantTotal(Client c);
        int NbReservation(Client c);
    }
}
