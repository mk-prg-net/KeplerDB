using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace KeplerBI.DB.SpaceShips
{
    /// <summary>
    /// Definiert allgemeine Einsatzbereiche von Raumschiffen
    /// </summary>
    public class Application 
    {        
        public virtual int ApplicationID { get; set; }
        public virtual string Description { get; set; }
    }
}
