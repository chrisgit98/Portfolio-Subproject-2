define([], () => {

    let getSearchHistory = (callback) => {
        let params = {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        };
        fetch("api/searchhistory/" + localStorage.getItem("u_id"), params)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    }

    let deleteSearchHistory = searchHistory => {
        console.log(searchHistory.url);
        fetch(searchHistory.url + "/" + searchHistory.filmId, { method: "DELETE" })
            .then(response => console.log(response.status))
    };

   

    return {
        getSearchHistory,
        deleteSearchHistory
        
    }
});