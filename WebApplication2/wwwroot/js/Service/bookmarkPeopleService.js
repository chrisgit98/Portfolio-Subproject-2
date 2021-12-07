define([], () => {
    
    let getBookmarkPeople = (callback) => {
        fetch("api/BookmarkPeople")
            .then(response => response.json())
            .then(json => callback(json));
    };

    let deleteBookmarkPeople = bookmarkPeople => {
        console.log(bookmarkPeople.url);
        fetch(bookmarkPeople.url +"/"+ bookmarkPeople.personId, { method: "DELETE" })
            .then(response => console.log(response.status))
    };

    let createBookmarkPeople = (bookmarkPeople, callback) => {
        let param = {
            method: "POST",
            body: JSON.stringify(bookmarkPeople), 
            headers: {
                "Content-Type": "application/json"
            }
        }
        fetch("api/BookmarkPeople", param)
            .then(response => response.json())
            .then(json => callback(json));
    };

    return {
        getBookmarkPeople,
        deleteBookmarkPeople,
        createBookmarkPeople
    }
});