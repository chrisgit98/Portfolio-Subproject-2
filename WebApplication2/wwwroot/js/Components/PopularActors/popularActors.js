define(['knockout', 'popularActorsService'], function (ko, pas) {
    return function (params) {
        let popularActors = ko.observableArray([]);
        let ActorSearch = ko.observable();
        //let currentView = params.currentView



        let createPopularActorsSearch = () => pas.getPopularActors(ActorSearch(), data => {
            popularActors(data);
        });

        return {

            popularActors,
            ActorSearch,
            createPopularActorsSearch

        };

    }


})