using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribePlanet : FSM.NormalState<DescribePlanet.Inputs>
    {
        public enum Inputs
        {
            ok,
            cancel
        }

        public DescribePlanet() { }

        protected NCB.IPlanet _planet;
        public NCB.IPlanet Planet
        {
            get
            {
                return _planet;
            }
        }

        public DescribePlanet(NCB.IPlanet planet)
        {
            this._planet = planet;
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
                    return new NCBFinal(_planet);
                default:
                    throw new ArgumentException();

            }
        }
    }
}
