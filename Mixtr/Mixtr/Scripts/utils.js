function showAlert(statusParam, message) {
    let alertElement = "<div class='alert alert-success fade show'><a href='#' class='close' data-dismiss='alert' aria-label='close'>&times;</a><b>Success! </b><span></span></div>";
    alertElement = $(alertElement);
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