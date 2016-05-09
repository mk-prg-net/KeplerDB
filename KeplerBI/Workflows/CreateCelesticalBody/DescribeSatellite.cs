using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using SP = KeplerBI.SpaceShips;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeSatellite : FSM.NormalState<DescribeSatellite.Input>
    {
        public class Input
        {
            public Input()
            {
                Cancel = false;
            }
            public bool Cancel { get; set; }

            public SP.Application[] AreasOfApplication { get; set; }
            public ICountry Homeland { get; set; }
        }

        public DescribeSatellite() { }

        protected SP.ISpaceShip _satellite;
        public SP.ISpaceShip Satellite
        {
            get
            {
                return _satellite;
            }
        }

        SpaceShipAssembler assembler;

        public DescribeSatellite(SP.ISpaceShip spaceShip, SpaceShipAssembler assembler)
        {
            this._satellite = spaceShip;
            this.assembler = assembler;
        }


        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new SPFinalSatelitte(), new SPCancel() }; }
        }

        public override FSM.State Transition(Input input)
        {
            try
            {
                if (input.Cancel)
                    return new SPCancel();
                else
                {
                    assembler.SetHomeland(_satellite, input.Homeland);
                    assembler.SetAreasOfApplication(_satellite, input.AreasOfApplication);
                    return new SPFinalSatelitte(_satellite);
                }
            }
            catch (Exception ex)
            {
                return new SPErr(ex);
            }
        }
    }
}
