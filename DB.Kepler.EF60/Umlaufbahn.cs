//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DB.Kepler.EF60
{
    using System;
    using System.Collections.Generic;
    
    public partial class Umlaufbahn
    {
        public double Laenge_grosse_Halbachse_in_km { get; set; }
        public double Exzentritzitaet { get; set; }
        public double Umlaufdauer_in_Tagen { get; set; }
        public double Mittlere_Umlaufgeschwindigkeit_in_km_pro_sec { get; set; }
        public int TrabantID { get; set; }
        public int Zentralobjekt_ID { get; set; }
    
        public virtual Himmelskoerper Trabant { get; set; }
        public virtual Himmelskoerper Zentralobjekt { get; set; }
    }
}
