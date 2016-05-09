using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCBSys.SelectCentralBody
{
    public class PlanetAsCentralBody : FSM.State
    {
        public PlanetAsCentralBody() : base(FSM.State.CreateNormalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new Start.Start(), new SelectSatellite.SatellitesOfPlanet(), new Cancel(), new Error() }; }
        }
    }

    public abstract class PlanetAsCentralBodyContext : PlanetAsCentralBody
    {
        /// <summary>
        /// Liste aller auswählbaren Planeten
        /// </summary>
        public abstract NaturalCelesticalBodies.Repositories.PlanetsCo Planets { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class PlanetAsCentralBodySTF : FSM.IStateTransistion<PlanetAsCentralBodyContext, SelectCentralBody.Input>
    {


        public class InputPlanet : SelectCentralBody.Input
        {
            public InputPlanet(NaturalCelesticalBodies.IPlanet Planet)
            {
                Tag = Tags.CentralBody;
                PlanetAsCentralBody = Planet;
            }
            public NaturalCelesticalBodies.IPlanet PlanetAsCentralBody { get; set; }
        }


        public abstract SelectSatellite.SatellitesOfPlanet CreateSatellitesOfPlanetContext(NaturalCelesticalBodies.IPlanet Planet);

        public FSM.State Transition(PlanetAsCentralBodyContext ActiveState, SelectCentralBody.Input input)
        {
            switch (input.Tag)
            {
                case Input.Tags.Start:
                    return new Start.Start();
                case Input.Tags.Cancel:
                    return new Cancel();
                case Input.Tags.CentralBody:
                    {
                        return CreateSatellitesOfPlanetContext(((InputPlanet)input).PlanetAsCentralBody);
                    }
                default:
                    return new ErrorContext() { FaultyState = ActiveState };
            }
        }

    }
}
