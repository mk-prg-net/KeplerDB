using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeBigBang : FSM.NormalState<DescribeBigBang.Inputs>
    {
        public enum Inputs
        {
            ok,
            cancel
        }

        public DescribeBigBang() { }

        protected NCB.IBigBang _bigBang;
        public NCB.IBigBang BigBang
        {
            get
            {
                return _bigBang;
            }
        }

        public DescribeBigBang(NCB.IBigBang bigBang)
        {
            this._bigBang = bigBang;
        }


        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new NCBFinal(), new NCBFinal() }; }
        }

        public override FSM.State Transition(Inputs input)
       
        {
            switch (input)
            {
                case Inputs.cancel:
                    return new NCBCancel();
                case Inputs.ok:
                    return new NCBFinal(_bigBang);
                default:
                    throw new ArgumentException();

            }
        }
    }
}
