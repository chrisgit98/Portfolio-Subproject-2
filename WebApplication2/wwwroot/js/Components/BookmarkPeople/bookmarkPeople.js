﻿define(['knockout', 'bookmarkPeopleService', 'postman'], function (ko, bps, postman) {
    return function (params) {
        let bookmarkPeople = ko.observableArray([]);

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