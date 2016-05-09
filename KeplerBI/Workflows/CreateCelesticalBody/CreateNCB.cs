using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    /// <summary>
    /// Einen Planeten, Mond etc. erzeugen
    /// </summary>
    public abstract class CreateNCB : FSM.NormalState<CreateNCB.Inputs>
    {
        public override FSM.State[] Next
        {
            get
            {
                return new FSM.State[]{
                        new DescribeAsteroid(),
                        new DescribeBigBang(),
                        new DescribeGalaxy(),
                        new DescribeGalaxyCore(),
                        new DescribeMoon(),
                        new DescribeStar(),
                        new DescribePlanet(),
                        new DescribeComet()};
            }
        }

        public enum Inputs
        {
            Asteroid,
            BigBang,
            Comet,
            Planet,
            Star,
            Moon,
            Galaxy,
            GalaxyCore
        }

        // Klassenfabriken
        public abstract IAsteroid CreateAsteroid();
        public abstract IBigBang CreateBigBang();
        public abstract IComet CreateComet();
        public abstract IGalaxy CreateGalaxy();
        public abstract IGalaxyCore CreateGalaxyCore();
        public abstract IStar CreateStar();
        public abstract IMoon CreateMoon();
        public abstract IPlanet CreatePlanet();

        public override FSM.State Transition(Inputs input)
        {
            switch (input)
            {
                case Inputs.Asteroid:
                    return new DescribeAsteroid(CreateAsteroid());
                case Inputs.BigBang:
                    return new DescribeBigBang(CreateBigBang());
                case Inputs.Comet:
                    return new DescribeComet(CreateComet());
                case Inputs.Galaxy:
                    return new DescribeGalaxy(CreateGalaxy());
                case Inputs.GalaxyCore:
                    return new DescribeGalaxyCore(CreateGalaxyCore());
                case Inputs.Moon:
                    return new DescribeMoon(CreateMoon());
                case Inputs.Planet:
                    return new DescribePlanet(CreatePlanet());
                default:
                    return null;
            }
        }


        
    }
}
