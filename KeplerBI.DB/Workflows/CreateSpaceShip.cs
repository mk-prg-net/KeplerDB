using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBISpaceShips = KeplerBI.SpaceShips;

namespace KeplerBI.DB.Workflows
{
    public class CreateSpaceShip : KeplerBI.Workflows.CreateCelesticalBody.CreateSpaceShip
    {
        protected override KBISpaceShips.ISpaceShip CreateSatellite()
        {
            return new SpaceShips.SpaceShip();
        }

        protected override KBISpaceShips.IMannedSpacecraft CreateMannedSpacecraft()
        {
            return new SpaceShips.MannedSpacecraft();
        }

        SpaceShipAssembler assembler = new SpaceShipAssembler();

        protected override KeplerBI.Workflows.CreateCelesticalBody.SpaceShipAssembler SpaceShipAssembler
        {
            get { return assembler; }
        }
    }
}
