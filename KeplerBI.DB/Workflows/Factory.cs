using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows
{
    public class Factory : KeplerBI.Workflows.CreateCelesticalBody.AbstractFactory
    {
        public override KeplerBI.Workflows.CreateCelesticalBody.CreateNCB NewCreateNCB()
        {
            return new CreateNCB();
        }

        public override KeplerBI.Workflows.CreateCelesticalBody.CreateSpaceShip NewCreateSpaceShip()
        {
            return new CreateSpaceShip();
        }
    }
}
