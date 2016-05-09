using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FSM = mko.Algo.Automaton.StateMachine;


namespace KeplerBI.Workflows.CreateCBSys.SelectSatellite
{
    /// <summary>
    /// Zustand: Auswahl von Satelliten in einem Himmelskörpersystem
    /// </summary>
    public class SatellitesOfMoon : FSM.State
    {

        public SatellitesOfMoon() : base(FSM.State.CreateNormalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new SatellitesOfMoon(), new Save.SaveNewCBSys(), new Cancel(), new Error() }; }
        }
    }

    /// <summary>
    /// Spezialisierter SelectSatellite- Zustand. Enthält das zu konstruierenden Himmelskörpersystem
    /// </summary>
    public abstract class SatellitesOfMoonContext : SatellitesOfMoon, IContext
    {
        ContextCore _Core;
        public ContextCore Core { get { return _Core; } }

        protected abstract ContextCore CreateCore(NaturalCelesticalBodies.INaturalCelesticalBody NCB);

        public SatellitesOfMoonContext(NaturalCelesticalBodies.INaturalCelesticalBody NCB)
        {
            _Core = CreateCore(NCB);
        }

        /// <summary>
        /// Liste aller möglichen Satelliten (auf Raumschiffe eingeschränkt)
        /// </summary>
        public abstract mko.BI.Repositories.BoCoBase<SpaceShips.ISpaceShip, string> SpaceShips { get; }

    }

    /// <summary>
    /// Zustandsübergangsfunktion für SelectSatellite- Zustand
    /// </summary>
    public abstract class SatellitesOfMoonSTF : STFCore<SatellitesOfMoonContext>
    {
        protected override FSM.State SelectSatelliteTransistion(SatellitesOfMoonContext ActiveState, IOrbit orbit)
        {
            if (orbit.Satellite is SpaceShips.ISpaceShip)
            {
                // Satelliten dem neu zu erstellenden Himmelskörpersystem hinzufügen
                ActiveState.Core.CBSys.AddSatelliteOrbit(orbit);

                // Neu erstelltes Himmelskörpersystem an den Context des nächsten Zustandes übergeben.
                return ActiveState;
            }
            else
            {
                return new ErrorContext() { FaultyState = ActiveState, ErrorDescription = "Einem Mond darf nur ein Raumschifforbit hinzugefügt werden." };
            }
        }
    }
}
