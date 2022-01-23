define([], () => {

    /*Search Page*/

    let getMovies = (searchInput, callback) => {
        let params = {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        };
        console.log(searchInput, localStorage.getItem("token"))
        fetch("api/bestmatch/" + searchInput, params)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    }

    let getStringSearchUrl = (url, callback) => {
        fetch(url)
            .then(response => response.json())
            .then(json => callback(json));
    };

    /*Deatils Page*/

    let getSpecificMovie = (filmId, callback) => {
        console.log(filmId)
        fetch("api/moviedetails/" + filmId)
            .then(response => response.json())
            .then(json => callback(json));
    };

    /*SimilarMoviess*/
    let getSimilarMovies = (filmId, callback) => {
        console.log(filmId)
        fetch("api/SimilarMovies/" + filmId)
            .then(response => response.json())
            .then(json => callback(json));

    };

    let getPopularActors = (filmId, callback) => {
        console.log(filmId)
        fetch("api/PopularActors/" + filmId)
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