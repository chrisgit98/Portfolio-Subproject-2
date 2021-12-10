define([], () => {

    let getMovies = (searchString, callback) => {
        console.log(searchString)
        fetch("api/StringSearch/" + searchString)
            .then(response => response.json())
            .then(json => callback(json));

    };

    let getSpecificMovies = (tconst, callback) => {
        console.log(tconst)
        fetch("api/titlebasics/" + tconst)
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getMovies,
        getSpecificMovies

    };

});