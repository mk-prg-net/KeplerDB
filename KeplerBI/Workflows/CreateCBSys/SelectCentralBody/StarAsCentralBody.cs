using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCBSys.SelectCentralBody
{
    public class StarAsCentralBody : FSM.State
    {
        public StarAsCentralBody() : base(FSM.State.CreateNormalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new Start.Start(), new SelectSatellite.SatellitesOfStar(), new Cancel(), new Error() }; }
        }
    }

    public abstract class StarAsCentralBodyContext : StarAsCentralBody
    {
        /// <summary>
        /// Liste aller auswählbaren Planeten
        /// </summary>
        public abstract mko.BI.Repositories.BoCoBase<NaturalCelesticalBodies.IStar, string> Stars { get; }
    }

    /// <summary>
    /// 
    /// </summary>
    public abstract class StarAsCentralBodySTF : FSM.IStateTransistion<StarAsCentralBodyContext, SelectCentralBody.Input>
    {


        public class InputStar : SelectCentralBody.Input
        {
            public InputStar(NaturalCelesticalBodies.IStar Star)
            {
                Tag = Tags.CentralBody;
                StarAsCentralBody = Star;
            }
            public NaturalCelesticalBodies.IStar StarAsCentralBody { get; set; }
        }


        public abstract SelectSatellite.SatellitesOfStar CreateSatellitesOfStarContext(NaturalCelesticalBodies.IStar Star);

        public FSM.State Transition(StarAsCentralBodyContext ActiveState, SelectCentralBody.Input input)
        {
            switch (input.Tag)
            {
                case Input.Tags.Start:
                    return new Start.Start();
                case Input.Tags.Cancel:
                    return new Cancel();
                case Input.Tags.CentralBody:
                    {
                        return CreateSatellitesOfStarContext(((InputStar)input).StarAsCentralBody);
                    }
                default:
                    return new ErrorContext() { FaultyState = ActiveState };
            }
        }

    }
}
