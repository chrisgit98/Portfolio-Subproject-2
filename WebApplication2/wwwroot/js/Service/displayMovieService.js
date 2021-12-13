define([], () => {

    let getSpecificMovie = (tconst, callback) => {
        console.log(tconst)
        fetch("api/titlebasics/" + "tt8305218")
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
        getSpecificMovie,
        getSimilarMovies,
        getPopularActors
    };

});