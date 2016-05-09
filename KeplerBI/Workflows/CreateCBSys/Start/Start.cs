using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;

namespace KeplerBI.Workflows.CreateCBSys.Start
{
    public class Start : FSM.State
    {
        public Start() : base(FSM.State.CreateStartStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new Cancel(), new SelectCentralBody.MoonAsCentralBody() }; }
        }
    }    

    public abstract class StartSTF : FSM.IStateTransistion<Start, StartSTF.Inputs>
    {
        /// <summary>
        /// Menge der möglichen Eingaben
        /// </summary>
        public enum Inputs
        {
            SelectStarAsCentralBody,
            SelectPlanetAsCentralBody,
            SelectMoonAsCentralBody,
            Cancel
        }

        /// <summary>
        /// Klassenfabrit zum erstellen eines Objekts von der abstrakten Klasse SelectCentralBodyContext
        /// abgeleiteten Klasse.
        /// </summary>
        /// <returns></returns>
        protected abstract SelectCentralBody.MoonAsCentralBodyContext CreateSelectMoonAsCentralBodyContext();
        protected abstract SelectCentralBody.PlanetAsCentralBodyContext CreateSelectPlanetAsCentralBodyContext();
        protected abstract SelectCentralBody.StarAsCentralBodyContext CreateSelectStarAsCentralBodyContext();



        public FSM.State Transition(Start ActiveState, StartSTF.Inputs input)
        {
            switch (input)
            {
                case Inputs.Cancel:
                    return new CancelContext() {  WorkflowAbortedInState = ActiveState};
                case Inputs.SelectMoonAsCentralBody:
                    return CreateSelectMoonAsCentralBodyContext();
                case Inputs.SelectPlanetAsCentralBody:
                    return CreateSelectPlanetAsCentralBodyContext();
                case Inputs.SelectStarAsCentralBody:
                    return CreateSelectStarAsCentralBodyContext();
                default:
                    return new ErrorContext() { FaultyState = ActiveState, ErrorDescription="Unbekannte Eingabe" };

            }
        }
    }
}
