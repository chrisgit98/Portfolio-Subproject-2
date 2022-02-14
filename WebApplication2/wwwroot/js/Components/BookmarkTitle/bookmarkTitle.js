define(['knockout', 'bookmarkService', 'postman'], function (ko, bs, postman) {
    return function (params) {
        let bookmarkTitle = ko.observableArray([]);

        let deleteBookmarkTitle = bookmarkTitles => {
            console.log("title" + bookmarkTitles);
            bookmarkTitle.remove(bookmarkTitles)
            bs.deleteBookmarkTitle(bookmarkTitles);
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