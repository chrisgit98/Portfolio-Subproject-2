define(['knockout', 'personservice', 'postman'], function (ko, ps, postman) {
    return function (params) {
        let nameSearch = ko.observableArray([]);
        let searchInput = ko.observable();
        let prev = ko.observable();
        let next = ko.observable();

        let createSearch = () => {
            ps.getPersons(searchInput(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                nameSearch(data.names);
            });
        }

        let showPreviousPage = () => {
            console.log(prev());
            ps.getNameSearchUrl(prev(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                nameSearch(data.names);
            });

        }

        let enablePreviousPage = ko.computed(() => prev() !== undefined);

        let showNextPage = () => {
            console.log(next());
            ps.getNameSearchUrl(next(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                nameSearch(data.names);
            });
        }

        let enableNextPage = ko.computed(() => next() !== undefined);

        let SeeDetails = (data) => {
            postman.publish("showperson", data.personId)
            postman.publish("changeView", "personDetails")
        }


        return {

            nameSearch,
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