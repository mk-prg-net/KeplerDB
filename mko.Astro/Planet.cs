using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mko.Astro
{
    public abstract class Planet : Himmelskoerper
    {
        /// <summary>
        /// 1:n Beziehung:
        /// Verweis auf den Stern, der umkreist wird von diesem Planeten
        /// </summary>
        public abstract Stern Zentralstern { get; }

    }
}
