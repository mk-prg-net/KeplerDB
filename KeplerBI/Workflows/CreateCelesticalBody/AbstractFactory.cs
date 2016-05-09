using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public abstract class AbstractFactory
    {

        public abstract CreateNCB NewCreateNCB();
        public abstract CreateSpaceShip NewCreateSpaceShip();       
       
    }
}
