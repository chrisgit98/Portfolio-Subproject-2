require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery",
        bootstrap: "lib/bootstrap/js/bootstrap",
        knockout: "lib/knockout/knockout-latest",
        text: "lib/require-text/text",
        movieservice: "Service/movieService",
        personservice: "Service/personService",
        bookmarkPeopleService: "Service/bookmarkPeopleService",
        searchHistoryService: "Service/searchHistoryService",
        displayPersonService: "Service/displayPersonService",
        bookmarkTitleService: "Service/bookmarkTitleService",
        postman: "Service/postman"
    }
});


require(['knockout'], (ko) => {

    ko.components.register("Search-for-movies", {
        viewModel: { require: "Components/MovieSearchBar/movieSearchBar" },
        template: { require: "text!Components/MovieSearchBar/movieSearchBar.html" }
    });
    ko.components.register("displayMovie", {
        viewModel: { require: "Components/DisplayMovie/displayMovie" },
        template: { require: "text!Components/DisplayMovie/displayMovies.html" }
    });
    ko.components.register("list-bookmarkPeople", {
        viewModel: { require: "Components/BookmarkPeople/bookmarkPeople" },
        template: { require: "text!Components/BookmarkPeople/bookmarkPeople.html" }
    });
    ko.components.register("list-bookmarkTitle", {
        viewModel: { require: "Components/BookmarkTitle/bookmarkTitle" },
        template: { require: "text!Components/BookmarkTitle/bookmarkTitle.html" }
    });
    ko.components.register("searchHistory", {
        viewModel: { require: "Components/SearchHistory/searchHistory" },
        template: { require: "text!Components/SearchHistory/searchHistory.html" }
    });
    ko.components.register("Search-for-persons", {
        viewModel: { require: "Components/PersonSearchBar/personSearchBar" },
        template: { require: "text!Components/PersonSearchBar/personSearchBar.html" }
    });
    ko.components.register("displayPerson", {
        viewModel: { require: "Components/DisplayPerson/displayPerson" },
        template: { require: "text!Components/DisplayPerson/displayPerson.html" }
    });

});

require(['knockout', 'viewModel'], (ko, vm) => {


    ko.applyBindings(vm);

});