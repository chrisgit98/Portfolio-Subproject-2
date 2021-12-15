define(['knockout', 'personService', 'postman'], function (ko, ps, postman) {
    return function (params) {
        let nameOtherview = ko.observableArray([]);
        let personId = ko.observable();

        let findingCoPlayers = ko.observableArray([]);

        let getPerson = () => {
            ps.getSpecificPerson(personId(), data => {
                console.log(data);
                nameOtherview(data);
            });
        }

        let Back = () => postman.publish("changeView", "Search-for-persons");

        getPerson();


        /*CoPlayers*/
        ps.getCoPlayers(personId(), data => {
            console.log(data);
            findingCoPlayers(data);
        });

     
        return {
            nameOtherview,
            person,
            getPerson,
            Back,
            findingCoPlayers
            
        };
    };
});