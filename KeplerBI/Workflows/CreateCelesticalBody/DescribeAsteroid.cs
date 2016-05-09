using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeAsteroid : FSM.NormalState<DescribeAsteroid.Inputs>
    {
        public enum Inputs
        {
            ok,
            cancel
        }

        public DescribeAsteroid() { }

        protected NCB.IAsteroid _asteroid;
        public NCB.IAsteroid Asteroid
        {
            get
            {
                return _asteroid;
            }
        }

        public DescribeAsteroid(NCB.IAsteroid asteroid)
        {
            this._asteroid = asteroid; 
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
                    return new NCBFinal(_asteroid);
                default:
                    throw new ArgumentException();

            }
        }
    }
}
