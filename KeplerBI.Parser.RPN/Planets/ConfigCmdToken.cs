using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN.Planets
{
    public abstract class ConfigCmdToken : mko.RPN.IToken
    {
        public ConfigCmdToken(int CountOfEvaluatedTokens)
        {
            _CountOfEvaluatedTokens = CountOfEvaluatedTokens;
        }

        public bool IsFunctionName
        {
            get { return false; }
        }

        public bool IsInteger
        {
            get { return false; }
        }

        public bool IsBoolean
        {
            get { return false; }
        }

        public bool IsNummeric
        {
            get { return false; }
        }

        public string Value
        {
            get { return GetType().Name; }
        }

        public abstract void ConfigBld(KeplerBI.NaturalCelesticalBodies.Repositories.IPlanetsCo_FilteredSortedSetBuilder bld);

        /// <summary>
        /// Stellt das Konfigurationskommando als RPN- String dar.
        /// </summary>
        /// <returns></returns>
        public abstract string ToRPNString();

        public int CountOfEvaluatedTokens
        {
            get
            {
                return _CountOfEvaluatedTokens;
            }
        }
        int _CountOfEvaluatedTokens;
    }
}
