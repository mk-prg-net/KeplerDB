
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro
{
    public abstract class Galaxie : Himmelskoerper        
    {
        /// <summary>
        /// 1:n Beziehung zwischen Galaxie und Sterne:
        /// Verweist auf alle Sterne einer Galaxie
        /// </summary>
        public abstract IEnumerable<Stern> Sterne { get; }

        /// <summary>
        /// Galaxie um einen Stern bereichnern
        /// </summary>
        /// <param name="stern"></param>
        public abstract void Add(Stern stern);

        /// <summary>
        /// Einen Stern, der die Galaxie verlassen hat, aus dieser ausbuchen
        /// </summary>
        /// <param name="stern"></param>
        public abstract void Remove(Stern stern);

        protected override double BerechneMasseInKg()
        {
            double Masse = 0.0;
            foreach (var stern in Sterne)
            {
                Masse += stern.Masse_in_kg;
            }

            return Masse;
        }
        
    }
}
