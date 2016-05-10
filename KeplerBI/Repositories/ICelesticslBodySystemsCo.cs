using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IRepo = mko.BI.Repositories.Interfaces;

namespace KeplerBI.Repositories
{
    public interface ICelesticslBodySystemsCo : 
        IRepo.IGet<ICelesticalBodySystem, NaturalCelesticalBodies.INaturalCelesticalBody>
    {

    }    
}
