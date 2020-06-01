function showAlert(statusParam, message) {
    let alertClassName, statusMessage;

    switch (statusParam) {
        case 0:
            alertClassName = "alert-success";
            statusMessage = "Success"
            break;
        case 1:
            alertClassName = "alert-warning";
            statusMessage = "Warning"
            break;
        case 2:
            alertClassName = "alert-danger";
            statusMessage = "Fail"
            break;
    }
    
    
    let alertElement = "<div class='alert fade show'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><b>"
        + statusMessage + ": </b><span></span></div>";
    alertElement = $(alertElement);
    alertElement.addClass(alertClassName);    
    alertElement.find('span').text(message);
    $("#alerts-container").append(alertElement);
}

function getUrlParameter(sParam) {
    var sPageURL = window.location.search.substring(1),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1];
        }
    }
};