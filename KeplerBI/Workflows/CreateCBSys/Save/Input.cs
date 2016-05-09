using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.Workflows.CreateCBSys.Save
{
    public class Input
    {
        public enum Tags
        {
            Cancel,
            Save
        }

        public Tags Tag { get; set; }
    }

    public class InputCancel : Input
    {
        public InputCancel() 
        {
            Tag = Tags.Cancel;
        }
    }

    public class InputSave : Input
    {
        public InputSave()
        {
            Tag = Tags.Save;
        }

        public string Name { get; set; }
    }
}
