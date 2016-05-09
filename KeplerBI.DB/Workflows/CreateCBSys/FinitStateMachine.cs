using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.Workflows.CreateCBSys
{
    public class FinitStateMachine : KeplerBI.Workflows.CreateCBSys.FinitStateMachine
    {
        public override KeplerBI.Workflows.CreateCBSys.StateFactory StateFactory
        {
            get { return new StateFactory(); }
        }
        
    }
}
