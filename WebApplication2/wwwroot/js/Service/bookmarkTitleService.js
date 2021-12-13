define([], () => {

    let getBookmarkTitle = (callback) => {
        fetch("api/BookmarkTitle")
            .then(response => response.json())
            .then(json => callback(json));
    };

    let deleteBookmarkTitle = bookmarkTitle => {
        console.log(bookmarkTitle.url);
        fetch(bookmarkTitle.url + "/" + bookmarkTitle.filmId, { method: "DELETE" })
            .then(response => console.log(response.status))
    };

    let createBookmarkTitle = (bookmarkTitle, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(bookmarkTitle),
            headers: {
                "Content-Type": "application/json"
            }
        }
        fetch("api/BookmarkTitle", param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getBookmarkTitle,
        deleteBookmarkTitle,
        createBookmarkTitle
    }
});