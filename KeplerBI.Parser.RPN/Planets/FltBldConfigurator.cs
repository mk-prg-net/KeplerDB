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
        List<ConfigCmdToken> configCmds = new List<ConfigCmdToken>();

        public FltBldConfigurator(Stack<mko.RPN.IToken> stack)
        {
            // Umkopieren, um richtige Ausführungsreihenfolge zu erhalten
            while (stack.Any())
            {
                configCmds.Insert(0,(ConfigCmdToken)stack.Pop());
            }
        }

        public void Apply(KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            // FilteredSortedSetBuilder über Kommandos konfigurieren

            foreach(var cmd in configCmds)
            {                
                cmd.ConfigBld(bld);
            }
        }


        public IEnumerable<ConfigCmdToken> ConfigCmds
        {
            get
            {
                return configCmds.ToArray();
            }
        }

    }
}
