define(['knockout', 'movieservice','bookmarkService', 'postman'], function (ko, ms , bs, postman) {
    return function (params) {

        let titleOtherview = ko.observable();
        let similarMovies = ko.observableArray([]);
        let popularActors = ko.observableArray([]);
        let status = ko.observable();

        /*MovieDetails*/
        let getMovieDetails = (tconst) => {
            ms.getSpecificMovie(tconst, data => {
                console.log(data);
                titleOtherview(data);
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


        let BookamrkMovie = () => {
            const bookmarkTitle = { u_id: localStorage.getItem("u_id"), filmId: titleOtherview().filmId, title: titleOtherview().title };
            status("Bookmarked")

            bs.createBookmarkTitle(bookmarkTitle, data => {
                console.log(data);
            });
      
        }

        let deleteBookmarkTitle = bookmarkTitle => {
            console.log(bookmarkTitle);
            bs.deleteBookmarkTitle(bookmarkTitle);
        }

        return {
            titleOtherview,
            similarMovies,
            popularActors,
            BookamrkMovie,
            Back,
            status,
            deleteBookmarkTitle
        };
    };
});