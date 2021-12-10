define([], () => {

    let getSpecificMovies = (searchString, callback) => {
        console.log(searchString)
        fetch("api/titlebasics/" + searchString.tconst)
            .then(response => response.json())
            .then(json => callback(json));

    };

    return {
        getSpecificMovies

    };

});