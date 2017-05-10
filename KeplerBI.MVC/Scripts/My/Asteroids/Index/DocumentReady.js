//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 29.3.2017
//
//  Projekt.......: KeplerBI.MVC
//  Name..........: DocumentReady.js
//  Aufgabe/Fkt...: Startup- Script für Astroids\Index.cshtml
//                  
//
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


$(document).ready(function () {

    // btnFilter 
    $("#btnFilter").click(function () {        
        let AppFolder = $("#AppFolder").attr("value");
        
        let uri = AppFolder + 'Asteroids?pn=' + encodeURI($("#rpn").val());

        //window.location.href = uri;
        window.location.assign(uri);
    });
});