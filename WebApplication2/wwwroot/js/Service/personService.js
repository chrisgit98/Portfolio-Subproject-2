define([], () => {

    const nameSearchApiUrl = "api/namesearch/";

    let getPersons = (searchInput, callback) => {
        console.log(searchInput)
        fetch("api/namesearch/" + searchInput)
            .then(response => response.json())
            .then(json => callback(json));

    };

    let getNameSearchUrl = (url, callback) => {
        fetch(url)
            .then(response => response.json())
            .then(json => callback(json));
    };

    /*Person Details*/

    let getSpecificPerson = (personId, callback) => {
        console.log(personId)
        fetch("api/namedetails/" + "nm0000158")
            .then(response => response.json())
            .then(json => callback(json));
    };

    /*FindingCoPlayers*/
    let getCoPlayers = (personId, callback) => {
        console.log(personId)
        fetch("api/FindingCoPlayer/" + "nm0000158")
            .then(response => response.json())
            .then(json => callback(json));

    };

    return {
        nameSearchApiUrl,
        getPersons,
        getNameSearchUrl,
        getSpecificPerson,
        getCoPlayers

    };




});