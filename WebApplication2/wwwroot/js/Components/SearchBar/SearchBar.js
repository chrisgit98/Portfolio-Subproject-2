

define(['knockout', 'dataservice', 'postman'], function (ko, dataservice, postman) {
    return function (params) {
        let stringSearch = ko.observableArray([]);
        let searchInput = ko.observable();
        let prev = ko.observable();
        let next = ko.observable();

        //let currentView = params.currentView

        //let createSearch = () => {
        //    dataservice.getMovies(searchInput(), data => {
        //        prev(data.prev || undefined);
        //        next(data.next || undefined);
        //        stringSearch(data.movies);
        //    });
        //}

        //let showPreviousPage = () => {
        //    console.log(prev());
        //    createSearch(prev());
        //}

        //let enablePreviousPage = ko.observable(() => prev() !== undefined);

        //let showNextPage = () => {
        //    console.log(next());
        //    createSearch(next());
        //}

        //let enableNextPage = ko.observable(() => next() !== undefined);

        let createSearch = () => {
            dataservice.getMovies(searchInput(), data => {
                prev(data.prev || undefined);
                next(data.next || undefined);
                stringSearch(data.movies);
            });
        }

        let showPreviousPage = () => {
            console.log(prev());
            dataservice.getStringSearchUrl(prev(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                stringSearch(data);
            });
            
        }

        let enablePreviousPage = ko.observable(() => prev() !== undefined);

        let showNextPage = () => {
            console.log(next());
            dataservice.getStringSearchUrl(next(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                stringSearch(data);
            });
        }

        let enableNextPage = ko.observable(() => next() !== undefined);

        let SeeDetails = () => postman.publish("changeView", "displayMovie")
       

        return {
           
            stringSearch,
            searchInput,
            showPreviousPage,
            enablePreviousPage,
            showNextPage,
            enableNextPage,
            createSearch,
            SeeDetails
        };

    }


})