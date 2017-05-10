using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class OrderBySemiMajorAxisLengthData: OrderByConfigDataToken
    {

        public OrderBySemiMajorAxisLengthData(IFunctionNames fn, bool descending) : base(fn.OrderBySemiMajorAxisLength, descending)        
        {        
        }
    }
}
