﻿let Mixtr = function () {
    let _this = this;
    let _arrPosts = [];

    this.onReady = function () {
        _this.loadPosts();
    };

    this.loadPosts = function () {
        $.ajax({
            url: "/Home/GetPosts"
        }).done(function (data) {
            _arrPosts = data;
            if (_arrPosts.length) _this.init();
        }).fail(function () {
            alert("Fail");
        });
    };

    this.init = function () {
        for (let i = 0; i < _arrPosts.length; i++) {
            let thisPost;

            try {
                thisPost = new Post(_arrPosts[i]);
            } catch (e) { }
        }       

        setTimeout(function () { $("#preloader").hide() }, 1500);
    };   
}

function onYouTubeIframeAPIReady() {
    Mixtr = new Mixtr();
    Mixtr.onReady();
}

function checkStatus() {
    //check if status succes then show alert
    if (getUrlParameter("status") === "success")
        showAlert('', 'Post Created');
}

$(document).ready(function () {
    checkStatus();
});