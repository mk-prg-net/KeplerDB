using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeGalaxy : FSM.NormalState<DescribeGalaxy.Inputs>
    {
        public enum Inputs
        {
            ok,
            cancel
        }

        public DescribeGalaxy() { }

        protected NCB.IGalaxy _galaxy;
        public NCB.IGalaxy Galaxy
        {
            get
            {
                return _galaxy;
            }
        }

        public DescribeGalaxy(NCB.IGalaxy galaxy)
        {
            this._galaxy = galaxy;
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
                    return new NCBFinal(_galaxy);
                default:
                    throw new ArgumentException();

            }
        }
    }
}
