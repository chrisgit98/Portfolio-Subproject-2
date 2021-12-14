define(['knockout', 'displayPersonService', 'postman'], function (ko, dps, postman) {
    return function (params) {
        let nameOtherview = ko.observableArray([]);
        let personId = ko.observable();

        let findingCoPlayers = ko.observableArray([]);

        let getPerson = () => {
            dps.getSpecificPerson(personId(), data => {
                console.log(data);
                nameOtherview(data);
            });
        }

        let Back = () => postman.publish("changeView", "Search-for-persons");

        getPerson();


        /*CoPlayers*/
        dps.getCoPlayers(personId(), data => {
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