using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;


namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class Start : FSM.StartState<Start.Inputs>
    {
        public enum Inputs
        {
            CreateSpaceShip,
            CreateNCB
        }

        AbstractFactory Factory;
        public Start(AbstractFactory Factory)
        {
            this.Factory = Factory; 
        }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { Factory.NewCreateNCB(), Factory.NewCreateSpaceShip() }; }
        }

        public override FSM.State Transition(Inputs input)
        {
            switch (input)
            {
                case Inputs.CreateNCB:
                    return Factory.NewCreateNCB();
                case Inputs.CreateSpaceShip:
                    return Factory.NewCreateSpaceShip();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
