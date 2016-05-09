using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI
{
    public interface ICountry
    {
        int ID { get; set; }

        /// <summary>
        /// Länderkennzeichen, bestehend aus zwei Buchstaben. Definiert in ISO 3166-1
        /// </summary>
        string ISO_3166_1_Key{get;set;}

        string Description {get;set;}

    }
}
