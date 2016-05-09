using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCBSys.SelectCentralBody
{
    public class Input
    {
        public enum Tags{
            Start,
            Cancel,
            CentralBody
        }

        public Tags Tag{get; set;}
    }

    public class InputStart : SelectCentralBody.Input
    {
        public InputStart()
        {
            Tag = Tags.Start;
        }
    }


    public class InputCancel : SelectCentralBody.Input
    {
        public InputCancel()
        {
            Tag = Tags.Cancel;
        }
    }

   
}
