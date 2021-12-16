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
        fetch("api/StringSearch/" + searchInput, params)
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

    let getSpecificMovie = (tconst, callback) => {
        console.log(tconst)
        fetch("api/moviedetails/" + tconst)
            .then(response => response.json())
            .then(json => callback(json));
    };

    /*SimilarMoviess*/
    let getSimilarMovies = (tconst, callback) => {
        console.log(tconst)
        fetch("api/SimilarMovies/" + tconst)
            .then(response => response.json())
            .then(json => callback(json));

    };

    let getPopularActors = (tconst, callback) => {
        console.log(tconst)
        fetch("api/PopularActors/" + tconst)
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