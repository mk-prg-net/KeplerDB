using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void sp_Export_Sterne_Planeten_Monde(out bool Success, out string ErrMsg, out SqlXml res)
    {
        // Alle Sterne Planeten Monde auslesen und ein XML- Dokument erzeugen
        Success = true;
        ErrMsg = "";

        System.IO.StringReader stringReaderForNullTag = new System.IO.StringReader("<null/>");
        System.Xml.XmlReader xmlReaderForNullTag = System.Xml.XmlReader.Create(stringReaderForNullTag);
        res = new SqlXml(xmlReaderForNullTag);
        //res = "null";

        try
        {
            string resTxt = KeplerDB_Import_Export.BIImportExport.Export_SPM();
            res = new SqlXml(System.Xml.XmlReader.Create(new System.IO.StringReader(resTxt)));
        }
        catch (Exception ex)
        {
            Success = false;
            ErrMsg = ex.Message;
            if (ex.InnerException != null)
            {
                ErrMsg += ": " + ex.InnerException.Message;
                if (ex.InnerException.InnerException != null)
                {
                    ErrMsg += ": " + ex.InnerException.InnerException.Message;
                }
            }
        }

    }
}
