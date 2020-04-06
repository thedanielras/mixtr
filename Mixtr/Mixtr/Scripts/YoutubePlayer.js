let YoutubePlayer = function (playlist) {
    let _this = this;
    let playerContainerId;
    let playerParams;

    this.id = playlist.Id;
    this.videoId = playlist.IsSingleTrack ? playlist.Url : null;
    this.listId = playlist.IsSingleTrack ? null : playlist.Url;
    this.playerContainer;
    
    this.init = function () {
        new YT.Player(playerContainerId, playerParams);
    };

    let init = function () {
        let playerContainer;

        playerContainerId = "yt-player-" + _this.id;

        playerContainer = document.createElement('div');
        playerContainer.setAttribute('id', playerContainerId);
        playerContainer.classList.add('yt-player-container');

        playerParams = {
            width: '510'
        };

        if (_this.videoId) playerParams.videoId = _this.videoId;
        else playerParams.playerVars = {
            listType: "playlist",
            list: _this.listId
        }

        _this.playerContainer = playerContainer;
    };
        
   init();
}