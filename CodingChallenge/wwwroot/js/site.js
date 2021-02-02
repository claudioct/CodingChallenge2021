"use strict";

var connection = new signalR.HubConnectionBuilder()
    .withUrl("/likeposthub")
    .build();

connection.start()
    .then(function () { })
    .catch(function (err) {
        return console.log(err.toString());
    });

$(".like-button").on("click", function () {
    var postId = $(this).attr("data-id");
    sendPostLike(postId);
});

function sendPostLike(postId) {
    connection.invoke("SendPostLike", postId).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
}

connection.on("UpdateLikes", function (likes) {
    var counter = $(".like-count");
    $(counter).fadeOut(function () {
        $(this).text(likes);
        $(this).fadeIn();
    });
});
