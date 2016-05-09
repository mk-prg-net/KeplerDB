using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCBSys.SelectSatellite
{
    public class Input
    {
        public enum Tags
        {
            Cancel,
            finshSelection,
            SelectSatellite
        }

        public Tags Tag { get; set; }
    }

    /// <summary>
    /// Typ der möglichen Eingaben in diesem Zustand
    /// </summary>
    public class InputCancel : Input
    {
        public InputCancel()
        {
            Tag = Tags.Cancel;
        }
    }

    public class InputFinishSelection : Input
    {
        public InputFinishSelection()
        {
            Tag = Tags.finshSelection;
        }
    }

    public class InputSatelliteOrbit : Input
    {
        public IOrbit SatelliteOrbit { get; set; }

        public InputSatelliteOrbit(IOrbit Orbit)
        {
            Tag = Tags.SelectSatellite;
            SatelliteOrbit = Orbit;
        }
    }

}
