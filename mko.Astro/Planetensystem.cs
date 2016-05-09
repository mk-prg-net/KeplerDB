using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro
{
    public abstract class Planetensystem : Stern
    {
        /// <summary>
        /// Stern bzw. Doppelsternsystem, um den die Planeten kreisen
        /// </summary>
        public abstract Stern Zentralkoerper { get; }

        public override string Name
        {
            get { return Zentralkoerper.Name + "- System"; }
        }

        /// <summary>
        /// Liste aller Planeten, die den Stern umkreisen
        /// </summary>
        public abstract IEnumerable<Planet> Planeten { get; }

        /// <summary>
        /// Masse eines Planetensystems ist die Summe der Massen der Planeten und seines Sterns 
        /// </summary>
        /// <returns></returns>
        protected override double BerechneMasseInKg()
        {
            double Masse = 0.0;
            foreach (var planet in Planeten)
            {
                Masse += planet.Masse_in_kg;
            }

            return Masse + Zentralkoerper.Masse_in_kg;
        }


        public override Licht.ISpektralklasse Spektralklasse
        {
            get { return Zentralkoerper.Spektralklasse; }
        }

        public override Galaxie Heimatgalaxie
        {
            get { return Zentralkoerper.Heimatgalaxie; }
        }

        public override double Leuchtkraft_in_Lsonne
        {
            get { return Zentralkoerper.Leuchtkraft_in_Lsonne; }
        }
    }
}
