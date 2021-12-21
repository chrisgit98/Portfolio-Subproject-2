define(['knockout', 'securityService'], (ko, ss) => {
    return function (params) {
        let username = ko.observable();
        let password = ko.observable();

        let login = () => {
            let user = {
                username: username(),
                password: password()
            };

            localStorage.removeItem("username");
            localStorage.removeItem("token");

            ss.login(user, data => {
                console.log(data);
                localStorage.setItem("username", data.username);
                localStorage.setItem("token", data.token);
                localStorage.setItem("u_id", JSON.parse(atob(data.token.split('.')[1])).u_id);
            });

        };

        let cancel = () => {
            // TODO
        }



        return {
            username,
            password,
            login,
            cancel
        };
    };
});