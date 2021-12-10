require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery",
        bootstrap: "lib/bootstrap/js/bootstrap",
        knockout: "lib/knockout/knockout-latest",
        text: "lib/require-text/text",
        dataservice: "Service/DataService",
        bookmarkPeopleService: "Service/bookmarkPeopleService",
        similarMovieService: "Service/similarMoviesService",
        searchHistoryService: "Service/searchHistoryService",
        popularActorsService: "Service/popularActorsService",
        displayMovieService: "Service/displayMovieService",
        postman: "Service/postman"
    }
});


require(['knockout'], (ko) => {

    ko.components.register("Search-for-movies", {
        viewModel: { require: "Components/SearchBar/SearchBar" },
        template: { require: "text!Components/SearchBar/SearchBar.html" }
    });
    ko.components.register("list-bookmarkPeople", {
        viewModel: { require: "Components/BookmarkPeople/bookmarkPeople" },
        template: { require: "text!Components/BookmarkPeople/bookmarkPeople.html" }
    });
    ko.components.register("similarMovies", {
        viewModel: { require: "Components/SimilarMovies/similarMovies" },
        template: { require: "text!Components/SimilarMovies/similarMovies.html" }
    });
    ko.components.register("searchHistory", {
        viewModel: { require: "Components/SearchHistory/searchHistory" },
        template: { require: "text!Components/SearchHistory/searchHistory.html" }
    });
    ko.components.register("popularActors", {
        viewModel: { require: "Components/PopularActors/popularActors" },
        template: { require: "text!Components/PopularActors/popularActors.html" }
    });
    ko.components.register("displayMovie", {
        viewModel: { require: "Components/DisplayMovie/displayMovie" },
        template: { require: "text!Components/DisplayMovie/displayMovies.html" }
    });

});

require(['knockout', 'viewModel'], (ko, vm) => {


    ko.applyBindings(vm);

});