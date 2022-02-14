define(['knockout', 'searchHistoryService'], function (ko, shs) {
    return function (params) {
        let searchHistories = ko.observableArray([]);
        let prev = ko.observable();
        let next = ko.observable();

        let deleteSearchHistory = searchHistory => {
            console.log(searchHistory);
            searchHistories([]);
            shs.deleteSearchHistory(searchHistory);
        }


        shs.getSearchHistory(data => {
            console.log(data);
            searchHistories(data.searches);
        });

        let showPreviousPage = () => {
            console.log(prev());
            shs.getSearchHistoryUrl(prev(), data => {
                console.log(prev());
                prev(data.prev || undefined);
                next(data.next || undefined);
                searchHistories(data.searches);
            });

        }

        let enablePreviousPage = ko.computed(() => prev() !== undefined);

        let showNextPage = () => {
            console.log(next());
            shs.getSearchHistoryUrl(next(), data => {
                console.log(data);
                prev(data.prev || undefined);
                next(data.next || undefined);
                searchHistories(data.searches);
            });
        }

        let enableNextPage = ko.computed(() => next() !== undefined);

        return {
            showPreviousPage,
            enablePreviousPage,
            showNextPage,
            enableNextPage,
            searchHistories,
            deleteSearchHistory
        };
    };
});