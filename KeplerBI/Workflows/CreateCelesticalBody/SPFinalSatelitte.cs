using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using SP = KeplerBI.SpaceShips;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class SPFinalSatelitte : FSM.FinalState<SPFinalSatelitte.Inputs>
    {
        public enum Inputs
        {
            Ok
        }

        public SPFinalSatelitte() { }

        public SPFinalSatelitte(SP.ISpaceShip Satellite)
        {
            _spaceship = Satelitte;
        }

        protected SP.ISpaceShip _spaceship;
        public SP.ISpaceShip Satelitte
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
