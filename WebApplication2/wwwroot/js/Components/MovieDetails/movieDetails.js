define(['knockout', 'movieservice','bookmarkService', 'postman'], function (ko, ms , bs, postman) {
    return function (params) {

        let titleOtherview = ko.observable();
        let rateinput = ko.observable();
        let similarMovies = ko.observableArray([]);
        let popularActors = ko.observableArray([]);
        let status = ko.observable();

        /*MovieDetails*/
        let getMovieDetails = (filmId) => {
            ms.getSpecificMovie(filmId, data => {
                console.log(data);
                titleOtherview(data);
            });
        }


        /*SimilarMoviess*/
        let getSimilarMovies = (filmId) => {
            ms.getSimilarMovies(filmId, data => {
                console.log(data);
                similarMovies(data);
            });
        }
        /*PopularActors*/
        let getPopularActors = (filmId) => {
            ms.getPopularActors(filmId, data => {
                console.log(data);
                popularActors(data);
            });
        }

        postman.subscribe("showmovie", filmId => {
            getMovieDetails(filmId)
            getSimilarMovies(filmId)
            getPopularActors(filmId)
            console.log(filmId)
        })

        let Back = () => postman.publish("changeView", "Search-for-movies");

        let rateMovie = () => {
            const filmId = titleOtherview().filmId;
            ms.rateATitle(filmId, rateinput(), data => {
                console.log(data)
            });
        }

        //let rateMovie = () => {
        //    const movierate = { filmId: titleOtherview().filmId, givenRate: rateinput() };

        //    ms.rateATitle(movierate, data => {
        //        console.log(data)
        //    });
        //}

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
       //adding the star system
        var $star_rating = $('.star-rating .fa');

        var SetRatingStar = function () {
            return $star_rating.each(function () {
                if (parseInt($star_rating.siblings('input.rating-value').val()) >= parseInt($(this).data('rating'))) {
                    return $(this).removeClass('fa-star-o').addClass('fa-star');
                } else {
                    return $(this).removeClass('fa-star').addClass('fa-star-o');
                }
            });
        };

        $star_rating.on('click', function () {
            $star_rating.siblings('input.rating-value').val($(this).data('rating'));
            return SetRatingStar();
        });

        SetRatingStar();
        $(document).ready(function () {

        });
        return {
            titleOtherview,
            similarMovies,
            popularActors,
            BookamrkMovie,
            Back,
            status,
            deleteBookmarkTitle,
            rateMovie,
            rateinput
        };
    };
});