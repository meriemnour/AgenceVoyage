using ApplicationCore.Domain;
using ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public class ServiceReservation : Service<Reservation>, IServiceReservation
    {
        public ServiceReservation(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public double MontantTotal(Client c)
        {
           return GetMany(r => r.ClientFK == c.Identifiant)
                .Select(r => r.Pack)
                .SelectMany(p => p.Activites)
                .Sum(a=>a.Prix);
        }

        public int NbReservation(Client c)
        {
            return GetMany(r => r.ClientFK == c.Identifiant && r.DateReservation.Year == DateTime.Now.Year).Count();
                
        }
    }
}
