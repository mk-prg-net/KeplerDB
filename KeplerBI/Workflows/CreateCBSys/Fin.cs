using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;


namespace KeplerBI.Workflows.CreateCBSys
{
    public class Fin : FSM.State
    {
        public Fin() : base(FSM.State.CreateFinalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { throw new NotImplementedException(); }
        }
    }

    public class FinContext : Fin
    {
        ICelesticalBodySystem _CBSys;
        public ICelesticalBodySystem CBsys
        {
            get
            {
                return _CBSys;
            }
        }
        public FinContext(ICelesticalBodySystem CBsys)
        {
            _CBSys = CBsys;
        }

    }
}
