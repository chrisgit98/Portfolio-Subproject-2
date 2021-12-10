define([], () => {

    //const stringSearchApiUrl = "api/StringSearch/";

    //let getJson = (searchInput, callback) => {
    //    fetch(stringSearchApiUrl + searchInput)
    //        .then(response => response.json())
    //        .then(callback);
    //};

    //let getMovies = (stringSearchApiUrl, callback) => {
    //    if (stringSearchApiUrl === undefined) {
    //        stringSearchApiUrl;
    //    }
    //    getJson(stringSearchApiUrl, callback)

    //};

    let getMovies = (searchInput, callback) => {
        console.log(searchInput)
        fetch("api/StringSearch/" + searchInput)
            .then(response => response.json())
            .then(json => callback(json));

    };

    let getStringSearchUrl = (url, callback) => {
        fetch(url)
            .then(response => response.json())
            .then(json => callback(json));
    };


    return {
        getMovies,
        getStringSearchUrl
        
    };

});