define([], () => {

    /*const nameSearchApiUrl = "api/namesearch/";*/

    let getPersons = (searchInput, callback) => {
        let params = {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        };
        console.log(searchInput)
        fetch("api/namesearch/" + searchInput, params)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    }

    let getNameSearchUrl = (url, callback) => {
        let params = {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        };
        fetch(url, params)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    };

    /*Person Details*/

    let getSpecificPerson = (personId, callback) => {
        console.log(personId)
        fetch("api/namedetails/" + personId)
            .then(response => response.json())
            .then(json => callback(json));
    };

    /*FindingCoPlayers*/
    let getCoPlayers = (personId, callback) => {
        console.log(personId)
        fetch("api/FindingCoPlayer/" + personId)
            .then(response => response.json())
            .then(json => callback(json));

    };

    return {
        /*nameSearchApiUrl,*/
        getPersons,
        getNameSearchUrl,
        getSpecificPerson,
        getCoPlayers

    };




});