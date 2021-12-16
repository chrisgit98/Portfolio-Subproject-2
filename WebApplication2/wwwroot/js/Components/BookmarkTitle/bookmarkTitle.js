define(['knockout', 'bookmarkService', 'postman'], function (ko, bs, postman) {
    return function (params) {
        let bookmarkTitle = ko.observableArray([]);

        let deleteBookmarkTitle = bookmarkTitle => {
            console.log("title" + bookmarkTitle);
            bs.deleteBookmarkTitle(bookmarkTitle);
        }


        bs.getBookmarkTitle(data => {
            console.log(data);
            bookmarkTitle(data);
        });

        return {

            bookmarkTitle,
            deleteBookmarkTitle
        };
    };
});