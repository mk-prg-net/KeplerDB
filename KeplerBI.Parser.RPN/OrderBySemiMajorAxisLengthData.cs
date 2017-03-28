using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class OrderBySemiMajorAxisLengthData: ConfigDataToken
    {
        public bool descending;

        public OrderBySemiMajorAxisLengthData(bool descending) : base(Tokens.OrderBySemiMajorAxisLength)        
        {
            this.descending = descending;
        }
    }
}
