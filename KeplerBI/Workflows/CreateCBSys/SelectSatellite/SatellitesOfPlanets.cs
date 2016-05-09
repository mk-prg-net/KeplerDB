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
    public class SatellitesOfPlanet : FSM.State
    {

        public SatellitesOfPlanet() : base(FSM.State.CreateNormalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new SatellitesOfPlanet(), new Save.SaveNewCBSys(), new Cancel(), new Error() }; }
        }
    }

    /// <summary>
    /// Spezialisierter SelectSatellite- Zustand. Enthält das zu konstruierenden Himmelskörpersystem
    /// </summary>
    public abstract class SatellitesOfPlanetContext : SatellitesOfPlanet, IContext
    {
        ContextCore _Core;
        public ContextCore Core { get { return _Core; } }

        protected abstract ContextCore CreateCore(NaturalCelesticalBodies.INaturalCelesticalBody NCB);

        public SatellitesOfPlanetContext(NaturalCelesticalBodies.INaturalCelesticalBody NCB)
        {
            _Core = CreateCore(NCB);
        }

        /// <summary>
        /// Liste aller möglichen Raumschiffe als Satelliten
        /// </summary>
        public abstract mko.BI.Repositories.BoCoBase<SpaceShips.ISpaceShip, string> SpaceShips { get; }

        /// <summary>
        /// Liste aller möglichen Monde als Satelliten
        /// </summary>
        public abstract NaturalCelesticalBodies.Repositories.MoonsCo Moons { get; }



    }

    /// <summary>
    /// Zustandsübergangsfunktion für SelectSatellite- Zustand
    /// </summary>
    public abstract class SatellitesOfPlanetSTF : STFCore<SatellitesOfPlanetContext>
    {
        protected override FSM.State SelectSatelliteTransistion(SatellitesOfPlanetContext ActiveState, IOrbit orbit)
        {
            if (orbit.Satellite is SpaceShips.ISpaceShip || orbit.Satellite is NaturalCelesticalBodies.IMoon)
            {
                // Satelliten dem neu zu erstellenden Himmelskörpersystem hinzufügen
                ActiveState.Core.CBSys.AddSatelliteOrbit(orbit);

                // Neu erstelltes Himmelskörpersystem an den Context des nächsten Zustandes übergeben.
                return ActiveState;
            }
            else
            {
                return new ErrorContext() { FaultyState = ActiveState, ErrorDescription = "Einem Planeten darf nur ein Raumschifforbit oder ein Mondorbit hinzugefügt werden." };
            }
        }
    }


}
