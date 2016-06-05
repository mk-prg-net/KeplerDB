//<unit_header>
//----------------------------------------------------------------
//
// Martin Korneffel: IT Beratung/Softwareentwicklung
// Stuttgart, den 29.5.2016
//
//  Projekt.......: KeplerBI.MVC/Planets/Index
//  Name..........: DocumentReady.js
//  Aufgabe/Fkt...: Installieren und Implementieren von Click- Eventhandlern
//                  zum erzeugen und abrufen von Url's mit RPN- Filterausdrücken.
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

    $("#btnDefSemiMajorAxisRng").click(function () {
        let begin = $("#DefSemiMajorAxisRngBegin").val();
        let end = $("#DefSemiMajorAxisRngEnd").val();

        let queryOption = begin + " " + end + " SemiMajorAxisLengthRng";
        let uri = '/Planets?rpn=' + encodeURI(queryOption);

        //window.location.href = uri;
        window.location.assign(uri);

        
    });



});