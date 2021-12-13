define(['knockout', 'displayMovieService', 'postman'], function (ko, dms, postman) {
    return function (params) {
        let currentComponent = ko.observable("list")
        let currentView = ko.observable("Search-for-movies");
        let titleBasics = ko.observableArray([]);
        let tconst = ko.observable();

        let similarMovies = ko.observableArray([]);

        let popularActors = ko.observableArray([]);

        let getMovie = () => {
            dms.getSpecificMovie(tconst(), data => {
                console.log(data);
                titleBasics(data);
            });
            currentView("list");
            tconst("");
        }

        let Back = () => postman.publish("changeView", "Search-for-movies");

        getMovie();

        tconst.subscribe(getMovie);

        /*SimilarMoviess*/
        dms.getSimilarMovies(tconst(), data => {
            console.log(data);
            similarMovies(data);
        });

        /*PopularActors*/
        dms.getPopularActors(tconst(), data => {
            console.log(data);
            popularActors(data);
        });


        return {
            currentComponent,
            currentView,
            titleBasics,
            tconst,
            getMovie,
            Back,
            similarMovies,
            popularActors
        };
    };
});