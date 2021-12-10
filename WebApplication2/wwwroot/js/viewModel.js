define(["knockout", "postman"], function (ko, postman) {


    let menuItems = [
        { title: "Find Movies", component: "Search-for-movies" },
        { title: "People Bookmark", component: "list-bookmarkPeople" },
        { title: "Search History", component: "searchHistory" }
    ];

    let currentView = ko.observable(menuItems[0].component);

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

    }
});