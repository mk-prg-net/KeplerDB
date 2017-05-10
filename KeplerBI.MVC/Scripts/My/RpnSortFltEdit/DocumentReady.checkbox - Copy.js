// 12.4.2017 mko
// Berechnung des Konfigurierten Sortiertermes
$(document).ready(function () {

    $("#btnSave").click(function () {
        let AppFolder = $("#AppFolder").attr("value");

        let rpnFName = $("#rpnFName").attr("value");

        let ControllerName = $("#ControllerName").attr("value");
        let pnWithoutFunction = $("#pnWithoutFunction").attr("value");

        let desc = $("#SortDescending").prop('checked');
        let ParamTag = $("#ParamTag").attr("value");

        let pn = pnWithoutFunction + ' ' + rpnFName + ' ' + ParamTag + ' ' + (desc ? "desc" : "asc");


        let uri = AppFolder + ControllerName + '/Index' + '?pn=' + encodeURI(pn);

        //window.location.href = uri;
        window.location.assign(uri);
    });

});
