using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

public partial class StoredProcedures
{
    [Microsoft.SqlServer.Server.SqlProcedure]
    public static void sp_Export_Sterne_Planeten_Monde_as_String(out bool Success, out string ErrMsg, out string res)
    {
        // Alle Sterne Planeten Monde auslesen und ein XML- Dokument erzeugen
        Success = true;
        ErrMsg = "";
        res = "<null/>";
        
        //res = "null";

        try
        {
            res = KeplerDB_Import_Export.BIImportExport.Export_SPM();            
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
