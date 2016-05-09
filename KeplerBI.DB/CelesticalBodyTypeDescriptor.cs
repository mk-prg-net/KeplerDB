using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public class CelesticalBodyTypeDescriptor
    {
        /// <summary>
        /// ID des Himmelskörpertyps
        /// </summary>
        public virtual int TypeID { get; set; }

        /// <summary>
        /// NAme des Himmelskörpertyps, z.B. Planet
        /// </summary>
        public virtual string Name { get; set; }
    }
}
