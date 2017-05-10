using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Parser.RPN
{
    public class OrderByMassData : OrderByConfigDataToken
    {
        public OrderByMassData(IFunctionNames fn, bool descending) : base(fn.OrderByMass, descending)        
        {            
        }

    }
}
