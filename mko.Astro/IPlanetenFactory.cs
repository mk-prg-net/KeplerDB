using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro
{
    public interface IPlanetenFactory
    {
        Planet Create(Stern zentralstern, string name, double masse_in_kg);

        Mondsystem CreateMondsystem(Planet zentralkoerper, IEnumerable<Mond> monde);
    }
}
