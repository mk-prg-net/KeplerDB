using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCBSys.SelectCentralBody
{
    public class MoonAsCentralBody : FSM.State
    {
        public MoonAsCentralBody() : base(FSM.State.CreateNormalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new SelectSatellite.SatellitesOfMoon(), new Cancel(), new Error(), new Start.Start() }; }
        }
    }

    public abstract class MoonAsCentralBodyContext : MoonAsCentralBody
    {
        /// <summary>
        /// Liste aller auswählbaren Monde
        /// </summary>
        public abstract KeplerBI.NaturalCelesticalBodies.Repositories.MoonsCo Moons { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class MoonCentralBodySTF : FSM.IStateTransistion<MoonAsCentralBodyContext, SelectCentralBody.Input>
    {


        public class InputMoon : SelectCentralBody.Input
        {
            public InputMoon(NaturalCelesticalBodies.IMoon Moon)
            {
                Tag = Tags.CentralBody;
                MoonAsCentralBody = Moon;
            }
            public NaturalCelesticalBodies.IMoon MoonAsCentralBody { get; set; }
        }


        public abstract SelectSatellite.SatellitesOfMoonContext CreateSatellitesOfMoonContext(NaturalCelesticalBodies.IMoon Moon);

        public FSM.State Transition(MoonAsCentralBodyContext ActiveState, SelectCentralBody.Input input)
        {
            switch (input.Tag)
            {
                case Input.Tags.Start:
                    return new Start.Start();
                case Input.Tags.Cancel:
                    return new Cancel();
                case Input.Tags.CentralBody:
                    {
                        return CreateSatellitesOfMoonContext(((InputMoon)input).MoonAsCentralBody);
                    }
                default:
                    return new ErrorContext() { FaultyState = ActiveState };
            }
        }

    }
}

