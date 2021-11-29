require.config({
    baseUrl: 'js',
    paths: {

        knockout: "lib/knockout/knockout-latest",
        text: "lib/require-text/text.min",
        dataservice: "Service/dataService"
    }
});


require(['knockout', 'text'], (ko, vm) => {

    ko.components.register("Search-for-movies", {
        viewModel: { require: "components/SearchBar/SearchBar" },
        template: { require: "text!Components/SearchBar/SearchBar.html" }
    });

});

require(['knockout', 'viewModel'], (ko, vm) => {


    ko.applyBindings(vm);

});