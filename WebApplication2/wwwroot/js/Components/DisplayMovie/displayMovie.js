define(['knockout', 'displayMovieService', 'postman'], function (ko, dms, postman) {
    return function (params) {
        let titleBasics = ko.observableArray([]);
        let tconst = ko.observable();

        let getMovie = () => dms.getSpecificMovies(tconst(), data => {
            console.log(data);
            titleBasics(data);
        });

        return {

            titleBasics,
            tconst,
            getMovie
        };
    };
});