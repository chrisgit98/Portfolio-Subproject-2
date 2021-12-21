define([], () => {
    const usersUrl = "api/users";

    let register = (user, callback) => {
        let params = {
            method: "POST",
            body: JSON.stringify(user),
            headers: {
                "Content-Type": "application/json"
            }
        };
        fetch(usersUrl + '/register', params)
            .then(response => response.json())
            .then(json => callback(json));
    }

    let login = (user, callback) => {
        let params = {
            method: "POST",
            body: JSON.stringify(user),
            headers: {
                "Content-Type": "application/json"
            }
        };
        fetch(usersUrl + '/login', params)
            .then(response => response.json())
            .then(json => callback(json));
    }

    return {
        register,
        login
       
    }
});