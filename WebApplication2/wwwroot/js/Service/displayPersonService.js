define([], () => {

    let getSpecificPerson = (personId, callback) => {
        console.log(personId)
        fetch("api/namedetails/" + "nm0000158")
            .then(response => response.json())
            .then(json => callback(json));
    };

    /*SimilarMoviess*/
    let getCoPlayers = (personId, callback) => {
        console.log(personId)
        fetch("api/FindingCoPlayer/" + "nm0000158")
            .then(response => response.json())
            .then(json => callback(json));

    };

    return {
        getSpecificPerson,
        getCoPlayers
        
    };

});