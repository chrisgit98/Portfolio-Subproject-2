define([], () => {

    let getSpecificMovies = (tconst, callback) => {
        console.log(tconst)
        fetch("api/titlebasics/" + "tt9460980 ")
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getSpecificMovies

    };

});