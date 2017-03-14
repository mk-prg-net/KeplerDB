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

        let AppFolder = $("#AppFolder").attr("value");

        let queryOption = begin + " " + end + " SemiMajorAxisLengthRng";
        let uri = AppFolder + 'Planets?rpn=' + encodeURI(queryOption);

        //window.location.href = uri;
        window.location.assign(uri);
    });


    $("img[name=rank]").each(function (ix, elem) {

        var rankCount = parseInt($(elem).attr("data-RankCount"))
        var rankSum = parseInt($(elem).attr("data-RankSum"))
        var planet = $(elem).attr("data-Planet");
        CalculateRank(planet, rankCount, rankSum);

    });



    $("img[data-Vote=bad]").click(function () {
        var planet = $(this).attr("data-Planet");
        Vote(planet, "1")
    });

    $("img[data-Vote=ok]").click(function () {
        var planet = $(this).attr("data-Planet");
        Vote(planet, "2")
    });

    $("img[data-Vote=good]").click(function () {
        var planet = $(this).attr("data-Planet");
        Vote(planet, "3")
    });

});

function CalculateRank(planet, rankCount, rankSum) {
    var AppFolder = $("#AppFolder").attr("value");
    if (rankCount > 0) {

        var Rank = rankSum / rankCount;

        $("#imgVote" + planet).attr("title", "#Stimmen: " + rankCount.toString());
        if (Rank < 1.5) {
            $("#imgVote" + planet).attr("src", AppFolder + "Content/pics/etc/cuby-bad.svg");
        } else if (Rank < 2.5) {
            $("#imgVote" + planet).attr("src", AppFolder + "Content/pics/etc/cuby.svg");
        } else {
            $("#imgVote" + planet).attr("src", AppFolder + "Content/pics/etc/cuby-happy.svg");
        }
    } else {
        $("#imgVote" + planet).attr("src", AppFolder + "Content/pics/etc/cuby-unknown.svg");
    }
}


function Vote(planetName, option) {

    var AppFolder = $("#AppFolder").attr("value");

    // Alte Fehlermeldungen löschen
    $("#status").text("");
    $("#status").attr("class", "");

    $.ajax({
        type: "GET",
        //dataType: "json",
        url: AppFolder + "Planets/Voting",
        data: "Name=" + planetName + "&option=" + option,
        cache: false
    }).done(function (Result, status, req) {

        // Es hat geklappt
        console.log(Result.toString());

        CalculateRank(Result.Planet, Result.Count, Result.Sum);

    }).fail(function (jqXHR, textStatus, errorThrown) {

        // Leider ein Fehler
        console.log(jqXHR.status.toString());
        $("#status").attr("class", "bg-danger");
        $("#status").text("Ein Fehler beim Abstimmen ist aufgetreten: " + jqXHR.status.toString());



    });
}