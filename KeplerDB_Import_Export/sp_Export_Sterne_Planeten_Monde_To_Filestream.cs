using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void sp_Export_Sterne_Planeten_Monde_To_Filestream(out bool Success, out string ErrMsg)
    {
        // Alle Sterne Planeten Monde auslesen und ein XML- Dokument erzeugen
        Success = true;
        ErrMsg = "";

        // 
        try
        {

            string xmlTxt = KeplerDB_Import_Export.BIImportExport.Export_SPM();

            //xmlTxt = xmlTxt.Replace("encoding=\"utf-16\"", "encoding=\"utf-8\"");

            string FileName = "SPM_" + DateTime.Now.ToString("s").Replace(':', '-') + ".xml";

            var cmdInsertTxt = string.Format("insert into [dbo].[Export_Sterne_Planeten_Monde]([name], file_stream) values('{0}', Cast('{1}' as varbinary(max)))", FileName, xmlTxt);

            // using Block ruft am Ende automat. die Dispose- Methode von conn auf. Dadurch wird conn geschlossen
            using (var conn = new SqlConnection("context connection=true"))
            {
                conn.Open();
                // Xml- Datei wird durch einfügen in der Filetable im Dateisystem unter der Fstream- Dateifreigabe angelegt
                var cmdInsert = new SqlCommand(cmdInsertTxt, conn);
                cmdInsert.ExecuteNonQuery();
            }


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
