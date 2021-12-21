define(['knockout', 'movieservice', 'postman'], function (ko, ms, postman) {
    return function (params) {

        /*Search Page*/

        let stringSearch = ko.observableArray([]);
        let searchInput = ko.observable();
        let tconst = ko.observable();
        let prev = ko.observable();
        let next = ko.observable();

        /*Details Page*/

        let createSearch = () => {
            ms.getMovies(searchInput(), data => {
                console.log("error" + data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                stringSearch(data.movies);
            });
        }


        let showPreviousPage = () => {
            console.log(prev());
            ms.getStringSearchUrl(prev(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                stringSearch(data);
            });
            
        }

        let enablePreviousPage = ko.observable(() => prev() !== undefined);

        let showNextPage = () => {
            console.log(next());
            ms.getStringSearchUrl(next(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                stringSearch(data);
            });
        }

        let enableNextPage = ko.observable(() => next() !== undefined);

        let SeeDetails = (data) => {
            postman.publish("showmovie", data.tconst)
            postman.publish("changeView", "movieDetails")
            
        }





        return {
           
            stringSearch,
            searchInput,
            showPreviousPage,
            enablePreviousPage,
            showNextPage,
            enableNextPage,
            createSearch,
            tconst,
            SeeDetails
        };

    }


})