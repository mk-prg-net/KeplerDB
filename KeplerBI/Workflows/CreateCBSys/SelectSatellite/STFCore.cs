using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;


namespace KeplerBI.Workflows.CreateCBSys.SelectSatellite
{
    public abstract class STFCore<TContext> : FSM.IStateTransistion<TContext, SelectSatellite.Input>
        where TContext : FSM.State, IContext
    {
        protected abstract Save.SaveNewCBSysContext CreateSaveNewCBsysContext(ICelesticalBodySystem CBSys);

        protected abstract FSM.State SelectSatelliteTransistion(TContext ActiveState, IOrbit orbit);

        public FSM.State Transition(TContext ActiveState, Input input)
        {
            switch (input.Tag)
            {
                case Input.Tags.Cancel:
                    return new Cancel();
                case Input.Tags.finshSelection:
                    {
                        return CreateSaveNewCBsysContext(ActiveState.Core.CBSys);
                    }
                case Input.Tags.SelectSatellite:
                    {
                        // Nur Monde sind als Satelliten zugelassen
                        var orbit = ((InputSatelliteOrbit)input).SatelliteOrbit;
                        return SelectSatelliteTransistion(ActiveState, orbit);
                    }
                default:
                    return new ErrorContext() { FaultyState = ActiveState, ErrorDescription = "Hinzuzufügender Satellitenorbit fehlt!" };

            }
        }
    }
}
