using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using NCB = KeplerBI.NaturalCelesticalBodies;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeGalaxyCore : FSM.NormalState<DescribeGalaxyCore.Inputs>
    {
        public enum Inputs
        {
            ok,
            cancel
        }

        public DescribeGalaxyCore() { }

        protected NCB.IGalaxyCore _galaxyCore;
        public NCB.IGalaxyCore Galaxy
        {
            get
            {
                return _galaxyCore;
            }
        }

        public DescribeGalaxyCore(NCB.IGalaxyCore galaxyCore)
        {
            this._galaxyCore = galaxyCore;
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
                    return new NCBFinal(_galaxyCore);
                default:
                    throw new ArgumentException();

            }
        }
    }
}
