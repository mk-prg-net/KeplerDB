using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro
{
    public abstract class Mond : Himmelskoerper
    {
        /// <summary>
        /// 1:n Beziehung zwischen Planet und seinen Monden
        /// Verweis auf den Plaeten, den dieser Mond umkreist
        /// </summary>
        public abstract Planet Planet { get; }
    }
}
