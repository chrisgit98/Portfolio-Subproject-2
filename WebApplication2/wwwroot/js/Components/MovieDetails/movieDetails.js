define(['knockout', 'movieservice', 'postman'], function (ko, ms, postman) {
    return function (params) {

        let titleBasics = ko.observableArray([]);
        let similarMovies = ko.observableArray([]);
        let popularActors = ko.observableArray([]);


        /*MovieDetails*/
        let getMovieDetails = (tconst) => {
            ms.getSpecificMovie(tconst, data => {
                console.log(data);
                titleBasics(data);
            });
        }


        /*SimilarMoviess*/
        let getSimilarMovies = (tconst) => {
            ms.getSimilarMovies(tconst, data => {
                console.log(data);
                similarMovies(data);
            });
        }
        /*PopularActors*/
        let getPopularActors = (tconst) => {
            ms.getPopularActors(tconst, data => {
                console.log(data);
                popularActors(data);
            });
        }

        postman.subscribe("showmovie", tconst => {
            getMovieDetails(tconst)
            getSimilarMovies(tconst)
            getPopularActors(tconst)
            console.log(tconst)
        })

        let Back = () => postman.publish("changeView", "Search-for-movies");

        return {
            titleBasics,
            similarMovies,
            popularActors,
            Back
        };
    };
});