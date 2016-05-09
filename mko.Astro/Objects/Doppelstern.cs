using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro.inMem
{
    // Dekorator implementieren
    public class Doppelstern : mko.Astro.Doppelstern
    {

        public Doppelstern(Astro.Stern A, Astro.Stern B)
        {
            _A = A;
            _B = B;
        }

        public override Astro.Stern A
        {
            get { return _A; }
        }
        Astro.Stern _A;


        public override Astro.Stern B
        {
            get { return _B; }
        }
        Astro.Stern _B;
    }
}
