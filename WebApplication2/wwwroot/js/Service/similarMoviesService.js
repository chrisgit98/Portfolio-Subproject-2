define([], () => {

    let getSimilarMovies = (similarMovies, callback) => {
        console.log(similarMovies)
        fetch("api/SimilarMovies/" + similarMovies)
            .then(response => response.json())
            .then(json => callback(json));

    };

    return {
        getSimilarMovies

    };

});