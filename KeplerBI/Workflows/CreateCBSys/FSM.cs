using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCBSys
{

    public abstract class FinitStateMachine : mko.Algo.Automaton.StateMachine.FinitStateMachine<StateFactory>
    {
        /// <summary>
        /// Startzustand
        /// </summary>
        public Start.Start ActiveStateAsStart
        {
            get
            {
                return CastToExpectedStateType<Start.Start>();
            }
        }

        // Auswahl eines Zentralkörpers

        public SelectCentralBody.MoonAsCentralBodyContext ActiveStateAsMoonAsCentralBody
        {
            get
            {
                return CastToExpectedStateType<SelectCentralBody.MoonAsCentralBodyContext>();
            }
        }

        public SelectCentralBody.PlanetAsCentralBodyContext ActiveStateAsPlanetAsCentralBody
        {
            get
            {
                return CastToExpectedStateType<SelectCentralBody.PlanetAsCentralBodyContext>();
            }
        }

        public SelectCentralBody.StarAsCentralBodyContext ActiveStateAsStarAsCentralBody
        {
            get
            {
                return CastToExpectedStateType<SelectCentralBody.StarAsCentralBodyContext>();
            }
        }

        // Auswahl von Satelliten

        public SelectSatellite.SatellitesOfMoonContext ActiveStateAsSatellitesOfMoon
        {
            get
            {
                return CastToExpectedStateType<SelectSatellite.SatellitesOfMoonContext>();
            }
        }

        public SelectSatellite.SatellitesOfPlanetContext ActiveStateAsSatellitesOfPlanet
        {
            get
            {
                return CastToExpectedStateType<SelectSatellite.SatellitesOfPlanetContext>();
            }
        }

        public SelectSatellite.SatellitesOfStarContext ActiveStateAsSatellitesOfStar
        {
            get
            {
                return CastToExpectedStateType<SelectSatellite.SatellitesOfStarContext>();
            }
        }

        // 

        public Save.SaveNewCBSysContext ActiveStateAsSaveNewCBSys
        {
            get
            {
                return CastToExpectedStateType<Save.SaveNewCBSysContext>();
            }
        }


        public FinContext ActiveStateAsFin
        {
            get
            {
                return CastToExpectedStateType<FinContext>();
            }
        }

        public ErrorContext ActiveStateAsError
        {
            get
            {
                return CastToExpectedStateType<ErrorContext>();
            }
        }
    }
}
