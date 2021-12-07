define([], () => {

    let getPopularActors = (popularActors, callback) => {
        console.log(popularActors)
        fetch("api/PopularActors/" + popularActors)
            .then(response => response.json())
            .then(json => callback(json));

    };

    return {
        getPopularActors
    };

});