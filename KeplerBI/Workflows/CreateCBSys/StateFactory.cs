using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCBSys
{
    public abstract class StateFactory
    {
        /// <summary>
        /// Startzustand
        /// </summary>
        /// <returns></returns>
        public Start.Start CreateStart()
        {
            return new Start.Start();
        }
        public abstract Start.StartSTF CreateStartSTF();


        /// <summary>
        /// Auswahl der Zentralkörper
        /// </summary>
        /// <returns></returns>
        public  SelectCentralBody.MoonAsCentralBody CreateMoonAsCentralBody()
        {
            return new SelectCentralBody.MoonAsCentralBody();
        }
        public abstract SelectCentralBody.MoonCentralBodySTF CreateMoonAsCentralBodySTF();



        public SelectCentralBody.PlanetAsCentralBody CreatePlanetAsCentralBody()
        {
            return new SelectCentralBody.PlanetAsCentralBody();
        }
        public abstract SelectCentralBody.PlanetAsCentralBodySTF CreatePlanetAsCentralBodySTF();
                
        public SelectCentralBody.StarAsCentralBody CreateStarAsCentralBody()
        {
            return new SelectCentralBody.StarAsCentralBody();
        }
        public abstract SelectCentralBody.StarAsCentralBodySTF CreateStarAsCentralBodySTF();



        /// <summary>
        /// Auswahl der Satelliten
        /// </summary>
        /// <returns></returns>
        public  SelectSatellite.SatellitesOfMoon CreateSatellitesOfMoon()
        {
            return new SelectSatellite.SatellitesOfMoon();
        }
        public abstract SelectSatellite.SatellitesOfMoonSTF CreateSatellitesOfMoonSTF();


        public SelectSatellite.SatellitesOfPlanet CreateSatellitesOfPlanet()
        {
            return new SelectSatellite.SatellitesOfPlanet();
        }
        public abstract SelectSatellite.SatellitesOfPlanetSTF CreateSatellitesOfPlanetSTF();


        public SelectSatellite.SatellitesOfStar CreateSatellitesOfStar()
        {
            return new SelectSatellite.SatellitesOfStar();
        }
        public abstract SelectSatellite.SatellitesOfStarSTF CreateSatellitesOfStarSTF();


        /// <summary>
        ///  Sichern des Systems
        /// </summary>
        /// <returns></returns>

        public  Save.SaveNewCBSys CreateSaveCBSys()
        {
            return new Save.SaveNewCBSys();
        }

        public Save.SaveNewCBSysSTF CreateSaveCBSysSTF()
        {
            return new Save.SaveNewCBSysSTF();
        }


        /// <summary>
        /// Ende des Workflows
        /// </summary>
        /// <returns></returns>
        public  Fin CreateFin()
        {
            return new Fin();
        }


        /// <summary>
        /// Abbruch des Workflows
        /// </summary>
        /// <returns></returns>
        public  Cancel CreateCancel()
        {
            return new Cancel();
        }



        /// <summary>
        /// Abbruch mit Fehler
        /// </summary>
        /// <returns></returns>
        public  Error CreateError()
        {
            return new Error();
        }

    }
}
