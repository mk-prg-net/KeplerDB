using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class SPCancel : FSM.FinalState<SPCancel.Inputs>
    {
        public enum Inputs
        {
            Ok
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
