using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    /// <summary>
    /// Datensatz für die Konfiguration eines Filters/Sortierterms. Wirds durch evaluieren von Konfigurationskommandos gewonnen.    
    /// </summary>
    public class ConfigDataToken : mko.RPN.FunctionNameToken
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ConfigCmdName">Name der Funktion. Dieser wird um "ConfigCmd" erweitert</param>
        public ConfigDataToken(string ConfigCmdName)
            : base(ConfigCmdName + "ConfigData", -1)
        {
            _Name = ConfigCmdName;
        }

        /// <summary>
        /// Name des Konfigurationskommandos.
        /// </summary>
        public string ConfigCmdName
        {
            get
            {
                return _Name;
            }
        }
        string _Name;


    }
}
