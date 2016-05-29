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

        Stack<mko.RPN.IToken> stack;       

        public FltBldConfigurator(Stack<mko.RPN.IToken> stack)
        {
            this.stack = stack;            
        }

        public void Apply(KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld)
        {
            // Umkopieren, um richtige Ausführungsreihenfolge zu erhalten
            var stack2 = new Stack<ConfigCmdToken>();
            while (stack.Any())
            {
                stack2.Push((ConfigCmdToken)stack.Pop());
            }

            // FilteredSortedSetBuilder über Kommandos konfigurieren

            while (stack2.Any())
            {
                var configCmd = stack2.Pop();
                configCmd.ConfigBld(bld);
            }
        }     

    }
}
