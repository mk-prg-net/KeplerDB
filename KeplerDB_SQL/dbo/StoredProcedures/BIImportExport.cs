//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung (www.mkoit.de)
// Stuttgart, den 
//
//  Projekt.......: KEplerDB_Import_Export
//  Name..........: BIImportExport.cs
//  Aufgabe/Fkt...: Fragt in der Beispieldatenbank KeplerDB mittels
//                  Join alle Daten zu Sternen/Planeten/Monden ab und
//                  formt daraus ein XML- Dokument
//
//
//
//<unit_environment>
//------------------------------------------------------------------
//  Zielmaschine..: PC 
//  Betriebssystem: Windows 7 mit .NET 4.5
//  Werkzeuge.....: Visual Studio 2013
//  Autor.........: Martin Korneffel (mko)
//  Version 1.0...: 
//
// </unit_environment>
//
//<unit_history>
//------------------------------------------------------------------
//
//  Version.......: 1.1
//  Autor.........: Martin Korneffel (mko)
//  Datum.........: 
//  Änderungen....: 
//
//</unit_history>
//</unit_header>        
        
using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;


namespace KeplerDB_Import_Export
{
    public class BIImportExport
    {
        public static string Export_SPM()
        {

            var xml = new System.Xml.XmlDocument();            

            xml.AppendChild(xml.CreateXmlDeclaration("1.0", "utf-8", ""));

            // Dokumentwurzel erzeugen
            var root = xml.CreateElement("Alle");
            xml.AppendChild(root);



            // using Block ruft am Ende automat. die Dispose- Methode von conn auf. Dadurch wird conn geschlossen
            using (var conn = new SqlConnection("context connection=true"))
            {
                conn.Open();
                var cmd = new SqlCommand("select	A.Name as Name, "
                                        + "A.Masse_in_kg as Masse, "
                                        + "B.Aequatordurchmesser_in_km as D, "
                                        + "B.Fallbeschleunigung_in_meter_pro_sec as g, "
                                        + "B.Rotationsperiode_in_Stunden as DTag, "
                                        + "C.Name as Typ  "
                                        + "from [KeplerDB].[dbo].[HimmelskoerperTab] as A join [KeplerDB].[dbo].[Sterne_Planeten_MondeTab] as B on A.ID = B.HimmelskoerperID "
                                        + "Join [KeplerDB].dbo.HimmelskoerperTypenTab as C on A.HimmelskoerperTyp_ID = C.ID "
                                        + "order by Masse_in_kg", conn);

                // Erzeugt einen Kulturkontext für die US- Amerikanische Kultur. Wird benötigt bei der Umwandlung von Double- Werten
                // in Strings, damit als Dezimaltrennzeichen anstatt eines Kommas (auf deutschen Servern) ein Punkt eingesetzt wird.
                // Denn in XML- Dokumenten sollte aus Gründen der Kompadibilität mit XSD die US- Notation für Gleitkommawerte vrwendet werden.
                var cultUS = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string Name = (string)reader["Name"];
                        double Masse_in_kg = (double)reader["Masse"];
                        double Aequtordurchmesser_in_km = (double)reader["D"];
                        double Rotationsperiode_in_Stunden = (double)reader["DTag"];
                        double Fallbeschleunigung_in_meter_pro_sec = (double)reader["g"];


                        // Aus den Daten ein XML- Element machen
                        var row = xml.CreateElement((string)reader["Typ"]);
                        //var row = xml.CreateElement("T");
                        root.AppendChild(row);

                        var aName = xml.CreateAttribute("Name");
                        aName.Value = Name;
                        row.Attributes.Append(aName);

                        var aM = xml.CreateAttribute("Masse");
                        aM.Value = Masse_in_kg.ToString(cultUS);  // Formatieren nach US- Kultur !
                        row.Attributes.Append(aM);

                        var aD = xml.CreateAttribute("D");
                        aD.Value = Aequtordurchmesser_in_km.ToString(cultUS);
                        row.Attributes.Append(aD);

                        var aDTag = xml.CreateAttribute("DTag");
                        aDTag.Value = Rotationsperiode_in_Stunden.ToString(cultUS);
                        row.Attributes.Append(aDTag);

                        var ag = xml.CreateAttribute("g");
                        ag.Value = Fallbeschleunigung_in_meter_pro_sec.ToString(cultUS);
                        row.Attributes.Append(ag);

                    }
                }

                // Alternativ zum Einsatz der US- Kultur könnte auch beim Schreiben des XML- Dokumentes der Kulturkontext 
                // des Threads geändert werden. Dies erfordert jedoch den Permission Level Unsafe in den Projekteinstellungen\SQLClr
                // Diese erfodern dann noch weitere Andministrative Schritte: 
                // siehe http://www.codeproject.com/Articles/290249/Deploy-Use-assemblies-which-require-Unsafe-Externa
                //var cult = System.Threading.Thread.CurrentThread.CurrentCulture;
                try
                {

                    //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

                    //res = new SqlXml(System.Xml.XmlReader.Create(new System.IO.StringReader(xml.ToString())));
                    var bld = new System.Text.StringBuilder();

                    var settings = new System.Xml.XmlWriterSettings();
                    settings.Encoding = UTF8Encoding.UTF8;
                    settings.Indent = true;                    

                    var writer = System.Xml.XmlWriter.Create(bld);                    
                    xml.WriteContentTo(writer);
                    writer.Flush();

                    return bld.ToString();
                }
                finally
                {
                    // Wiederherstellen der urspünglichen Kultur
                    //System.Threading.Thread.CurrentThread.CurrentCulture = cult;
                }

            }
        }

    }
}
