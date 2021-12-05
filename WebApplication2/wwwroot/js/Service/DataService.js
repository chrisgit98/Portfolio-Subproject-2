define([], () => {

    let getMovies = (searchString, callback) => {
        console.log(searchString)
        fetch("api/StringSearch/" + searchString)
            .then(response => response.json())
            .then(json => callback(json));

    };

    return {
        getMovies

    };

});