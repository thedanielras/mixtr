let Mixtr = function () {
    let _this = this;
    let _arrPlaylists = [];
    let playersCount = 0;

    this.onReady = function () {
        _this.loadPlayLists();
    };

    this.loadPlayLists = function () {
        $.ajax({
            url: "/Home/GetPlaylists"
        }).done(function (data) {
            _arrPlaylists = data;
            if (_arrPlaylists.length) _this.initPlayers();
        }).fail(function () {
            alert("Fail");
        });
    };

    this.initPlayers = function () {
        for (let i = 0; i < _arrPlaylists.length; i++) {
            let thisPlaylist = _arrPlaylists[i];
            if (thisPlaylist.Url)
                _this.loadPlayer(thisPlaylist);
        }

        setTimeout(function () { $("#preloader").hide() }, 1500);
    };

    this.loadPlayer = function (playlistObj) {
        let playersContainer = document.getElementById('rollBar');
        let playerElementId = _this.getDistinctId();

        let playerElement = document.createElement('div');
        playerElement.setAttribute('id', playerElementId);
        playerElement.classList.add('player-entity');

        playersContainer.appendChild(playerElement);

        // 3 - load new player
        let playerParams = {
            height: '390'
            , width: '640'
        };

        if (playlistObj.IsSingleVideo) playerParams.videoId = playlistObj.Url;
        else playerParams.playerVars = {
            listType: "playlist",
            list: playlistObj.Url
        }

        new YT.Player(playerElementId, playerParams);
    };

    this.getDistinctId = function () {
        let playerId = "Player_Index_" + playersCount;
        playersCount++;

        return playerId;
    };

}

function onYouTubeIframeAPIReady() {
    Mixtr = new Mixtr();
    Mixtr.onReady();
}

$(document).ready(function () {
    //check if status succes then show alert
    if (getUrlParameter("status") === "success")
        showAlert('', 'Playlist Added');
});

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