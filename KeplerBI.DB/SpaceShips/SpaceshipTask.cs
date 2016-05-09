using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeplerBI.DB.SpaceShips
{
    /// <summary>
    /// Definiert die Aufgaben von Raumschiffen
    /// </summary>
    public class SpaceshipTask
    {
        public virtual int ID { get; set; }
        public virtual SpaceShip SpaceShip { get; set; }
        public virtual Application Application { get; set; }
        
    }
}
