define(['knockout', 'similarMoviesService'], function (ko, sms) {
    return function (params) {
        let similarMovies = ko.observableArray([]);
        let SimilarSearch = ko.observable();



        let createSimilarSearch = () => sms.getSimilarMovies(SimilarSearch(), data => {
            similarMovies(data);
        });

        return {

            similarMovies,
            SimilarSearch,
            createSimilarSearch

        };

    }


})