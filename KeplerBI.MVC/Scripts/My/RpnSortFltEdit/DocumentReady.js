// 12.4.2017 mko
// Berechnung des Konfigurierten Sortiertermes
$(document).ready(function () {

    $("#btnSave").click(function () {
        let AppFolder = $("#AppFolder").attr("value");

        let rpnFName = $("#rpnFName").attr("value");

        let ControllerName = $("#ControllerName").attr("value");
        let pnWithoutFunction = $("#pnWithoutFunction").attr("value");

        // Herausfiltern des gecheckten Radiobuttons, auslesen seines Wertes
        let dir = $('input[name=option]:checked').val();
        let ParamTag = $("#ParamTag").attr("value");

        let pn = pnWithoutFunction + ' ' + rpnFName + ' ' + ParamTag + ' ' + dir;


        let uri = AppFolder + ControllerName + '/Index' + '?pn=' + encodeURI(pn);

        //window.location.href = uri;
        window.location.assign(uri);
    });

});
