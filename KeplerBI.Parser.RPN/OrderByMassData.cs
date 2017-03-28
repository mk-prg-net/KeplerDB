using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class OrderByMassData : ConfigDataToken
    {
        public bool descending;

        public OrderByMassData(bool descending) : base(Tokens.OrderByMass)        
        {
            this.descending = descending;
        }

    }
}
