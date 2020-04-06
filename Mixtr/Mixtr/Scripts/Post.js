let Post = function (postObject) {
    let _this = this;
    let postContainerId,
        postContainer;

    this.id = postObject.Id;
    this.title = postObject.Title;
    this.playlist = postObject.Playlist;
    this.likesCount = postObject.LikesCount;
    this.youtubePlayer;

    let initHeader = function () {
        // title
        let header,
            title;

        header = document.createElement("div");
        header.classList.add("post__header");
        title = document.createElement("h5");
        title.classList.add("post__title");
        title.innerText = _this.title;
        header.appendChild(title);

        postContainer.appendChild(header);
    };

    let initBody = function () {
        // player
        try {
            _this.youtubePlayer = new YoutubePlayer(_this.playlist);
        } catch (e) { alert("Failed initializing player"); }

        let body;

        body = document.createElement("div");
        body.classList.add("post__body");
        body.appendChild(_this.youtubePlayer.playerContainer);

        postContainer.appendChild(body);
    };

    let initActions = function () {
        // likes
        let actions,
            likes,
            likesImg,
            likesCount;

        actions = document.createElement("div");
        actions.classList.add("post__actions");
        likes = document.createElement("div");
        likes.classList.add("post__likes");
        likesImg = document.createElement("img");
        likesImg.classList.add("post__like-img");
        likesImg.setAttribute("src", "../../Content/icons/like.svg");
        $(likesImg).click(function () {
            $(this).attr("src", "../../Content/icons/like-filled.svg");
        });
        likes.appendChild(likesImg);
        likesCount = document.createElement("span");
        likesCount.classList.add("post__likes-count");
        likesCount.innerText = String(_this.likesCount);
        likes.appendChild(likesCount);
        actions.appendChild(likes);

        postContainer.appendChild(actions);
    };

    let init = function () {
        postContainerId = "post-" + _this.id;

        postContainer = document.createElement("div");
        postContainer.classList.add("post");
        postContainer.setAttribute("id", postContainerId);

        initHeader();
        initBody();
        initActions();

        $("#feed").append(postContainer);
        _this.youtubePlayer.init();
    }

    init();
};