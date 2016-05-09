using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.NaturalCelesticalBodies
{
    public interface IStar : INaturalCelesticalBody
    {
        SpectralClasses SpectralClass { get; set; }
    }
}
