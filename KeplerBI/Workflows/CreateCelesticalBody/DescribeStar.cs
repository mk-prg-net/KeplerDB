using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeStar : FSM.NormalState<DescribeStar.Inputs>
    {
        public enum Inputs
        {
            ok,
            cancel
        }

        public DescribeStar() { }

        protected NCB.IStar _star;
        public NCB.IStar Star
        {
            get
            {
                return _star;
            }
        }

        public DescribeStar(NCB.IStar star)
        {
            this._star = star;
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
                    return new NCBFinal(_star);
                default:
                    throw new ArgumentException();

            }
        }
    }
}
