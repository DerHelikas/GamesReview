$("#AllGamesFilterButton").on("click",() => {


    $("#All").css({ "display": "block" });
    $("#WithReview").css({ "display": "none" });
    $("#WithoutRaview").css({ "display": "none" });
});

$("#GamesWithReviews").on("click", () => {


    $("#All").css({ "display": "none" });
    $("#WithReview").css({ "display": "block" });
    $("#WithoutRaview").css({ "display": "none" });
});


$("#AllGamesFilterButton").on("click", () => {

    $("#All").css({ "display": "none" });
    $("#WithReview").css({ "display": "none" });
    $("#WithoutRaview").css({ "display": "block" });
});