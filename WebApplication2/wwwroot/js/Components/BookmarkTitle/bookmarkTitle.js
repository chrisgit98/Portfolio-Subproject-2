define(['knockout', 'bookmarkTitleService', 'postman'], function (ko, bts, postman) {
    return function (params) {
        let bookmarkTitle = ko.observableArray([]);

        let deleteBookmarkTitle = bookmarkTitle => {
            console.log(bookmarkTitle);
            bps.deleteBookmarkTitle(bookmarkTitle);
        }


        bts.getBookmarkTitle(data => {
            console.log(data);
            bookmarkTitle(data);
        });

        return {

            bookmarkTitle,
            deleteBookmarkTitle
        };
    };
});