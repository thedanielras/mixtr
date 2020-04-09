let YoutubePlayer = function (playlist) {
    let _this = this;
    let playerContainerId;
    let playerParams;

    this.id = playlist.Id;
    this.youtubeId = playlist.Url;
    this.playerContainer;
    this.isSingleVideo = true;
    this.isValid = true;

    this.init = function () {
        new YT.Player(playerContainerId, playerParams);
    };

    let processUrl = function () {
        if (_this.youtubeId.match(/^PL|^RD/g)) {
            _this.isSingleVideo = false;
        }
    };

    let init = function () {
        processUrl();

        let playerContainer;

        playerContainerId = "yt-player-" + _this.id;

        playerContainer = document.createElement('div');
        playerContainer.setAttribute('id', playerContainerId);
        playerContainer.classList.add('yt-player-container');

        playerParams = {
            width: '510'
        };

        if (_this.isSingleVideo) playerParams.videoId = _this.youtubeId;
        else playerParams.playerVars = {
            listType: "playlist",
            list: _this.youtubeId
        }

        _this.playerContainer = playerContainer;
    };
        
   init();
}