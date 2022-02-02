define(['knockout', 'ratingService'], function (ko, rs) {
    return function (params) {
        let ratingHistory = ko.observableArray([]);

        rs.getRatingHistory(data => {
            console.log(data);
            ratingHistory(data);
        });

        return {
            ratingHistory
        };
    };
});