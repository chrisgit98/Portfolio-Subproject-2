define(['knockout', 'dataservice'], function (ko, dataservice) {
    return function (params) {
        let stringSearch = ko.observableArray([]);
        let Search = ko.observable();
        //let currentView = params.currentView

        

        let createSearch = () => dataservice.getMovies(Search(), data => {         
            stringSearch(data);
        });

        return {

            stringSearch,
            Search,
            createSearch

        };

    }


})