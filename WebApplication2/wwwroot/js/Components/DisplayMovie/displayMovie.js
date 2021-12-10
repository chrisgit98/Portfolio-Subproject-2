define(['knockout', 'displayMovieService'], function (ko, dms) {
    return function (params) {
        let titleBasics = ko.observableArray([]);
        let chosenMovie = ko.observable();

        dms.getSpecificMovies(data => {
            console.log(data);
            titleBasics(data);
        });

        return {

            titleBasics,
            getSpecificMovies
        };
    };
});