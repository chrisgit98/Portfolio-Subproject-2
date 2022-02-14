define([], () => {

    let getSearchHistory = (callback) => {
        let params = {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        };
        fetch("api/searchhistory", params)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    };

    let deleteSearchHistory = searchHistory => {
        let param = {
            method: "DELETE",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token"),

            }
        }
        console.log(searchHistory.url);
        fetch("api/searchhistory", param)
            .then(response => console.log(response.status))
    };

    let getSearchHistoryUrl = (url, callback) => {
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
   

    return {
        getSearchHistory,
        deleteSearchHistory,
        getSearchHistoryUrl
        
    }
});