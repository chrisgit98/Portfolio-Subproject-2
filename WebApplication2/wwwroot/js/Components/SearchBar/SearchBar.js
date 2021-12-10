define(['knockout', 'dataservice'], function (ko, dataservice) {
    return function (params) {
        let stringSearch = ko.observableArray([]);
        let Search = ko.observable();
        let titleBasics = ko.observableArray([]);
        let tconst = ko.observable();
        tconst(params)
        //let currentView = params.currentView

        

        let createSearch = () => dataservice.getMovies(Search(), data => {         
            stringSearch(data.movies);
        });

        let getM = () => dataservice.getSpecificMovies(tconst(), data => {
            console.log(data);
            titleBasics(data);
        });

       

        return {

            stringSearch,
            Search,
            createSearch,           
            getM,
            tconst,
            titleBasics
            

        };

    }


})