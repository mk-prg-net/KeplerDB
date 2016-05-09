using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class NCBFinal : FSM.FinalState<NCBFinal.Inputs>
    {
        public enum Inputs
        {
            Ok
        }

        public NCBFinal() { }

        public NCBFinal(NCB.INaturalCelesticalBody ncb)
        {
            _ncb = ncb;
        }

        protected NCB.INaturalCelesticalBody _ncb;
        public NCB.INaturalCelesticalBody NCB
        {
            get
            {
                return _ncb;
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
