using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using KBINcb = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.DB.Workflows
{
    public class CreateNCB : KeplerBI.Workflows.CreateCelesticalBody.CreateNCB
    {
        public override KBINcb.IAsteroid CreateAsteroid()
        {
           return new NaturalCelesticalBodies.Asteroid();
        }

        public override KBINcb.IBigBang CreateBigBang()
        {
            return new NaturalCelesticalBodies.BigBang();
        }

        public override KBINcb.IComet CreateComet()
        {
            return new NaturalCelesticalBodies.Comet();
        }

        public override KBINcb.IGalaxy CreateGalaxy()
        {
            return new NaturalCelesticalBodies.Galaxy();
        }

        public override KBINcb.IGalaxyCore CreateGalaxyCore()
        {
            return new NaturalCelesticalBodies.GalaxyCore();
        }

        public override KBINcb.IStar CreateStar()
        {
            return new NaturalCelesticalBodies.Star();
        }

        public override KBINcb.IMoon CreateMoon()
        {
            return new NaturalCelesticalBodies.Moon();
        }

        public override KBINcb.IPlanet CreatePlanet()
        {
            return new NaturalCelesticalBodies.Planet();
        }
    }
}
