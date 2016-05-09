using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro.inMem
{
    public class Stern : Astro.Stern
    {
        public Stern(string Name, double Masse_in_kg, Astro.Licht.ISpektralklasse Spektralklasse, double Leuchtkraft)
        {
            _Masse_in_kg = Masse_in_kg;
            _Spektralklasse = Spektralklasse;
            _Leuchtkraft = Leuchtkraft;
        }

        public override double Leuchtkraft_in_Lsonne
        {
            get { return Leuchtkraft_in_Lsonne; }
        }
        double _Leuchtkraft;

        public override Astro.Licht.ISpektralklasse Spektralklasse
        {
            get { return _Spektralklasse; }
        }
        Astro.Licht.ISpektralklasse _Spektralklasse;


        public override Astro.Galaxie Heimatgalaxie
        {
            get { throw new NotImplementedException(); }
        }


        public override string Name
        {
            get { return _Name; }
        }
        string _Name;

        protected override double BerechneMasseInKg()
        {
            return _Masse_in_kg;
        }
        double _Masse_in_kg;
    }
}
