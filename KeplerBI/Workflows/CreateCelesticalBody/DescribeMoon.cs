using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeMoon : FSM.NormalState<DescribeMoon.Inputs>
    {
        public enum Inputs
        {
            ok,
            cancel
        }

        public DescribeMoon() { }

        protected NCB.IMoon _moon;
        public NCB.IMoon Moon
        {
            get
            {
                return _moon;
            }
        }

        public DescribeMoon(NCB.IMoon moon)
        {
            this._moon = moon;
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
                    return new NCBFinal(_moon);
                default:
                    throw new ArgumentException();

            }
        }
    }
}
