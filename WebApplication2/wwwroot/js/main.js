require.config({
    baseUrl: 'js',
    paths: {
        jquery: "lib/jquery/dist/jquery",
        bootstrap: "lib/bootstrap/js/bootstrap",
        knockout: "lib/knockout/knockout-latest",
        text: "lib/require-text/text",
        movieservice: "Service/movieService",
        personservice: "Service/personService",
        bookmarkService: "Service/bookmarkService",
        searchHistoryService: "Service/searchHistoryService",
        securityService: "Service/securityService",
        ratingService: "Service/ratingService",
        postman: "Service/postman"
    }
});


require(['knockout'], (ko) => {

    ko.components.register("Search-for-movies", {
        viewModel: { require: "Components/MovieSearchBar/movieSearchBar" },
        template: { require: "text!Components/MovieSearchBar/movieSearchBar.html" }
    });
    ko.components.register("movieDetails", {
        viewModel: { require: "Components/MovieDetails/movieDetails" },
        template: { require: "text!Components/MovieDetails/movieDetails.html" }
    });
    ko.components.register("Search-for-persons", {
        viewModel: { require: "Components/PersonSearchBar/personSearchBar" },
        template: { require: "text!Components/PersonSearchBar/personSearchBar.html" }
    });
    ko.components.register("personDetails", {
        viewModel: { require: "Components/PersonDetails/personDetails" },
        template: { require: "text!Components/PersonDetails/personDetails.html" }
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
    ko.components.register("logIn", {
        viewModel: { require: "Components/Security/userLogin" },
        template: { require: "text!Components/Security/userLogin.html" }
    });
    ko.components.register("register", {
        viewModel: { require: "Components/Security/userRegister" },
        template: { require: "text!Components/Security/userRegister.html" }
    });
    ko.components.register("ratingHistory", {
        viewModel: { require: "Components/TitleRating/titleRating" },
        template: { require: "text!Components/TitleRating/titleRating.html" }
    });
    

});

require(['knockout', 'viewModel'], (ko, vm) => {


    ko.applyBindings(vm);

});