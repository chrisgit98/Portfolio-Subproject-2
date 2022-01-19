define([], () => {

    /*Bookmark a movie*/
    let getBookmarkTitle = (callback) => {
        let params = {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        };
        fetch("api/BookmarkTitle/" + localStorage.getItem("u_id"), params)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    }

    let deleteBookmarkTitle = bookmarkTitle => {
        let param = {
            method: "DELETE",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token"),

            }
        }
        console.log(bookmarkTitle.url);
        fetch("api/BookmarkTitle/" + bookmarkTitle.filmId, param)
            .then(response => console.log(response.status))
    };

    let createBookmarkTitle = (bookmarkTitle, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(bookmarkTitle),
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json"
            }
        }
        fetch("api/BookmarkTitle", param)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    }

    /*Bookmark a person*/
    let getBookmarkPeople = (callback) => {
        let params = {
            method: "GET",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token")
            }
        };
        fetch("api/BookmarkPeople/" + localStorage.getItem("u_id"), params)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    }

    let deleteBookmarkPeople = bookmarkPeople => {
        let param = {
            method: "DELETE",
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token"),

            }
        }
        console.log(bookmarkPeople.url);
        fetch("api/BookmarkPeople/" + bookmarkPeople.personId, param)
            .then(response => console.log(response.status))
    
    };

    let createBookmarkPeople = (bookmarkPeople, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(bookmarkPeople),
            headers: {
                "Authorization": "Bearer " + localStorage.getItem("token"),
                "Content-Type": "application/json"
            }
        }
        fetch("api/BookmarkPeople", param)
            .then(response => {
                if (!response.ok) {
                    throw Error(response.statusText);
                }
                return response.json();
            }).then(json => callback(json));
    };



    return {
        getBookmarkTitle,
        deleteBookmarkTitle,
        createBookmarkTitle,
        getBookmarkPeople,
        deleteBookmarkPeople,
        createBookmarkPeople
    }
});