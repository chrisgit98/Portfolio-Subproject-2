define(['knockout', 'movieservice', 'postman'], function (ko, ms, postman) {
    return function (params) {

        let titleBasics = ko.observableArray([]);
        let tconst = ko.observable();
        let similarMovies = ko.observableArray([]);
        let popularActors = ko.observableArray([]);

        let getMovie = () => {
            ms.getSpecificMovie(tconst(), data => {
                console.log(data);
                titleBasics(data);
            });
        }

        getMovie();

        let Back = () => postman.publish("changeView", "Search-for-movies");

        /*SimilarMoviess*/
        ms.getSimilarMovies(tconst(), data => {
            console.log(data);
            similarMovies(data);
        });

        /*PopularActors*/
        ms.getPopularActors(tconst(), data => {
            console.log(data);
            popularActors(data);
        });


        return {
            titleBasics,
            tconst,
            getMovie,
            Back,
            similarMovies,
            popularActors
        };
    };
});