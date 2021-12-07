define([], () => {

    let getSearchHistory = (callback) => {
        fetch("api/searchhistory")
            .then(response => response.json())
            .then(json => callback(json));
    };

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