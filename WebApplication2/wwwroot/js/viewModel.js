define(["knockout", "postman"], function (ko, postman) {


    let menuItems = [
        { title: "LogIn", component: "logIn" },
        { title: "Find Movies", component: "Search-for-movies" },
        { title: "Find People", component: "Search-for-persons" },
        { title: "People Bookmarks", component: "list-bookmarkPeople" },
        { title: "Title Bookmarks", component: "list-bookmarkTitle" },
        { title: "Search History", component: "searchHistory" },
        { title: "Rating History", component: "ratingHistory" },
        { title: "Register", component: "register" }
    ];

    let currentView = ko.observable(menuItems[0].component);

    let tconst = ko.observable();

    let changeContent = menuItem => {
        console.log(menuItem);
        currentView(menuItem.component)
    };

    let isActive = menuItem => {
        return menuItem.component === currentView() ? "active" : "";
    }

    postman.subscribe("changeView", function (data) {
        currentView(data);
    });

    return {
        currentView,
        menuItems,
        changeContent,
        isActive,
        tconst

    }
});