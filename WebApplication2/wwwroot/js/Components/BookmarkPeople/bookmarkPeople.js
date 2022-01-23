define(['knockout', 'bookmarkService', 'postman'], function (ko, bs, postman) {
    return function (params) {
        let bookmarkPeople = ko.observableArray([]);

        let deleteBookmarkPeople = bookmarkPeople => {
            console.log("name" + bookmarkPeople);
            bs.deleteBookmarkPeople(bookmarkPeople);
        }


        bs.getBookmarkPeople(data => {
            console.log(data);
            bookmarkPeople(data);
        });

       

        return {
            
            bookmarkPeople,     
            deleteBookmarkPeople
        };
    };
});