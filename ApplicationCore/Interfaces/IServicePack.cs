using ApplicationCore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Interfaces
{
    public interface IServicePack:IService<Pack>
    {
        double PrixPAck(Pack p);

        int LongPacks();
    }
}
