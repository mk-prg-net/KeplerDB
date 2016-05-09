using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using KBI = KeplerBI;
using KBISpaceShips = KeplerBI.SpaceShips;


namespace KeplerBI.DB.SpaceShips
{
    public class SpaceShip : CelestialBodyBase, KeplerBI.SpaceShips.ISpaceShip
    {
        public SpaceShip()
        {
            Type = CelesticalBodyType.SpaceShip;
        }

        public virtual double MassInKg { get; set; }
        public override mko.Newton.Mass Mass
        {
            get
            {
                return mko.Newton.Mass.Kilogram(MassInKg);
            }
            set
            {
                MassInKg = mko.Newton.Mass.Kilogram(value).Value;
            }
        }


        // Homeland aus Schnittstelle gibt ICountry zurück. Datenbank speichert in Country- Objekt.
        // => Für Datenbank muss zusätzliche Eigenschaft Country Homeland erzeugt werden.
        ICountry KBISpaceShips.ISpaceShip.Homeland {
            get
            {
                return Homeland;
            }
        }

        public virtual Country Homeland { get; set; }

        IEnumerable<KeplerBI.SpaceShips.Application> KBISpaceShips.ISpaceShip.AreasOfApplication
        {
            get
            {
                return Tasks.Select(e => (KBISpaceShips.Application)e.Application.ApplicationID).ToArray();
            }            
        }


        public virtual ICollection<SpaceshipTask> Tasks { get; set; }
        

    }
}
