using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCBSys
{
    public class Cancel : FSM.State
    {
        public Cancel() : base(FSM.State.CreateFinalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class CancelContext : Cancel
    {
        public FSM.State WorkflowAbortedInState { get; set; }
    }

}
