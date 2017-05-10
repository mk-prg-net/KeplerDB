// 12.4.2017, mko
$(document).ready(function () {

    $("#btnSave").click(function () {
        let AppFolder = $("#AppFolder").attr("value");

        let rpnFName = $("#rpnFName").attr("value");

        let ControllerName = $("#ControllerName").attr("value");
        let pnWithoutFunction = $("#pnWithoutFunction").attr("value");

        let pCount = parseInt($("#ParameterCount").val());
        let pn = pnWithoutFunction + ' ' + rpnFName + ' ';

        for (i = 0; i < pCount; i++) {

            let pName = $("#PName" + i).attr("value");
            if (pName[0] == '.') {
                pn += ' ' + pName;
            }

            let pVal = $("#PVal" + i).val();
            pn += ' ' + pVal;
        }

        let uri = AppFolder + ControllerName + '/Index' + '?pn=' + encodeURI(pn);

        //window.location.href = uri;
        window.location.assign(uri);
    });

});
