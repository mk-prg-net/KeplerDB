using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCBSys
{
    public interface ICBSysDraft : ICelesticalBodySystem
    {
        /// <summary>
        /// Den Zentralkörper definieren
        /// </summary>
        /// <param name="centralBody"></param>
        void SetCentralBody(ICelestialBodyBase centralBody);

        /// <summary>
        /// Einen Satellit hinzufügen
        /// </summary>
        /// <param name="satellite"></param>
        void AddSatelliteOrbit(IOrbit satelliteOrbit);

        /// <summary>
        /// Entfernt den zuletzt dem Himmelkörpersystem hinzugefügten Satelliten aus diesem und gibt ihn zurück
        /// </summary>
        /// <returns></returns>
        IOrbit RemoveLastSatelliteOrbit();

        /// <summary>
        /// Alle zuvor gesetzten Satelliten wieder löschen
        /// </summary>
        void ClearSatelliteOrbits();
    }
}
