using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;
using SP = KeplerBI.SpaceShips;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public class DescribeMannedSpacecraft : FSM.NormalState<DescribeMannedSpacecraft.Input>
    {
        public class Input
        {
            public Input()
            {
                Cancel = false;
            }
            public bool Cancel { get; set; }
            public int CrewSize { get; set; }
            public SP.Application[] AreasOfApplication { get; set; }
            public ICountry Homeland { get; set; }
        }

        public DescribeMannedSpacecraft() { }

        protected SP.IMannedSpacecraft _mannedSpacecraft;
        public SP.IMannedSpacecraft Satelitte
        {
            get
            {
                return _mannedSpacecraft;
            }
        }


        SpaceShipAssembler assembler;

        public DescribeMannedSpacecraft(SP.IMannedSpacecraft spaceShip, SpaceShipAssembler assembler)
        {
            this._mannedSpacecraft = spaceShip;
            this.assembler = assembler;
        }


        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new SPFinalMannedSpaceShip(), new SPCancel() }; }
        }

        public override FSM.State Transition(Input input)            
        {
            if (input.Cancel)
                return new SPCancel();
            else
            {                
                try
                {
                    _mannedSpacecraft.CrewSize = input.CrewSize;
                    assembler.SetAreasOfApplication(_mannedSpacecraft, input.AreasOfApplication);
                    assembler.SetHomeland(_mannedSpacecraft, input.Homeland);
                    return new SPFinalMannedSpaceShip(_mannedSpacecraft);
                }
                catch (Exception ex)
                {
                    return new SPErr(ex);
                }                
            }
        }
    }
}
