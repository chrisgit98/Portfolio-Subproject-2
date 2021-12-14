define([], () => {

    /*Search Page*/

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

    /*Deatils Page*/

    let getSpecificMovie = (tconst, callback) => {
        console.log(tconst)
        fetch("api/titlebasics/" + tconst)
            .then(response => response.json())
            .then(json => callback(json));
    };

    /*SimilarMoviess*/
    let getSimilarMovies = (similarMovies, callback) => {
        console.log(similarMovies)
        fetch("api/SimilarMovies/" + "tt8305218")
            .then(response => response.json())
            .then(json => callback(json));

    };

    let getPopularActors = (popularActors, callback) => {
        console.log(popularActors)
        fetch("api/PopularActors/" + "tt8305218")
            .then(response => response.json())
            .then(json => callback(json));

    };


    return {
        getMovies,
        getStringSearchUrl,
        getSpecificMovie,
        getSimilarMovies,
        getPopularActors
        
    };

});