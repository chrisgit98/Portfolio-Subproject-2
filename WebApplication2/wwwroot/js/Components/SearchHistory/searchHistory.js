define(['knockout', 'searchHistoryService'], function (ko, shs) {
    return function (params) {
        let searchHistory = ko.observableArray([]);
        /* let userId = ko.observable < number > ();*/
        let filmId = ko.observable();


        let deleteSearchHistory = searchHistory => {
            console.log(searchHistory);
            shs.deleteSearchHistory(searchHistory);
        }


        shs.getSearchHistory(data => {
            console.log(data);
            searchHistory(data);
        });

        return {

            searchHistory,
            deleteSearchHistory
        };
    };
});