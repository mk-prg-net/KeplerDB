using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeComet : FSM.NormalState<DescribeComet.Inputs>
    {
        public enum Inputs
        {
            ok,
            cancel
        }

        public DescribeComet() { }

        protected NCB.IComet _comet;
        public NCB.IComet Comet
        {
            get
            {
                return _comet;
            }
        }

        public DescribeComet(NCB.IComet comet)
        {
            this._comet = comet;
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
                    return new NCBFinal(_comet);
                default:
                    throw new ArgumentException();

            }
        }
    }
}
