using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using KeplerBI.SpaceShips;

namespace KeplerBI.Workflows.CreateCelesticalBody
{
    public abstract class SpaceShipAssembler
    {
        
        /// <summary>
        /// Fügt dem Raumschiff neue Anwendungsgebiete hinzu
        /// </summary>
        /// <param name="SpaceShip"></param>
        /// <param name="AreasOfApplication"></param>
        /// <returns></returns>
        public abstract void SetAreasOfApplication(ISpaceShip SpaceShip, IEnumerable<Application> AreasOfApplication);

        /// <summary>
        /// Definiert für ein Raumschiff ein Heimatland
        /// </summary>
        /// <param name="SpaceShip"></param>
        /// <param name="Homeland"></param>
        /// <returns></returns>
        public abstract void SetHomeland(ISpaceShip SpaceShip, ICountry Homeland);


    }
}
