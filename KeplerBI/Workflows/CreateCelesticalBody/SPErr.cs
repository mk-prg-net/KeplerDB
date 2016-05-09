using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class SPErr : FSM.FinalState<SPErr.Inputs>
    {
        public enum Inputs {
            ok
        }

        public string ErrMsg { get; set; }

        public SPErr() { }

        public SPErr(string ErrMsg)
        {
            this.ErrMsg = ErrMsg;
        }

        public SPErr(Exception ex)
        {
            this.ErrMsg = mko.ExceptionHelper.FlattenExceptionMessages(ex);
        }

        public override FSM.State Transition(SPErr.Inputs input)
        {
            throw new NotImplementedException();
        }

        public override FSM.State[] Next
        {
            get { throw new NotImplementedException(); }
        }
    }
}
