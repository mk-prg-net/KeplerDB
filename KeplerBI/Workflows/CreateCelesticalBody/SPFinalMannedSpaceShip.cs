using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using SP = KeplerBI.SpaceShips;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class SPFinalMannedSpaceShip : FSM.FinalState<SPFinalMannedSpaceShip.Inputs>
    {
        public enum Inputs
        {
            Ok
        }

        public SPFinalMannedSpaceShip() { }

        public SPFinalMannedSpaceShip(SP.IMannedSpacecraft Satelitte)
        {
            _spaceship = Satelitte;
        }

        protected SP.IMannedSpacecraft _spaceship;
        public SP.IMannedSpacecraft MannedSpaceShip
        {
            get
            {
                return _spaceship;
            }
        }

        public override FSM.State[] Next
        {
            get { throw new NotImplementedException(); }
        }

        public override FSM.State Transition(Inputs input)
        {
            throw new NotImplementedException();
        }
    }
}
