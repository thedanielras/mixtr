let Mixtr = function () {
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
            } catch (e) {
            }
        }

        setTimeout(function () {
            $("#preloader").hide();
            $("body").css("overflow", "auto")
        }, 1700);
    };
}

function onYouTubeIframeAPIReady() {
    Mixtr = new Mixtr();
    Mixtr.onReady();
}

function checkStatus() {
    let status = getUrlParameter("status");
    if (status === null) return;

    if (status === "success")
        showAlert(0, 'Post created');
    else if (status === "fail")
        showAlert(2, 'Something went wrong :(')
}

$(document).ready(function () {
    $("#dropdown-user-authentication").click(function () {
        $(".authentication-dropdown-menu").css("left", "-" + (($(".authentication-dropdown-menu").width() / 2) - 18) + "px");
        $(".authentication-dropdown-menu").show();
        window.onclick = function (event) {
            if (!event.target.matches('.dropbtn')) {
                var dropdowns = document.getElementsByClassName("dropdown-content");
                var i;
                for (i = 0; i < dropdowns.length; i++) {
                    var openDropdown = dropdowns[i];
                    $(openDropdown).hide();
                }
                window.onclick = function () {
                }
            }
        }
    });

    checkStatus();
});