define(['knockout', 'movieservice', 'postman'], function (ko, ms, postman) {
    return function (params) {

        /*Search Page*/

        let bestMatchSearch = ko.observableArray([]);
        let searchInput = ko.observable();
        let filmId = ko.observable();
        let prev = ko.observable();
        let next = ko.observable();

        /*Details Page*/

        let createSearch = () => {
            ms.getMovies(searchInput(), data => {
                console.log( data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                bestMatchSearch(data.movies);
            });
        }


        let showPreviousPage = () => {
            console.log(prev());
            ms.getBestMatchUrl(prev(), data => {
                console.log(prev());
                prev(data.prev || undefined);
                next(data.next || undefined);
                bestMatchSearch(data.movies);
            });
            
        }

        let enablePreviousPage = ko.computed(() => prev() !== undefined);

        let showNextPage = () => {
            console.log(next());
            ms.getBestMatchUrl(next(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                bestMatchSearch(data.movies);
            });
        }

        let enableNextPage = ko.computed(() => next() !== undefined);

        let SeeDetails = (data) => {
            postman.publish("showmovie", data.filmId)
            postman.publish("changeView", "movieDetails")
            
        }





        return {
           
            bestMatchSearch,
            searchInput,
            showPreviousPage,
            enablePreviousPage,
            showNextPage,
            enableNextPage,
            createSearch,
            filmId,
            SeeDetails
        };

    }


})