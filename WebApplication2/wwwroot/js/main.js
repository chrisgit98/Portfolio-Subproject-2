require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery",
        bootstrap: "lib/bootstrap/js/bootstrap",
        knockout: "lib/knockout/knockout-latest",
        text: "lib/require-text/text",
        dataservice: "Service/DataService",
        bookmarkPeopleService: "Service/bookmarkPeopleService",
        similarMoviesService: "Service/similarMoviesService"
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

});

require(['knockout', 'viewModel'], (ko, vm) => {


    ko.applyBindings(vm);

});