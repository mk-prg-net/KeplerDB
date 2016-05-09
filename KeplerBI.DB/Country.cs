using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public class Country : KeplerBI.ICountry
    {
        public virtual int ID { get; set; }

        /// <summary>
        /// Länderkennzeichen, bestehend aus zwei Buchstaben. Definiert in ISO 3166-1
        /// </summary>
        public virtual string ISO_3166_1_Key{get;set;}

        public virtual string Description {get;set;}

    }
}
