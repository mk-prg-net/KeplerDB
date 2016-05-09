using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using SP = KeplerBI.SpaceShips;


namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public abstract class CreateSpaceShip : FSM.NormalState<CreateSpaceShip.Inputs>
    {
        public enum Inputs
        {
            Satellite,
            MannedSpacecraft,
            Cancel
        }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new DescribeSatellite(), new DescribeMannedSpacecraft(), new SPCancel() }; }
        }

        // Klassenfabriken
        protected abstract SP.ISpaceShip CreateSatellite();
        protected abstract SP.IMannedSpacecraft CreateMannedSpacecraft();

        // Werkzeug zum zusammenbauen (aggregieren) von Raumschiffen
        protected abstract SpaceShipAssembler SpaceShipAssembler { get; }

        public override FSM.State Transition(Inputs input)
        {
            switch (input)
            {
                case Inputs.Satellite:
                    return new DescribeSatellite(CreateSatellite(), SpaceShipAssembler);
                case Inputs.MannedSpacecraft:
                    return new DescribeMannedSpacecraft(CreateMannedSpacecraft(), SpaceShipAssembler);
                case Inputs.Cancel:
                    return new SPCancel();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
