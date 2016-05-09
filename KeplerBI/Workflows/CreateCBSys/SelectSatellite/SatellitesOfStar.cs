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
    public class SatellitesOfStar : FSM.State
    {

        public SatellitesOfStar() : base(FSM.State.CreateNormalStateBehavior()) { }

        public override FSM.State[] Next
        {
            get { return new FSM.State[] { new SatellitesOfStar(), new Save.SaveNewCBSys(), new Cancel(), new Error() }; }
        }
    }

    /// <summary>
    /// Spezialisierter SelectSatellite- Zustand. Enthält das zu konstruierenden Himmelskörpersystem
    /// </summary>
    public abstract class SatellitesOfStarContext : SatellitesOfStar, IContext
    {
        ContextCore _Core;
        public ContextCore Core { get { return _Core; } }

        protected abstract ContextCore CreateCore(NaturalCelesticalBodies.INaturalCelesticalBody NCB);

        public SatellitesOfStarContext(NaturalCelesticalBodies.INaturalCelesticalBody NCB)
        {
            _Core = CreateCore(NCB);
        }

        /// <summary>
        /// Liste aller möglichen Raumschiffe als Satelliten
        /// </summary>
        public abstract mko.BI.Repositories.BoCoBase<SpaceShips.ISpaceShip, string> SpaceShips { get; }

        /// <summary>
        /// Liste aller möglichen Asteroiden als Satelliten
        /// </summary>
        public abstract mko.BI.Repositories.BoCoBase<NaturalCelesticalBodies.IAsteroid, string> Asteroids { get; }

        /// <summary>
        /// Liste aller möglichen Kometen als Satelliten
        /// </summary>
        public abstract mko.BI.Repositories.BoCoBase<NaturalCelesticalBodies.IComet, string> Comets { get; }

        /// <summary>
        /// Liste aller möglichen Planeten als Satelliten
        /// </summary>
        public abstract NaturalCelesticalBodies.Repositories.PlanetsCo Planets { get; }



    }

    /// <summary>
    /// Zustandsübergangsfunktion für SelectSatellite- Zustand
    /// </summary>
    public abstract class SatellitesOfStarSTF : STFCore<SatellitesOfStarContext>
    {
        protected override FSM.State SelectSatelliteTransistion(SatellitesOfStarContext ActiveState, IOrbit orbit)
        {
            if (orbit.Satellite is SpaceShips.ISpaceShip || orbit.Satellite is NaturalCelesticalBodies.IAsteroid || orbit.Satellite is NaturalCelesticalBodies.IComet || orbit.Satellite is NaturalCelesticalBodies.IPlanet)
            {
                // Satelliten dem neu zu erstellenden Himmelskörpersystem hinzufügen
                ActiveState.Core.CBSys.AddSatelliteOrbit(orbit);

                // Neu erstelltes Himmelskörpersystem an den Context des nächsten Zustandes übergeben.
                return ActiveState;
            }
            else
            {
                return new ErrorContext() { FaultyState = ActiveState, ErrorDescription = "Einem Stern darf nur ein Raumschiff, Asteroiden, Kometen oder Planetenorbit hinzugefügt werden." };
            }
        }
    }
}
