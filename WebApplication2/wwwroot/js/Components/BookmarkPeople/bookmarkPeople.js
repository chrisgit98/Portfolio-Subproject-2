define(['knockout', 'bookmarkService', 'postman'], function (ko, bs, postman) {
    return function (params) {
        let bookmarkPeople = ko.observableArray([]);

        let deleteBookmarkPeople = bookmarkPeoples => {
            console.log("name" + bookmarkPeoples);
            bookmarkPeople.remove(bookmarkPeoples)
            bs.deleteBookmarkPeople(bookmarkPeoples);
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