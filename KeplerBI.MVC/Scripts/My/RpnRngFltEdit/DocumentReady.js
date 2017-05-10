// 12.4.2017 mko
$(document).ready(function () {

    $("#btnSave").click(function () {
        let AppFolder = $("#AppFolder").attr("value");

        let rpnFName = $("#rpnFName").attr("value");

        let ControllerName = $("#ControllerName").attr("value");
        let pnWithoutFunction = $("#pnWithoutFunction").attr("value");

        let Begin = $("#Begin").val();
        let BeginTag = $("#BeginTag").attr("value");

        let End = $("#End").val();
        let EndTag = $("#EndTag").attr("value");



        
        let pnRng = pnWithoutFunction + ' ' + rpnFName + ' ' + BeginTag + ' ' + Begin + ' ' + EndTag + ' ' + End


        let uri = AppFolder + ControllerName + '/Index' + '?pn=' + encodeURI(pnRng);

        //window.location.href = uri;
        window.location.assign(uri);
    });

});
