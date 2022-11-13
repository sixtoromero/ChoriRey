$(document).ready(function () {
    $("#year").text((new Date).getFullYear());
    $("#welcome").hide();
    $("#error").hide();

    SetActivation();

});

var getUrlParameter = function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : decodeURIComponent(sParameterName[1]);
        }
    }
};

function SetActivation() {
    
    let param = getUrlParameter('email');
    if (param != null) {
        var params = new Object();
        params.email = param;

        $.ajax({
            type: "GET",
            url: "/api/Clientes/GetActivation",
            data: params,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                console.log('Resultado', data);
                if (data) {
                    $("#loading").hide();
                    $("#loadingtxt").hide();
                    $("#error").hide();
                    $("#loading").removeClass("d-flex justify-content-center");

                    $("#welcome").show();
                } else {
                    $("#loading").hide();
                    $("#loadingtxt").hide();
                    $("#welcome").hide();
                    $("#loading").removeClass("d-flex justify-content-center");

                    $("#error").show();
                }
            },
            complete: function () {

            },
            error: function (data) {
                $("#loading").removeClass("d-flex justify-content-center");
                $("#loading").hide();
                $("#loadingtxt").hide();

                $("#welcome").hide();
                $("#error").show();
                //swal("Error: " + data.responseText, "Ads Publisher", "error");
            }
        });
    }
}

