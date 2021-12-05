define(['knockout', 'bookmarkPeopleService'], function (ko, bps) {
    return function (params) {
        let bookmarkPeople = ko.observableArray([]);
        /* let userId = ko.observable < number > ();*/
        let personId = ko.observable();
        let currentView = params.currentView


        let deleteBookmarkPeople = bookmarkPeople => {
            console.log(bookmarkPeople);
            bps.deleteBookmarkPeople(bookmarkPeople);
        }

        let addBookmarkPeopleView = () => currentView("add-bookmarkPeople");

        bps.getBookmarkPeople(data => {
            console.log(data);
            bookmarkPeople(data);
        });

        return {
            
            bookmarkPeople,     
            deleteBookmarkPeople,
            addBookmarkPeopleView
        };
    };
});