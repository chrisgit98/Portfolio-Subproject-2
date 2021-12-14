define([], () => {

    const nameSearchApiUrl = "api/namesearch/";

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

    let getPersons = (searchInput, callback) => {
        console.log(searchInput)
        fetch("api/namesearch/" + searchInput)
            .then(response => response.json())
            .then(json => callback(json));

    };

    let getNameSearchUrl = (url, callback) => {
        fetch(url)
            .then(response => response.json())
            .then(json => callback(json));
    };


    return {
        nameSearchApiUrl,
        getPersons,
        getNameSearchUrl

    };

});