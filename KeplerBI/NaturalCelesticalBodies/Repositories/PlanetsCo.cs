using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.NaturalCelesticalBodies.Repositories
{
    public abstract class PlanetsCo : mko.BI.Repositories.BoCoBase<IPlanet, string>
    {

        public PlanetsCo() : base(new SortName(false)) { }


        public class SortName : mko.BI.Repositories.DefSortOrderCol<IPlanet, string>
        {
            public SortName(bool Descending) : base(r => r.Name, Descending) { }
        }

        public class SortMass : mko.BI.Repositories.DefSortOrderCol<IPlanet, double>
        {
            public SortMass(bool Descending) : base(r => r.MassInEarthmasses, Descending) { }
        }


        //public abstract mko.Algo.Interval<double> DiameterFlt { get; set; }
        //public abstract bool DiameterFilterOn { get; set; }


        //public abstract mko.Algo.Interval<double> MassInEarthmassFlt { get; set; }
        //public abstract bool MassInEarthmassFilterOn { get; set; }

    }
}
