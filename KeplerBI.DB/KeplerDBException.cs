using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB
{
    public class KeplerDBException : ApplicationException
    {

        public KeplerDBException() : base() { }
        public KeplerDBException(string Message) : base(Message) { }
        public KeplerDBException(string Message, Exception InnerException) : base(Message, InnerException) { }        
        
    }
}
