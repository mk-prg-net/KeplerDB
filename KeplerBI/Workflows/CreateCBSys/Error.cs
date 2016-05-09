using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCBSys
{
    public class Error : FSM.State    {

        public Error() : base(FSM.State.CreateFinalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { throw new NotImplementedException(); }
        }
    }


    public class ErrorContext : Error
    {
        public Exception Exception { get; set; }

        public string ErrorDescription { get; set; }

        public FSM.State FaultyState { get; set; }
    }


}
