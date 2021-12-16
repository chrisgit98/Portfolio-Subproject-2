define(['knockout', 'securityService', 'postman'], (ko, ss, postman) => {
    return function (params) {
        let name = ko.observable();
        let username = ko.observable();
        let password = ko.observable();

        let register = () => {
            let user = {
                name: name(),
                username: username(),
                password: password()
            };

            ss.register(user, data => {
                console.log(data);
                postman.publish("changeView", "logIn");
            });

        };

        let cancel = () => {
            // TODO
        }



        return {
            username,
            password,
            name,
            register,
            cancel
        };
    };
});