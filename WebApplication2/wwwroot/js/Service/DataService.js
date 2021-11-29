define([], () => {
    const moviesApiUrl = "api/sss";

    let getJson = (url, callback) => {
        fetch(url).then(response => response.json()).then(callback);
    };

    let getMovies = (url, callback) => {
        if (url === undefined) {
            url = moviesApiUrl;
        }
        getJson(url, callback)

    };
    return {
        getMovies,
        getMovie: getJson
    };

});