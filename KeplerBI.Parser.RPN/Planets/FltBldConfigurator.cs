using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    /// <summary>
    /// Geparste Konfigurationskommandos werden auf einen Planets.FilteredSortedSetBuilder angewendet
    /// 
    /// </summary>
    public class FltBldConfigurator
    {
        ConfigDataToken[] configDatas;

        public FltBldConfigurator(Stack<mko.RPN.IToken> stack)
        {
            // Umkopieren, um richtige Ausführungsreihenfolge zu erhalten
            configDatas = stack.ToArray().Select(t => (ConfigDataToken)t).ToArray();
            Array.Reverse(configDatas);
        }

        public void Apply(KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            // FilteredSortedSetBuilder über Kommandos konfigurieren

            foreach(var data in configDatas)
            {
                if (data is DiameterRngData)
                {
                    var tdata = (DiameterRngData)data;
                    bld.defAequatorialDiameterRange(mko.Newton.Length.Meter(tdata.min), mko.Newton.Length.Meter(tdata.max));
                }
                else if (data is MassRngData)
                {
                    var tdata = (MassRngData)data;
                    bld.defMassRange(mko.Newton.Mass.EarthMasses(tdata.minEM), mko.Newton.Mass.EarthMasses(tdata.maxEM));
                }
                else if (data is OrderByMassData)
                {
                    var tdata = (OrderByMassData)data;
                    bld.OrderByMass(tdata.descending);
                }
                else if (data is OrderBySemiMajorAxisLengthData)
                {
                    var tdata = (OrderBySemiMajorAxisLengthData)data;
                    bld.OrderBySemiMajorAxisLength(tdata.descending);
                }
                else if (data is SemiMajorAxisLengthRngData)
                {
                    var tdata = (SemiMajorAxisLengthRngData)data;
                    bld.defSemiMajorAxisLengthRange(mko.Newton.Length.Meter(tdata.Min), mko.Newton.Length.Meter(tdata.Max));
                }                
            }
        }
    }
}
