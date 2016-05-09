using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro.inMem
{
    public class Galaxie : Astro.Galaxie
    {
        public override IEnumerable<mko.Astro.Stern> Sterne
        {
            get { return _Sterne; }
        }
        List<Astro.Stern> _Sterne = new List<Astro.Stern>();

        public override string Name
        {
            get { return _Name; }
        }
        string _Name;

        public override void Add(Astro.Stern stern)
        {
            _Sterne.Add(stern);
        }

        public override void Remove(Astro.Stern stern)
        {
            _Sterne.Remove(stern);
        }
    }
}
